using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Rating.Core.Interfaces;
using Rating.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsApiController : BaseController
    {
        private readonly IProductsManager _productsManager;
        private readonly IRatingManager<Shared.Core.Models.Products> _ratingManager;
        public ProductsApiController(IProductsManager productsManager, IRatingManager<Shared.Core.Models.Products> ratingManager)
        {
            _productsManager = productsManager;
            _ratingManager = ratingManager;
        }

        [HttpGet("GetActiveItems")]
        public ActionResult GetActiveItems(int PageNo=1 , int PageSize=10)
        {
            var filter = new ProductFilter
            {
                IsActive = true
            };
            return GetStatusCodeResult(_productsManager.GetAll(PageNo,PageSize,filter));
        }

        [HttpGet("GetSpecialItems")]
        public ActionResult GetSpecialItems(int PageNo = 1, int PageSize = 10)
        {
            var filter = new ProductFilter
            {
                IsSpecial = true,
                IsActive =true
            };
            return GetStatusCodeResult(_productsManager.GetAll(PageNo, PageSize,filter));
        }

        [HttpGet]
        public ActionResult Get(int PageNo = 1, int PageSize = 10)
        {
            return GetStatusCodeResult(_productsManager.GetAll(PageNo, PageSize));
        }

        [HttpGet("Category/{id}")]
        public ActionResult GetByCategory(int id)
        {
            return GetStatusCodeResult(_productsManager.GetByCategoryId(id));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_productsManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Insert(productsDto));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Update(productsDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_productsManager.Delete(id));
        }

        [HttpPost("AddRate")]
        public ActionResult AddRate(RatingDto newRate)
        {
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }
    }
}