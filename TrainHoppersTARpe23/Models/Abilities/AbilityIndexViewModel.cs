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
    public class AbilityIndexViewModel
    {
        public Guid ID { get; set; }
        public int AbilityRechargeTime { get; set; }
        public int AbilityUseTime { get; set; }
        public string AbilityName { get; set; }
        public double AbilityDamage { get; set; }
        public string AbilityDescription { get; set; }
        public int LevelNeededToBeUsed { get; set; }
        public AbilityType AbilityType { get; set; }
        public List<AbilitySideEffects> SideEffects { get; set; }
    }
}
