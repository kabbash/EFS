using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banner.Core.Interfaces;
using Banner.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trainer.Controllers
{
    [Route("api/Banners")]
    [ApiController]
    public class BannerController : BaseController
    {
        private readonly IBannerManager _bannerManager;
        public BannerController(IBannerManager bannerManager)
        {
            _bannerManager = bannerManager;
        }
        [HttpGet]
        public ActionResult Get(int pageNo= 1 , int pageSize = 10)
        {
            return GetStatusCodeResult(_bannerManager.Get(pageNo, pageSize));
        }

        [HttpGet("{id}")]

        public ActionResult GetById(int id)
        {
            return GetStatusCodeResult(_bannerManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromForm] BannerDto banner)
        {
            return GetStatusCodeResult(_bannerManager.Add(banner));
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromForm] BannerDto banner , int id)
        {
            return GetStatusCodeResult(_bannerManager.Update(banner, id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_bannerManager.Delete(id));
        }
    }
}