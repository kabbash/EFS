using ItemsReview.Interfaces;
using ItemsReview.Models;
using Microsoft.AspNetCore.Mvc;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;
using DBModels = Shared.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/itemsreview")]
    [ApiController]
    public class ItemsReviewsController : BaseController
    {
        private readonly IItemsReviewsManager _itemsReviewManager;
        private readonly IRatingManager<DBModels.ItemsForReview> _ratingManager;
        public ItemsReviewsController(IItemsReviewsManager itemsReviewManager, IRatingManager<DBModels.ItemsForReview> ratingManager)
        {
            _itemsReviewManager = itemsReviewManager;
            _ratingManager = ratingManager;
        }

        // GET: api/itemsreview
        [HttpGet]
        public ActionResult Get([FromQuery]ItemsReviewFilter itemsReviewFilter)
        {
            return GetStatusCodeResult(_itemsReviewManager.GetAll(itemsReviewFilter));
        }

        // GET: api/itemsreview/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_itemsReviewManager.GetById(id,GetCurrentUser().Id));
        }

        // POST: api/itemsreview
        [HttpPost]
        public ActionResult Post([FromForm] ItemReviewDto itemDto)
        {
            return GetStatusCodeResult(_itemsReviewManager.Insert(itemDto));
        }

        // PUT: api/itemsreview/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ItemReviewDto itemDto)
        {
            return GetStatusCodeResult(_itemsReviewManager.Update(itemDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_itemsReviewManager.Delete(id));
        }

        [HttpPost("AddRate")]
        public ActionResult AddRate(RatingDto newRate)
        {
            newRate.CurrentUserId = GetCurrentUser().Id;
            newRate.EntityTypeId = (int)RatingEntityTypesEnum.ItemsForReview;
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }   
    }
}