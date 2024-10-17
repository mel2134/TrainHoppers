using Microsoft.AspNetCore.Mvc;
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
                    AbilityType = (AbilityType)x.AbilityType,
                    AbilityLevel = x.AbilityLevel,
                    AbilityRechargeTime = x.AbilityRechargeTime,
                });
            return View();
        }
    }
}
