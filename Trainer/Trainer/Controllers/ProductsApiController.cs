using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System.Linq;
using System.Security.Claims;
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
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }

            // Set User 
            productsDto.CreatedBy = userIdClaim.Value;

            return GetStatusCodeResult(_productsManager.Insert(productsDto));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ProductsDto productsDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                return StatusCode(500);
            }

            //Set User
            productsDto.UpdatedBy = userIdClaim.Value;

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
            model.UserId = User.Identity.Name;
            return GetStatusCodeResult(_productsManager.Reject(model));
        }

        #endregion
    }
}