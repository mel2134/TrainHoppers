using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;

namespace TrainHoppers.Core.ServiceInterface
{
    public interface IPowerupsServices
    {
        Task<Powerup> Create(PowerupDto dto);
        Task<Powerup> DetailsAsync(Guid id);
    }
}
