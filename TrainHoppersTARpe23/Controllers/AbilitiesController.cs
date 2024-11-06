using Microsoft.AspNetCore.Mvc;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Models.Abilities;

namespace TrainHoppersTARpe23.Controllers
{
    public class AbilitiesController : Controller
    {
        private readonly TrainHoppersContext _context;
        private readonly IAbilitiesServices _abilitiesServices;
        public AbilitiesController(TrainHoppersContext context, IAbilitiesServices abilitiesServices)
        {
            _context = context;
            _abilitiesServices = abilitiesServices;
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
                    AbilityRechargeTime = x.AbilityRechargeTime,
                });
            return View();
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
                //SideEffects = vm.SideEffects,
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
    }
}
