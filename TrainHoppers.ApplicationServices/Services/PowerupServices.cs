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
    public class PowerupServices : IPowerupsServices
    {
        private readonly TrainHoppersContext _context;
        private readonly IFileServices _fileServices;
        // private readonly IFileServices _fileServices

        public PowerupServices(TrainHoppersContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Powerup> Create(PowerupDto dto)
        {
            Powerup powerup = new Powerup();
            powerup.ID = Guid.NewGuid();
            powerup.PowerUpName = dto.PowerUpName;
            powerup.PowerUpDescription = dto.PowerUpDescription;
            powerup.PowerupType = dto.PowerupType;
            powerup.CreatedAt = DateTime.Now;
            powerup.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, powerup);
            }
            await _context.Powerups.AddAsync(powerup);
            await _context.SaveChangesAsync();
            return powerup;

        }
    }
}
