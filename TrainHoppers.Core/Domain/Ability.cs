using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Domain
{
    public enum AbilityType
    {
        MoreDamage,MoreHealth,FasterAttackSpeed,FasterHealing,AlmostInvincible,Shield,MoreShield,MoreAttackDamage
    }
    public enum AbilitySideEffects
    {
        LessHealth,LessAttackSpeed,LessHealing,LessShield,LessAttackDamage,SlowerAttackSpeed,NoShield
    }
    public class Ability
    {
        public Guid ID { get; set; }
        public int AbilityRechargeTime { get; set; }
        public int AbilityUseTime { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
        public int AbilityLevel { get; set; }
        public AbilityType AbilityType { get; set; }
        public List<AbilitySideEffects> SideEffects { get; set; }

    }

}
