namespace TrainHoppersTARpe23.Models.Abilities
{
    public enum AbilityType
    {
        MoreDamage, MoreHealth, FasterAttackSpeed, FasterHealing, Invincible, Shield, MoreShield, MoreAttackDamage
    }
    public enum AbilitySideEffects
    {
        LessHealth, LessAttackSpeed, LessHealing, LessShield, LessAttackDamage, SlowerAttackSpeed, NoShield
    }
    public enum AbilityStatus
    {
        Charging, Ready
    }
    public class AbilityIndexViewModel
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
        //public List<AbilitySideEffects> SideEffects { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
