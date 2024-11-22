using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainHoppers.ApplicationServices.Services;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Models.Abilities;
using TrainHoppersTARpe23.Models.Powerups;
using static System.Net.Mime.MediaTypeNames;
using PowerupType = TrainHoppersTARpe23.Models.Powerups.PowerupType;

namespace TrainHoppersTARpe23.Controllers
{
    public class PowerupsController : Controller
    {
        private readonly TrainHoppersContext _context;
        private readonly IPowerupsServices _powerupServices;
        private readonly IFileServices _fileServices;
        public PowerupsController(TrainHoppersContext context, IPowerupsServices powerupsServices, IFileServices fileServices)
        {
            _context = context;
            _powerupServices = powerupsServices;
            _fileServices = fileServices;
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
                    UsesLeft = x.UsesLeft,

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
                PowerUpDescription = vm.PowerUpDescription,
                PowerupType = (TrainHoppers.Core.Domain.PowerupType)vm.PowerupType,
                UsesLeft=vm.UsesLeft,
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

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {
            var powerup = await _powerupServices.DetailsAsync(Id);
            if (powerup == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(t => t.PowerupID == Id)
                .Select(
                    y => new PowerupImageViewModel
                    {
                        PowerupID = y.ID,
                        ImageID = y.ID,
                        ImageData = y.ImageData,
                        ImageTitle = y.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                    }).ToArrayAsync();
            var vm = new PowerupCDDViewModel();
            vm.ID = powerup.ID;
            vm.PowerUpName = powerup.PowerUpName;
            vm.PowerUpDescription = powerup.PowerUpDescription;
            vm.PowerupType = (PowerupType)powerup.PowerupType;
            vm.TotalUses = powerup.TotalUses;
            vm.UsesLeft = powerup.UsesLeft;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == null) { return NotFound(); }

            var powerup = await _powerupServices.DetailsAsync(Id);

            if (powerup == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(t => t.PowerupID == Id)
                .Select(
                    y => new PowerupImageViewModel
                    {
                        PowerupID = y.ID,
                        ImageID = y.ID,
                        ImageData = y.ImageData,
                        ImageTitle = y.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                    }).ToArrayAsync();

            var vm = new PowerupCDDViewModel();
            vm.ID = powerup.ID;
            vm.PowerUpName = powerup.PowerUpName;
            vm.PowerUpDescription = powerup.PowerUpDescription;
            vm.PowerupType = (PowerupType)powerup.PowerupType;
            vm.TotalUses = powerup.TotalUses;
            vm.UsesLeft = powerup.UsesLeft;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(Guid id)
        {
            var powerup = await _powerupServices.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var powerup = await _powerupServices.DetailsAsync(Id);
            if (powerup == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(x => x.PowerupID == Id)
                .Select(
                    y => new PowerupImageViewModel
                    {
                        PowerupID = y.ID,
                        ImageID = y.ID,
                        ImageData = y.ImageData,
                        ImageTitle = y.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                    }).ToArrayAsync();
            var vm = new PowerupCDDViewModel();
            vm.ID = powerup.ID;
            vm.PowerUpName = powerup.PowerUpName;
            vm.PowerUpDescription = powerup.PowerUpDescription;
            vm.PowerupType = (PowerupType)powerup.PowerupType;
            vm.TotalUses = powerup.TotalUses;
            vm.UsesLeft = powerup.UsesLeft;
            vm.Image.AddRange(images);
            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PowerupCDDViewModel vm)
        {
            var dto = new PowerupDto()
            {
                ID = (Guid)vm.ID,
                PowerUpName = vm.PowerUpName,
                PowerUpDescription = vm.PowerUpDescription,
                PowerupType = (TrainHoppers.Core.Domain.PowerupType)vm.PowerupType,
                TotalUses = vm.TotalUses,
                UsesLeft = vm.UsesLeft,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto { ID = x.ImageID, ImageData = x.ImageData, ImageTitle = x.ImageTitle, PowerupID = x.PowerupID }).ToArray()
            };
            var result = await _powerupServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }

        [HttpPost]
        public async Task<IActionResult> removeImage(Guid ID)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = ID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
