using Articles.Core.Interfaces;
using Articles.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Utilities.Models;
using System.Linq;
using System.Security.Claims;

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
            return GetStatusCodeResult(_articlesService.GetAll(filter.PageNo, filter.PageSize));
        }

        [HttpGet("getFilteredData")]        
        public ActionResult getFilteredData([FromQuery]ArticlesFilter filter)
        {
            return GetStatusCodeResult(_articlesService.GetFilteredData(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_articlesService.GetById(id));
        }

        [HttpGet("GetByCategory/{id}")]
        public ActionResult GetByCategory(int id,int pageNo=1, int pageSize=10)
        {
            return GetStatusCodeResult(_articlesService.GetByCategoryId(id,pageNo, pageSize));
        }

        [HttpGet("GetByCategoryKey/{id}")]
        public ActionResult GetByPredefinedCategoryKey(int id, int pageNo=1, int pageSize=10)
        {
            return GetStatusCodeResult(_articlesService.GetByPredefinedCategoryKey(id, pageNo, pageSize));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Post([FromForm] ArticleAddDto articleDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }

            // Set User 
            articleDto.UserId = userIdClaim.Value;
            return GetStatusCodeResult(_articlesService.Insert(articleDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Put(int id, [FromForm] ArticleAddDto articleDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }

            //Set User
            articleDto.UserId = userIdClaim.Value;

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
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }
            //Set User
            model.UserId = userIdClaim.Value;
            return GetStatusCodeResult(_articlesService.Reject(model));
        }
    }
}