using Articles.Core.Models;
using Lookups.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Models;
using Shared.Core.Utilities;

namespace Trainer.Controllers
{
    [Route("api/Articles/Categories")]
    [ApiController]
    public class ArticlesCategoriesController : BaseController
    {
        protected ILookupService<ArticlesCategoriesDto, ArticlesCategories> _Manager;
        public ArticlesCategoriesController(ILookupService<ArticlesCategoriesDto, ArticlesCategories> manager)
        {
            _Manager = manager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<ResultMessage> Get()
        {
            return GetStatusCodeResult(_Manager.GetAll());
        }
        [HttpPost]
        public ActionResult Post([FromBody] ArticlesCategoriesDto calories)
        {
            var success = _Manager.Insert(calories);
            return Ok(success);
        }

        // GET api/calories/5
        [HttpGet("{id}")]
        public ActionResult<ResultMessage> Get(byte id)
        {

            return GetStatusCodeResult(_Manager.GetById(id));
        }


        // PUT api/calories/5
        [HttpPut("{id}")]
        public ActionResult<ResultMessage> Put(int id, [FromBody] ArticlesCategoriesDto value)
        {
            return GetStatusCodeResult(_Manager.Update(value, id));
        }

        // DELETE api/calories/5
        [HttpDelete("{id}")]
        public ActionResult Delete(byte id)
        {
            return GetStatusCodeResult(_Manager.Delete(id));
        }

    }

}