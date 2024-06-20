namespace NursingHome.Application.Features.Orders.Models;
public record OrderResponse : BaseOrderResponse
{
    //public User User { get; set; } = default!;
    //public ServicePackage ServicePackage { get; set; } = default!;
    //public NursingPackage NursingPackage { get; set; } = default!;
    //public Elder Elder { get; set; } = default!;
    //public FeedBack FeedBack { get; set; } = default!;
    public ICollection<OrderDateResponse> OrderDates { get; set; } = new List<OrderDateResponse>();

}
