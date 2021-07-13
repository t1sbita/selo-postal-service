
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QRCoder;

using selo_postal_api.Core.Domain.Entities;
using selo_postal_api.Core.Interfaces;
using selo_postal_api.Data.Context;
using System;

namespace selo_postal_api.Data.Repository
{
    public class QrCodeRepository : IQrCodeRepository
    {
        public readonly PostgresContext _context;

        public QrCodeRepository(PostgresContext context)
        {
            _context = context;
        }


        public static byte[] ToByteArray(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                return Array.Empty<byte>();
            }
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public byte[] GetQrCode(int id)
        {
            Endereco endereco = _context.Endereco.Include(c => c.Cidade).FirstOrDefault(e => e.Id == id);
            if (endereco != null)
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(endereco.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                return ToByteArray(qrCodeImage);
            }
            return Array.Empty<byte>();

        }
    }
}