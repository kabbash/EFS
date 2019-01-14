using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Models;

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
        public ActionResult GetActiveItems(int PageNo = 1, int PageSize = 10)
        {
            var filter = new ProductFilter
            {
                PageNo = PageNo,
                PageSize = PageSize,
                Status = ProductStatusEnum.Active
            };
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }

        [HttpGet("GetSpecialItems")]
        public ActionResult GetSpecialItems(int PageNo = 1, int PageSize = 10)
        {
            var filter = new ProductFilter
            {
                IsSpecial = true,
                Status = ProductStatusEnum.Active,
                PageNo = PageNo,
                PageSize = PageSize
            };
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }

        [HttpGet]
        public ActionResult Get(int PageNo = 1, int PageSize = 10)
        {
            var filter = new ProductFilter
            {
                PageNo = PageNo,
                PageSize = PageSize
            };

            return GetStatusCodeResult(_productsManager.GetAll(filter));
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

        #region Administration 

        [HttpGet("getFilteredData")]
        public ActionResult getFilteredData([FromQuery]ProductFilter filter)
        {
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }

        [HttpPost]
        [Route("Approve")]
        public ActionResult Approve([FromBody]baseDto model)
        {

            return GetStatusCodeResult(_productsManager.Approve(model.Id));
        }

        [HttpPost]
        [Route("Reject")]
        public ActionResult Reject([FromBody]baseDto model)
        {
            return GetStatusCodeResult(_productsManager.Delete(model.Id));
        }

        #endregion
    }
}