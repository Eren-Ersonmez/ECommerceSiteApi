

namespace ECommerceSiteApi.Application.Services;

public interface IQRCodeService
{
    byte[] GenerateQRCode(string text);
}
