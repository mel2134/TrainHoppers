using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;

namespace TrainHoppers.ApplicationServices.Services
{
    public class AbilitiesServices : IAbilitiesServices
    {
        private readonly TrainHoppersContext _context;
        // private readonly IFileServices _fileServices

        public AbilitiesServices(TrainHoppersContext context/*, IFileServices fileServices*/)
        {
            _context = context;
            // _fileServices = fileServices
        }

        /// <summary>
        /// Get details for one Ability
        /// </summary>
        /// <param name="id">Id of ability to show details of</param>
        /// <returns>resulting ability</returns>
        public async Task<Ability> DetailsAsync(Guid id)
        {
            var result = await _context.Abilities
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
    }
}
