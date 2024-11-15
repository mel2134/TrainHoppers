using Microsoft.AspNetCore.Mvc;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Models.Powerups;

namespace TrainHoppersTARpe23.Controllers
{
    public class PowerupsController : Controller
    {
        private readonly TrainHoppersContext _context;
        public PowerupsController(TrainHoppersContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Powerups.OrderByDescending(y => y.PowerUpName)
                .Select(x => new PowerupIndexViewModel
                {
                    ID = x.ID,
                    PowerUpName = x.PowerUpName,
                    PowerupType = (PowerupType)x.PowerupType,
                    PowerUpDescription = x.PowerUpDescription,

                });
            return View(resultingInventory);
        }
    }
}
