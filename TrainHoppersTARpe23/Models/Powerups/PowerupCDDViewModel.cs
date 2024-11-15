using TrainHoppersTARpe23.Models.Powerups;

namespace TrainHoppersTARpe23.Models.Powerups
{
    public class PowerupCDDViewModel
    {
        public Guid? ID { get; set; }
        public string PowerUpName { get; set; }
        public string PowerUpDescription { get; set; }
        public int TotalUses { get; set; }
        public int UsedTime { get; set; }
        public PowerupType PowerupType { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<PowerupImageViewModel> Image { get; set; } = new List<PowerupImageViewModel>();


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
