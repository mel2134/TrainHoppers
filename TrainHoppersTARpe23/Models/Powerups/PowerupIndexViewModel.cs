namespace TrainHoppersTARpe23.Models.Powerups
{
    public enum PowerupType
    {
        Heal, PlotArmor, Ressurect, WhiteFlag, CarrotMayhem
    }
    public class PowerupIndexViewModel
    {
        public Guid ID { get; set; }
        public string PowerUpName { get; set; }
        public string PowerUpDescription { get; set; }
        public int TotalUses { get; set; }
        public int UsedTime { get; set; }
        public PowerupType PowerupType { get; set; }
    }
}
