using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;

namespace TrainHoppers.Core.ServiceInterface
{
    public interface IAbilitiesServices
    {
        Task<Ability> DetailsAsync(Guid id);

    }
}
