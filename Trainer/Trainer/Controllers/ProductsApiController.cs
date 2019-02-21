using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System;
using System.Net;
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
        public ActionResult Post([FromForm] ProductsDto productsDto)
        {
            if (String.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            productsDto.CurrentUserId = CurrentUserId;
            return GetStatusCodeResult(_productsManager.Insert(productsDto));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ProductsDto productsDto)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            productsDto.CurrentUserId = CurrentUserId;
            return GetStatusCodeResult(_productsManager.Update(productsDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_productsManager.Delete(id));
        }

        [HttpPost("addrate")]
        public ActionResult AddRate(RatingDto newRate)
        {
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

            newRate.CurrentUserId = CurrentUserId;
            newRate.EntityTypeId = (int)RatingEntityTypesEnum.Product;
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }

        #region Administration 

        [HttpGet("getforadmin")]
        public ActionResult GetForAdmin([FromQuery]ProductFilter filter)
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
        //[Authorize(Roles = "Admin")]
        public ActionResult Reject([FromBody]RejectDto model)
        {
            model.CurrentUserId = User.Identity.Name;
            return GetStatusCodeResult(_productsManager.Reject(model));
        }

        #endregion
    }
}