using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Domain
{
    public enum PowerupType
    {
        Heal, PlotArmor, Ressurect, WhiteFlag, CarrotMayhem
    }
    public class Powerup
    {
        public string PowerUpName { get; set; }
        public string PowerUpDescription { get; set; }
        public int TotalUses { get; set; }
        public int UsedTime { get; set; }
        public PowerupType PowerupType { get; set; }

    }
}
