using Home.Core.Interfaces;
using Home.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Trainer.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeApiController : BaseController
    {
        private readonly IHomeService _homeService;
        public HomeApiController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpPost]
        [Route("contactus")]
        public ActionResult ContactUs([FromBody]ContactUsDto contactUsDto)
        {
            return GetStatusCodeResult(_homeService.ContactUs(contactUsDto));
        }
    }
}