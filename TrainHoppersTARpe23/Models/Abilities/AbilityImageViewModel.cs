namespace TrainHoppersTARpe23.Models.Abilities
{
    public class AbilityImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; }
        public Guid? AbilityID { get; set; }
    }
}
