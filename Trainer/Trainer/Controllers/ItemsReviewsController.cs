using ItemsReview.Interfaces;
using ItemsReview.Models;
using Microsoft.AspNetCore.Mvc;
using Rating.Core.Interfaces;
using Rating.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/itemsreview")]
    [ApiController]
    public class ItemsReviewsController : BaseController
    {
        private readonly IItemsReviewsManager _itemsReviewManager;
        private readonly IRatingManager<Shared.Core.Models.ItemsForReview> _ratingManager;
        public ItemsReviewsController(IItemsReviewsManager itemsReviewManager, IRatingManager<Shared.Core.Models.ItemsForReview> ratingManager)
        {
            _itemsReviewManager = itemsReviewManager;
            _ratingManager = ratingManager;
        }

        // GET: api/itemsreview
        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_itemsReviewManager.GetAll());
        }

        // GET: api/itemsreview/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_itemsReviewManager.GetById(id));
        }

        // POST: api/itemsreview
        [HttpPost]
        public ActionResult Post([FromBody] ItemReviewDto itemDto)
        {
            return GetStatusCodeResult(_itemsReviewManager.Insert(itemDto));
        }

        // PUT: api/itemsreview/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ItemReviewDto itemDto)
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
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }   
    }
}