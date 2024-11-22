using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Domain
{
    public enum PowerupType
    {
        Heal, PlotArmor, Ressurect, WhiteFlag, CarrotMayhem, Smoke, BunnyHop, Airstrike, InstantReload
    }
    public class Powerup
    {
        public Guid ID { get; set; }
        public string PowerUpName { get; set; }
        public string PowerUpDescription { get; set; }
        public int TotalUses { get; set; }
        public int UsesLeft { get; set; }
        public PowerupType PowerupType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
