using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NursingHome.Application.Common.Resources;
using NursingHome.Application.Contracts.Services;
using NursingHome.Infrastructure.Settings;
using System.Net;

namespace NursingHome.Infrastructure.Services;

public class StorageService : IStorageService
{
    private readonly AwsS3Settings _settings;
    private readonly IAmazonS3 _s3Client;

    public StorageService(IOptions<AwsS3Settings> settings)
    {
        _settings = settings.Value;
        _s3Client = new AmazonS3Client(
            _settings.AccessKey,
            _settings.SecretKey,
            RegionEndpoint.GetBySystemName(_settings.Region));
    }

    public async Task<byte[]> DownloadFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _settings.BucketName,
            Key = fileName
        };

        using var response = await _s3Client.GetObjectAsync(getObjectRequest, cancellationToken);
        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException(Resource.FileNotFound);
        }

        using var ms = new MemoryStream();
        await response.ResponseStream.CopyToAsync(ms, cancellationToken);
        return ms.ToArray();

    }

    public async Task<string> GetContentTypeAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _settings.BucketName,
            Key = fileName
        };

        using var response = await _s3Client.GetObjectAsync(getObjectRequest, cancellationToken);
        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException(Resource.FileNotFound);
        }

        return response.Headers.ContentType;
    }

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms, cancellationToken);

        var fileName = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}-{file.FileName}";
        var uploadFileRequest = new TransferUtilityUploadRequest
        {
            InputStream = ms,
            Key = fileName, // create unique file name
            BucketName = _settings.BucketName,
            ContentType = file.ContentType
        };

        var fileTransferUtility = new TransferUtility(_s3Client);

        await fileTransferUtility.UploadAsync(uploadFileRequest, cancellationToken);

        return fileName;
    }

    public async Task<bool> DeleteFileAsync(string fileName, string versionId = "", CancellationToken cancellationToken = default)
    {
        var deleteFileRequest = new DeleteObjectRequest()
        {
            BucketName = _settings.BucketName,
            Key = fileName,
            VersionId = !string.IsNullOrWhiteSpace(versionId) ? versionId : null
        };

        if (!string.IsNullOrEmpty(versionId))
        {
            deleteFileRequest.VersionId = versionId;
        }

        var response = await _s3Client.DeleteObjectAsync(deleteFileRequest, cancellationToken);
        if (response.HttpStatusCode != HttpStatusCode.OK)
        {
            throw new ApplicationException(Resource.FileUploadFailed);
        }

        return true;
    }

    public async Task<bool> IsFileExistsAsync(string fileName, string versionId = "", CancellationToken cancellationToken = default)
    {
        try
        {
            var getMetaObjectRequest = new GetObjectMetadataRequest()
            {
                BucketName = _settings.BucketName,
                Key = fileName,
                VersionId = !string.IsNullOrWhiteSpace(versionId) ? versionId : null
            };

            var response = await _s3Client.GetObjectMetadataAsync(getMetaObjectRequest, cancellationToken);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null && ex.InnerException is AmazonS3Exception awsEx)
            {
                if (string.Equals(awsEx.ErrorCode, "NoSuchBucket"))
                    return false;

                if (string.Equals(awsEx.ErrorCode, "NotFound"))
                    return false;
            }

            throw;
        }
    }

    public Task<string> GetPresignedUrlAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var urlRequest = new GetPreSignedUrlRequest()
        {
            BucketName = _settings.BucketName,
            Key = fileName,
            Expires = DateTime.UtcNow.AddMinutes(1)
        };

        return Task.FromResult(_s3Client.GetPreSignedURL(urlRequest));
    }

    public string GetObjectUrl(string fileName)
    {
        return $"https://{_settings.BucketName}.s3.{_settings.Region}.amazonaws.com/{fileName}";
    }
}