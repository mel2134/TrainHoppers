namespace TrainHoppersTARpe23.Models.Powerups
{
    public class PowerupImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? PowerupID { get; set; }
    }
}
