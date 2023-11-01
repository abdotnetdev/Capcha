using Capcha.Models;
using DNTCaptcha.Core;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace Capcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDNTCaptchaValidatorService _validatorService;
        public HomeController(ILogger<HomeController> logger, IDNTCaptchaValidatorService validatorService)
        {
            _logger = logger;
            _validatorService = validatorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(ErrorMessage = "Please Enter Valid Captcha")]
        public ActionResult Index1(LoginViewModel loginViewModel)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            //    return RedirectToAction("ThankYouPage");
            //}
            //if (!_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
            if (!_validatorService.HasRequestValidCaptchaEntry())
            {
                //this.ModelState.AddModelError("DNTCaptchaTagHelper.CaptchaInputName", "Please Enter Valid Captcha.");
                return View("Index");
            }
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? "" });
        }
    }
}