using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainHoppers.Core.Domain;

namespace TrainHoppers.Core.Dto
{
    public class PowerupDto
    {
        public Guid? ID { get; set; }
        public string PowerUpName { get; set; }
        public string PowerUpDescription { get; set; }
        public int TotalUses { get; set; }
        public int UsedTime { get; set; }
        public PowerupType PowerupType { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
