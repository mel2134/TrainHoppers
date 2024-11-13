using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;

namespace TrainHoppers.ApplicationServices.Services
{
    public class AbilitiesServices : IAbilitiesServices
    {
        private readonly TrainHoppersContext _context;
        private readonly IFileServices _fileServices;
        // private readonly IFileServices _fileServices

        public AbilitiesServices(TrainHoppersContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
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

        public async Task<Ability> Create(AbilityDto dto)
        {
            //List<Core.Domain.AbilitySideEffects> abilitySideEffects = dto.SideEffects;
            Ability ability = new();
            ability.ID = Guid.NewGuid();
            ability.AbilityXP = 0;
            ability.AbilityXPUntilNextLevel = 25;
            ability.AbilityLevel = 0;
            ability.AbilityStatus = Core.Domain.AbilityStatus.Ready;
            ability.AbilityDescription = dto.AbilityDescription;
            ability.AbilityName = dto.AbilityName;
            ability.AbilityUseTime = dto.AbilityUseTime;
            ability.AbilityRechargeTime = dto.AbilityRechargeTime;

            //ability.SideEffects = abilitySideEffects;
            ability.AbilityType = (Core.Domain.AbilityType)dto.AbilityType;
            ability.CreatedAt = DateTime.Now;
            ability.UpdatedAt = DateTime.Now;
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, ability);
            }
            await _context.Abilities.AddAsync(ability);
            await _context.SaveChangesAsync();
            return ability;

        }

        public async Task<Ability> Update(AbilityDto dto)
        {
            Ability ability = new();
            ability.ID = dto.ID;
            ability.AbilityXP = dto.AbilityXP;
            ability.AbilityXPUntilNextLevel = dto.AbilityXPUntilNextLevel;
            ability.AbilityLevel = dto.AbilityLevel;
            ability.AbilityStatus = (Core.Domain.AbilityStatus)dto.AbilityStatus;
            ability.AbilityDescription = dto.AbilityDescription;
            ability.AbilityName = dto.AbilityName;
            ability.AbilityUseTime = dto.AbilityUseTime;
            ability.AbilityRechargeTime = dto.AbilityRechargeTime;

            //ability.SideEffects = abilitySideEffects;
            ability.AbilityType = (Core.Domain.AbilityType)dto.AbilityType;
            ability.CreatedAt = dto.CreatedAt;
            ability.UpdatedAt = DateTime.Now;
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, ability);
            }
            _context.Abilities.Update(ability);
            await _context.SaveChangesAsync();
            return ability;
        }
        public async Task<Ability> Delete(Guid id)
        {
            var res = await _context.Abilities
                .FirstOrDefaultAsync(a => a.ID == id);
            _context.Abilities.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
