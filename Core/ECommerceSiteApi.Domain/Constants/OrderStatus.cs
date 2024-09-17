
namespace ECommerceSiteApi.Domain.Constants;

public static class OrderStatus
{
    public const string OrderIsBeingPrepared = "Sipariş Hazırlanıyor";
    public const string WaitingForOrderConfirmation = "Sipariş Onay Bekliyor";
    public const string HasBeenShipped = "Sipariş kargoya verildi";
    public const string Delivered = "Sipariş Teslim edildi";
}
