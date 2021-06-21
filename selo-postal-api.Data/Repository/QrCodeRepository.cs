using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QRCoder;

using selo_postal_api.Core.Domain.DTO;
using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Data.Context;

namespace selo_postal_api.Data.Repository
{
    public class QrCodeRepository : IQrCodeRepository
    {
        public readonly PostgresContext _context;
        public QrCodeRepository(PostgresContext context)
        {
            _context = context;
        }
        public List<TsvObjectItem> GetQrCode(List<Endereco> list)
        {
            List<TsvObjectItem> listToTsv = new List<TsvObjectItem>();
            
            foreach (var item in list)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                Etiqueta etiqueta = new Etiqueta(ToByteArray(qrCodeImage), item);

                _context.Etiqueta.Add(etiqueta);
                _context.SaveChanges();

                var tsvObject = TsvObjectItem.Build().WithName("fsad").WithEndereco("sdas").WithNumero(item.Cidade == null ? null : item.Cidade.Municipio);

                if (item.Cidade != null)
                {
                    
                    listToTsv.Add(
                        new TsvObjectItem(
                            item.Nome, 
                            item.EnderecoCasa, 
                            item.NumeroCasa, 
                            item.CodigoPostal, 
                            item.Bairro, 
                            item.Cidade.Municipio, 
                            item.Cidade.Estado, 
                            $"https://localhost:5001/api/Endereco/{etiqueta.Id}/qrcode"
                            )
                        );
                    
                }
                else
                {
                    listToTsv.Add(
                        new TsvObjectItem(
                            item.Nome, 
                            item.EnderecoCasa, 
                            item.NumeroCasa, 
                            item.CodigoPostal, 
                            item.Bairro, 
                            "null", 
                            "null", 
                            $"https://localhost:5001/api/Endereco/{etiqueta.Id}/qrcode"
                            )
                        );
                }
                
            }

            return listToTsv;
        }

        public static byte[] ToByteArray(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                return null;
            }
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public byte[] RecuperaQrCode(int id)
        {
            return _context.Etiqueta.Where(i => i.Id == id).Select(e => e.CodigoQr).FirstOrDefault();
        }
    }
}