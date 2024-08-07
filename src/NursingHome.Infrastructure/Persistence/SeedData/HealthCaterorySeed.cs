using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class HealthCaterorySeed
{
    public static List<HealthCategory> Default =>
         new List<HealthCategory>
         {
             new HealthCategory {
               Name = "Huyết áp",
               ImageUrl ="https://thanhnien.mediacdn.vn/Uploaded/ngocquy/2021_10_30/1-huyet-ap-shutterstock-6379.jpeg" ,
               Description="Đo các chỉ số liên quan đến huyết áp",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit {
                        Name = "Huyết áp tâm thu",
                        Description = "Áp lực trong động mạch khi tim co bóp",
                        UnitType ="mg/dL",
                        MinValue = 60,
                        MaxValue = 90
                    },
                    new MeasureUnit { Name = "Huyết áp tâm trương", Description = "Áp lực trong động mạch khi tim nghỉ",UnitType ="mg/dL" },
                }
            },
            new HealthCategory {
               Name = "Đường huyết",
               ImageUrl ="https://static.vecteezy.com/system/resources/previews/005/116/379/original/blood-sugar-logo-template-this-design-use-glucose-symbol-suitable-for-medical-business-free-vector.jpg" ,
               Description="Theo dõi các chỉ số đường huyết quan trọng",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Đường huyết ngẫu nhiên", Description = "Đo mức đường trong máu tại bất kỳ thời điểm nào",UnitType ="mg/dL" },
                }
            },
            new HealthCategory {
               Name = "Cholesterol" ,
               ImageUrl="https://media.gettyimages.com/id/1413404652/vector/cholesterol-education-month-september-vector.jpg?s=612x612&w=gi&k=20&c=Q4dSiTTOlce99S6BqIdc0O8KPMiuJmb2_1wvoD8uGxU=",
               Description="Theo dõi các chỉ số liên quan đến cholesterol trong máu",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Cholesterol toàn phần", Description = "Đo lượng cholesterol tổng trong máu",UnitType ="mg/dL" }
                }
            },
            new HealthCategory {
               Name = "Phổi",
               ImageUrl="https://img.lovepik.com/free-png/20210926/lovepik-lung-png-image_401431526_wh1200.png",
               Description = "Theo dõi các chỉ số liên quan đến phổi",
               MeasureUnits = new List<MeasureUnit>
               {
                 new MeasureUnit { Name = "Dung tích phổi", Description = "Dung tích phổi khi hít vào và thở ra", UnitType = "mL" },
               }
            },
            new HealthCategory {
               Name = "Thận",
               ImageUrl="https://media.istockphoto.com/id/1317973249/vi/vec-to/%E1%BA%A3nh-minh-h%E1%BB%8Da-s%E1%BB%8Fi-th%E1%BA%ADn-%C4%91%C6%B0%E1%BB%A3c-ph%C3%A2n-l%E1%BA%ADp-tr%C3%AAn-n%E1%BB%81n-tr%E1%BA%AFng-kh%C3%A1i-ni%E1%BB%87m-v%E1%BB%81-b%E1%BB%87nh-th%E1%BA%ADn.jpg?s=1024x1024&w=is&k=20&c=dS0VdCfCyKg4OsaBslB2zS9WrCD2x41WMKE6ZTdXXAA=",
               Description = "Theo dõi các chỉ số liên quan đến thận",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Creatinine", Description = "Đo mức creatinine trong máu để đánh giá chức năng thận", UnitType = "mg/dL" },
                }
            }
         };
}
