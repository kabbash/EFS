using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using ItemsReview.Interfaces;
using ItemsReview.Models;
using Microsoft.AspNetCore.Mvc;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Shared.Core.Utilities.Enums;
using System.Net;
using DBModels = Shared.Core.Models;

namespace Trainer.Controllers
{
    [Route("api/itemsreview")]
    [ApiController]
    public class ItemsReviewsController : BaseController
    {
        private readonly IItemsReviewsManager _itemsReviewManager;
        private readonly IRatingManager<DBModels.ItemsForReview> _ratingManager;
        private readonly IAttachmentsManager _attachmentManager;
        public ItemsReviewsController(IItemsReviewsManager itemsReviewManager, IRatingManager<DBModels.ItemsForReview> ratingManager, IAttachmentsManager attachmentsManager)
        {
            _itemsReviewManager = itemsReviewManager;
            _ratingManager = ratingManager;
            _attachmentManager = attachmentsManager;
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
            return GetStatusCodeResult(_itemsReviewManager.GetById(id,CurrentUserId));
        }

        // POST: api/itemsreview
        [HttpPost]
        public ActionResult Post([FromForm] ItemReviewDto itemDto)
        {
            itemDto.ProfilePicture = _attachmentManager.Save(new SavedFileDto
            {
                attachmentType = AttachmentTypesEnum.Products,
                CanChangeName = true,
                File = itemDto.ProfilePictureFile
            });
            return GetStatusCodeResult(_itemsReviewManager.Insert(itemDto));
        }

        // PUT: api/itemsreview/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ItemReviewDto itemDto)
        {
            if (itemDto.ProfilePictureFile != null)
            {
                itemDto.ProfilePicture = _attachmentManager.Save(new SavedFileDto
                {
                    attachmentType = AttachmentTypesEnum.Products,
                    CanChangeName = true,
                    File = itemDto.ProfilePictureFile
                });
            }
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
            if (string.IsNullOrEmpty(CurrentUserId))
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }
            newRate.CurrentUserId = CurrentUserId;
            newRate.EntityTypeId = (int)RatingEntityTypesEnum.ItemsForReview;
            return GetStatusCodeResult(_ratingManager.AddOrUpdate(newRate));
        }   
    }
}