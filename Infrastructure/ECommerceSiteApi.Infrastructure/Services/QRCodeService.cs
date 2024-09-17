

using ECommerceSiteApi.Application.Services;
using QRCoder;

namespace ECommerceSiteApi.Infrastructure.Services;

public class QRCodeService : IQRCodeService
{
    public byte[] GenerateQRCode(string text)
    {
        QRCodeGenerator codeGenerator = new QRCodeGenerator();
        QRCodeData codeData = codeGenerator.CreateQrCode(text,QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qRCode = new PngByteQRCode(codeData);
        byte[] byteGraphic = qRCode.GetGraphic(10, new byte[] { 84, 99, 71 }, new byte[] { 240, 240, 240 });
        return byteGraphic;
    }
}
