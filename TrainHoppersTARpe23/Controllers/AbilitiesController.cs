using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Models.Abilities;
using TrainHoppersTARpe23.Models.Stories;

namespace TrainHoppersTARpe23.Controllers
{
    public class AbilitiesController : Controller
    {
        private readonly TrainHoppersContext _context;
        private readonly IAbilitiesServices _abilitiesServices;
        private readonly IFileServices _fileServices;
        public AbilitiesController(TrainHoppersContext context, IAbilitiesServices abilitiesServices,IFileServices fileServices)
        {
            _context = context;
            _abilitiesServices = abilitiesServices;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Abilities.OrderByDescending(y => y.AbilityLevel)
                .Select(x => new AbilityIndexViewModel
                {
                    ID = x.ID,
                    AbilityName = x.AbilityName,
                    AbilityType = (Models.Abilities.AbilityType)x.AbilityType,
                    AbilityLevel = x.AbilityLevel,
                    AbilityStatus = (Models.Abilities.AbilityStatus)x.AbilityStatus,
                });
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            AbilityCreateViewModel vm = new();
            return View("Create",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AbilityCreateViewModel vm)
        {
            //List<TrainHoppers.Core.Dto.AbilitySideEffects> abilitySideEffects = new List<TrainHoppers.Core.Dto.AbilitySideEffects>() { TrainHoppers.Core.Dto.AbilitySideEffects.LessShield,TrainHoppers.Core.Dto.AbilitySideEffects.SlowerAttackSpeed};
            var dto = new AbilityDto()
            {
                AbilityName = vm.AbilityName,
                AbilityDescription = vm.AbilityDescription,
                AbilityXP = 0,
                AbilityXPUntilNextLevel = 25,
                AbilityLevel = 0,
                AbilityRechargeTime = vm.AbilityRechargeTime,
                AbilityUseTime = vm.AbilityUseTime,
                AbilityStatus = (TrainHoppers.Core.Dto.AbilityStatus)vm.AbilityStatus,
                AbilityType = (TrainHoppers.Core.Dto.AbilityType)vm.AbilityType,
               // SideEffects = abilitySideEffects,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto { ID = x.ImageID,ImageData = x.ImageData, ImageTitle = x.ImageTitle,AbilityID = x.AbilityID}).ToArray()

            };
            var result = await _abilitiesServices.Create(dto);
            if(result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid Id/*Guid ref*/)
        {
            var ability = await _abilitiesServices.DetailsAsync(Id);
            if (ability == null)
            {
                return NotFound(); // Custom partial view
            }
            var images = await _context.FilesToDatabase
                .Where(t => t.AbilityID == Id)
                .Select(
                    y => new AbilityImageViewModel
                    {
                        AbilityID = y.ID,
                        ImageID = y.ID,
                        ImageData = y.ImageData,
                        ImageTitle = y.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}",Convert.ToBase64String(y.ImageData))
                    }).ToArrayAsync();
            var vm = new AbilityDetailsViewModel();
            vm.ID = ability.ID;
            vm.AbilityName = ability.AbilityName;
            vm.AbilityDescription = ability.AbilityDescription;
            vm.AbilityRechargeTime = ability.AbilityRechargeTime;
            vm.AbilityUseTime = ability.AbilityUseTime;
            vm.AbilityStatus = (Models.Abilities.AbilityStatus)ability.AbilityStatus;
            vm.AbilityLevel = ability.AbilityLevel;
            vm.AbilityXP = ability.AbilityXP;
            vm.AbilityXPUntilNextLevel = ability.AbilityXPUntilNextLevel;
            vm.AbilityType = (Models.Abilities.AbilityType)ability.AbilityType;
            vm.Image.AddRange(images);
            return View(vm);
        }
        public async Task<IActionResult> Update(Guid Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var ability = await _abilitiesServices.DetailsAsync(Id);
            if (ability == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(x => x.AbilityID == Id)
                .Select(
                    y => new AbilityImageViewModel
                    {
                        AbilityID = y.ID,
                        ImageID = y.ID,
                        ImageData = y.ImageData,
                        ImageTitle = y.ImageTitle,
                        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                    }).ToArrayAsync();
            var vm = new AbilityCreateViewModel();
            vm.ID = ability.ID;
            vm.AbilityName = ability.AbilityName;
            vm.AbilityDescription = ability.AbilityDescription;
            vm.AbilityRechargeTime = ability.AbilityRechargeTime;
            vm.AbilityUseTime = ability.AbilityUseTime;
            vm.AbilityStatus = (Models.Abilities.AbilityStatus)ability.AbilityStatus;
            vm.AbilityLevel = ability.AbilityLevel;
            vm.AbilityXP = ability.AbilityXP;
            vm.AbilityXPUntilNextLevel = ability.AbilityXPUntilNextLevel;
            vm.AbilityType = (Models.Abilities.AbilityType)ability.AbilityType;
            vm.CreatedAt = ability.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);
            return View("Update",vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AbilityCreateViewModel vm)
        {
            var dto = new AbilityDto()
            {
                ID = (Guid)vm.ID,
                AbilityName = vm.AbilityName,
                AbilityDescription = vm.AbilityDescription,
                AbilityXP = 0,
                AbilityXPUntilNextLevel = 25,
                AbilityLevel = 0,
                AbilityRechargeTime = vm.AbilityRechargeTime,
                AbilityUseTime = vm.AbilityUseTime,
                AbilityStatus = (TrainHoppers.Core.Dto.AbilityStatus)vm.AbilityStatus,
                AbilityType = (TrainHoppers.Core.Dto.AbilityType)vm.AbilityType,
                // SideEffects = abilitySideEffects,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto { ID = x.ImageID, ImageData = x.ImageData, ImageTitle = x.ImageTitle, AbilityID = x.AbilityID }).ToArray()
            };
            var result = await _abilitiesServices.Update(dto);
            if(result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var ability = await _abilitiesServices.DetailsAsync(ID);
            if (ability == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(x => x.ID == ID)
                .Select(y => new AbilityImageViewModel
                {
                    AbilityID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}",Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new AbilityDeleteViewModel();
            vm.ID = ability.ID;
            vm.AbilityName = ability.AbilityName;
            vm.AbilityDescription = ability.AbilityDescription;
            vm.AbilityRechargeTime = ability.AbilityRechargeTime;
            vm.AbilityUseTime = ability.AbilityUseTime;
            vm.AbilityStatus = (Models.Abilities.AbilityStatus)ability.AbilityStatus;
            vm.AbilityLevel = ability.AbilityLevel;
            vm.AbilityXP = ability.AbilityXP;
            vm.AbilityXPUntilNextLevel = ability.AbilityXPUntilNextLevel;
            vm.AbilityType = (Models.Abilities.AbilityType)ability.AbilityType;
            vm.CreatedAt = ability.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(Guid ID)
        {
            var ability = await _abilitiesServices.Delete(ID);
            if (ability == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRandomAbilityOwnership(AbilityOwnershipFromStoryViewModel vm)
        {
            int rng = new Random().Next(1, _context.Abilities.Count());



            var source =  _context.Abilities.OrderByDescending(x=>x.AbilityName).Take(rng);
            
            var dto = new AbilityOwnershipDto()
            {
                AbilityName = vm.AddedAbility.AbilityName,
                AbilityDescription = vm.AddedAbility.AbilityDescription,
                AbilityXP = 0,
                AbilityXPUntilNextLevel = 25,
                AbilityLevel = 0,
                AbilityRechargeTime = vm.AddedAbility.AbilityRechargeTime,
                AbilityUseTime = vm.AddedAbility.AbilityUseTime,
                AbilityStatus = (TrainHoppers.Core.Dto.AbilityStatus)vm.AddedAbility.AbilityStatus,
                AbilityType = (TrainHoppers.Core.Dto.AbilityType)vm.AddedAbility.AbilityType,
                // SideEffects = abilitySideEffects,
                OwnershipCreatedAt = DateTime.Now,
                OwnershipUpdatedAt = DateTime.Now,
                Files = vm.AddedAbility.Files,
                Image = vm.AddedAbility.Image.Select(x => new FileToDatabaseDto { ID = x.ID, ImageData = x.ImageData, ImageTitle = x.ImageTitle, AbilityID = x.AbilityID }).ToArray()

            };
            //var result = await _storiesServices.Create(dto);
            // STUB needs stories services, a story to utilize, storiescontroller to function
            //var result = null;

            if (null == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }

    }
}
