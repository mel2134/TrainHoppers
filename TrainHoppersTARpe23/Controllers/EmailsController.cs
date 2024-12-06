using Microsoft.AspNetCore.Mvc;
using TrainHoppers.Core.Dto;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppersTARpe23.Models.Emails;

namespace TrainHoppersTARpe23.Controllers
{
    public class EmailsController : Controller
    {
        public readonly IEmailsServices _emailsServices;

        public EmailsController(IEmailsServices emailServices)
        {
            _emailsServices = emailServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel model)
        {
            var dto = new EmailDto()
            {
                To = model.To,
                Subject = model.Subject,
                Body = model.Body,
            };
            _emailsServices.SendEmail(dto);
            return RedirectToAction("Index");
        }
    }
}
