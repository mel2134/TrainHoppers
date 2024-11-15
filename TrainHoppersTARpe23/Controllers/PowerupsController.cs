using Microsoft.AspNetCore.Mvc;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Models.Abilities;
using TrainHoppersTARpe23.Models.Powerups;

namespace TrainHoppersTARpe23.Controllers
{
    public class PowerupsController : Controller
    {
        private readonly TrainHoppersContext _context;
        private readonly IPowerupsServices _powerupServices;
        public PowerupsController(TrainHoppersContext context,IPowerupsServices powerupsServices)
        {
            _context = context;
            _powerupServices = powerupsServices;
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
        [HttpGet]
        public IActionResult Create()
        {
            PowerupCDDViewModel vm = new();
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PowerupCDDViewModel vm)
        {
            var dto = new PowerupDto()
            {
                PowerUpName = vm.PowerUpName,
                PowerUpDescription= vm.PowerUpDescription,
                PowerupType= (TrainHoppers.Core.Domain.PowerupType)vm.PowerupType,
                // SideEffects = abilitySideEffects,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(
                    x => new FileToDatabaseDto { ID = x.ImageID, ImageTitle = x.ImageTitle, ImageData = x.ImageData, PowerupID = x.PowerupID }
                    ),

            };
            var result = await _powerupServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
