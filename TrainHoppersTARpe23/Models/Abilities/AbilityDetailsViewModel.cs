﻿using TrainHoppers.Core.Dto;

namespace TrainHoppersTARpe23.Models.Abilities
{
    public class AbilityDetailsViewModel
    {
        public Guid ID { get; set; }
        public int AbilityRechargeTime { get; set; }
        public int AbilityUseTime { get; set; }
        public AbilityStatus AbilityStatus { get; set; }
        public string AbilityName { get; set; }
        public string AbilityDescription { get; set; }
        public int AbilityLevel { get; set; }
        public int AbilityXP { get; set; }
        public int AbilityXPUntilNextLevel { get; set; }
        public AbilityType AbilityType { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<AbilityImageViewModel> Image { get; set; } = new List<AbilityImageViewModel>();
    }
}