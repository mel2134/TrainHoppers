using Microsoft.AspNetCore.Mvc;
using TrainHoppers.Data;

namespace TrainHoppersTARpe23.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly TrainHoppersContext _context;
        public PlayerProfilesController(TrainHoppersContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_context.PlayerProfiles.OrderByDescending(x=> x.ScreenName));
        }
        //[HttpGet]
        //public async Task<> Stories()
    }
}
