using Articles.Core.Interfaces;
using Articles.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;

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
        [Authorize(Roles = "Admin")]
        public ActionResult GetForAdmin([FromQuery]ArticlesFilter filter)
        {
            return GetStatusCodeResult(_articlesService.GetAll(filter));
        }

        [HttpGet("getforwriters")]
        [Authorize(Roles = "ArticleWriter")]
        public ActionResult GetForWriters([FromQuery]ArticlesFilter filter)
        {
            filter.CreatedBy = GetCurrentUser().Id;
            return GetStatusCodeResult(_articlesService.GetAll(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_articlesService.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Post([FromForm] ArticleAddDto articleDto)
        {
            return GetStatusCodeResult(_articlesService.Insert(articleDto, GetCurrentUser()));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Put(int id, [FromForm] ArticleAddDto articleDto)
        {
            return GetStatusCodeResult(_articlesService.Update(articleDto, id, GetCurrentUser()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_articlesService.Delete(id, GetCurrentUser()));
        }

        [HttpPost]
        [Route("Approve")]
        [Authorize(Roles = "Admin")]
        public ActionResult Approve([FromBody]baseDto model)
        {
            return GetStatusCodeResult(_articlesService.Approve(model.Id));
        }

        [HttpPost]
        [Route("Reject")]
        [Authorize(Roles = "Admin")]
        public ActionResult Reject([FromBody]RejectDto model)
        {
            return GetStatusCodeResult(_articlesService.Reject(model, GetCurrentUser()));
        }
    }
}