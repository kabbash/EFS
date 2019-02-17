using Articles.Core.Interfaces;
using Articles.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System.Net;

namespace Trainer.Controllers
{
    [Route("api/Articles")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        private readonly IArticlesService _articlesService;
        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]ArticlesFilter filter)
        {
            filter.Status = (int)(StatusFilterEnum.Active);
            return GetStatusCodeResult(_articlesService.GetAll(filter));
        }

        [HttpGet("getforadmin")]
        //[Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult GetForAdmin([FromQuery]ArticlesFilter filter)
        {
            return GetStatusCodeResult(_articlesService.GetAll(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_articlesService.GetById(id));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Post([FromForm] ArticleAddDto articleDto)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }
            articleDto.CurrentUserId = CurrentUserId;
            return GetStatusCodeResult(_articlesService.Insert(articleDto));
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Put(int id, [FromForm] ArticleAddDto articleDto)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }
            articleDto.CurrentUserId = CurrentUserId;
            return GetStatusCodeResult(_articlesService.Update(articleDto, id));
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_articlesService.Delete(id));
        }

        [HttpPost]
        [Route("Approve")]
        public ActionResult Approve([FromBody]baseDto model)
        {

            return GetStatusCodeResult(_articlesService.Approve(model.Id));
        }

        [HttpPost]
        [Route("Reject")]
        public ActionResult Reject([FromBody]RejectDto model)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }
            model.CurrentUserId = CurrentUserId;
            return GetStatusCodeResult(_articlesService.Reject(model));
        }
    }
}