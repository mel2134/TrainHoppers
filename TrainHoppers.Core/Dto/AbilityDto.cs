﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainHoppers.Core.Dto
{
    public enum AbilityType
    {
        MoreDamage, MoreHealth, FasterAttackSpeed, FasterHealing, Invincible, Shield, MoreShield, MoreAttackDamage
    }
    public enum AbilitySideEffects
    {
        LessHealth, LessAttackSpeed, LessHealing, LessShield, LessAttackDamage, SlowerAttackSpeed, NoShield
    }
    public class AbilityDto
    {
        public Guid ID { get; set; }
        public int AbilityRechargeTime { get; set; }
        public int AbilityUseTime { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
        public int AbilityLevel { get; set; }
        public AbilityType AbilityType { get; set; }
        public List<AbilitySideEffects> SideEffects { get; set; }

        /*
        public List<IFormFile> Files {get; set;}
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
        */

    }
}