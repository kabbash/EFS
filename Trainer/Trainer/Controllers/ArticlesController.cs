using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Articles.Core.Interfaces;
using Articles.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        // GET: api/ProductsCategories
        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_articlesService.GetAll());
        }

        // GET: api/ProductsCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(byte id)
        {
            return GetStatusCodeResult(_articlesService.GetById(id));
        }

        // POST: api/ProductsCategories
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

        // PUT: api/ProductsCategories/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Put(byte id, [FromBody] ArticleAddDto articleDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }
            return GetStatusCodeResult(_articlesService.Update(articleDto, id, userIdClaim.Value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, ArticleWriter")]

        public ActionResult Delete(byte id)
        {
            return GetStatusCodeResult(_articlesService.Delete(id));
        }
    }
}