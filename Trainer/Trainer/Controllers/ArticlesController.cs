using Articles.Core.Interfaces;
using Articles.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Get(int pageNo = 1,int pageSize=10)
        {
            return GetStatusCodeResult(_articlesService.GetAll(pageNo,pageSize));
        }

        [HttpGet("GetActiveItems")]
        public ActionResult GetActiveItems(int pageNo = 1, int pageSize = 10)
        {
            var filter = new ArticlesFilter
            {
                IsActive = true
            };
            return GetStatusCodeResult(_articlesService.GetAll(pageNo , pageSize , filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_articlesService.GetById(id));
        }

        [HttpGet("GetByCategory/{id}")]
        public ActionResult GetByCategory(int id)
        {
            return GetStatusCodeResult(_articlesService.GetByCategoryId(id));
        }

        [HttpGet("GetByCategoryKey/{id}")]
        public ActionResult GetByPredefinedCategoryKey(int id)
        {
            return GetStatusCodeResult(_articlesService.GetByPredefinedCategoryKey(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, ArticleWriter")]
        public ActionResult Post([FromBody] ArticleAddDto articleDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }
            return GetStatusCodeResult(_articlesService.Insert(articleDto, userIdClaim.Value));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Put(int id, [FromBody] ArticleAddDto articleDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }
            return GetStatusCodeResult(_articlesService.Update(articleDto, id, userIdClaim.Value));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_articlesService.Delete(id));
        }
    }
}