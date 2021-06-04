using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

using selo_postal_service.Core.Domain.DTO;
using selo_postal_service.Core.Domain.Entities;
using selo_postal_service.Core.Interfaces;

namespace selo_postal_service.Data.Repository
{
    public class QrCodeRepository : IQrCodeRepository
    {
        public List<TsvObjectItem> GetQrCode(List<Endereco> list)
        {
            List<TsvObjectItem> listToTsv = new List<TsvObjectItem>();
            string path = @"..\..\..\QRCode";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            foreach (var item in list)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                string gerarNomeArquivo = @"..\..\..\QRCode\Endereco " + item.Nome + ".png";
                qrCodeImage.Save(gerarNomeArquivo, ImageFormat.Png);

                listToTsv.Add(new TsvObjectItem(item.Nome, item.EnderecoCasa, item.NumeroCasa, item.CodigoPostal, item.Bairro, item.Cidade, item.Estado, gerarNomeArquivo));
            }

            return listToTsv;
        }
    }
}