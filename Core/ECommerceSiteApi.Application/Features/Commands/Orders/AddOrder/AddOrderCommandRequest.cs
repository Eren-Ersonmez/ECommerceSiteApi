

using MediatR;

namespace ECommerceSiteApi.Application.Features.Commands.Orders.AddOrder;

public class AddOrderCommandRequest:IRequest<AddOrderCommandResponse>
{
    public double OrderTotal { get; set; }
    public Guid AddressId { get; set; }
    public Guid CreditCardId { get; set; }
    public IEnumerable<Guid> OrderDetailIds { get; set; }
}
