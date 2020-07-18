using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using DBModels = Shared.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsApiController : BaseController
    {
        private readonly IProductsManager _productsManager;
        private readonly IRatingManager<DBModels.Products> _ratingManager;

        public ProductsApiController(IProductsManager productsManager, IRatingManager<DBModels.Products> ratingManager)
        {
            _productsManager = productsManager;
            _ratingManager = ratingManager;
        }

        [HttpGet]
        public ActionResult Get([FromQuery]ProductFilter filter)
        {
            filter.Status = StatusFilterEnum.Active;
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_productsManager.GetById(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromForm] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Insert(productsDto, GetCurrentUser()));
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Put(int id, [FromForm] ProductsDto productsDto)
        {
            return GetStatusCodeResult(_productsManager.Update(productsDto, id, GetCurrentUser()));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_productsManager.Delete(id,GetCurrentUser()));
        }

        [HttpPost("addrate")]
        public ActionResult AddRate(RatingDto newRate)
        {
            newRate.CurrentUserId = GetCurrentUser().Id;
            newRate.EntityTypeId = (int)RatingEntityTypesEnum.Product;
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }

        #region Administration 

        [HttpGet("getforadmin")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetForAdmin([FromQuery]ProductFilter filter)
        {
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }

        [HttpGet("getforowners")]
        [Authorize]
        public ActionResult GetForOwners([FromQuery]ProductFilter filter)
        {
            filter.CreatedBy = GetCurrentUser().Id;
            return GetStatusCodeResult(_productsManager.GetAll(filter));
        }


        [HttpPost]
        [Route("Approve")]
        [Authorize(Roles = "Admin")]
        public ActionResult Approve([FromBody]baseDto model)
        {

            return GetStatusCodeResult(_productsManager.Approve(model.Id));
        }

        [HttpPost]
        [Route("Reject")]
        [Authorize(Roles = "Admin")]
        public ActionResult Reject([FromBody]RejectDto model)
        {
            return GetStatusCodeResult(_productsManager.Reject(model,GetCurrentUser()));
        }

        #endregion
    }
}