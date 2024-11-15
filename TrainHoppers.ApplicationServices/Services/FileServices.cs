using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;

namespace TrainHoppers.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly TrainHoppersContext _context;

        public FileServices(IHostEnvironment webHost, TrainHoppersContext context)
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(AbilityDto dto, Ability domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            AbilityID = domain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
        public void UploadFilesToDatabase(PowerupDto dto, Powerup domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            PowerupID = domain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imgId = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imgId.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FilesToDatabase
                .Remove(imgId);
            await _context.SaveChangesAsync();
            return null;
        }

    }
}
