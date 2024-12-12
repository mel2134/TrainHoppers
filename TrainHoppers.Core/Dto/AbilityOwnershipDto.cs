using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Dto
{
    public class AbilityOwnershipDto : AbilityDto
    {
        public Guid OwnershipID { get; set; }
        public int AbilityLevel { get; set; }
        public int AbilityXP { get; set; }
        public int AbilityXPUntilNextLevel { get; set; }
        public AbilityType AbilityType { get; set; }
        public int AbilityRechargeTime { get; set; }
        public int AbilityUseTime { get; set; }
        public AbilityStatus AbilityStatus { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        //db
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
