using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core.Utilities.Enums;

namespace Trainer.Controllers
{
    [Route("api/Products/Categories")]
    [ApiController]
    public class ProductsCategoriesApiController : BaseController
    {
        private readonly IProductsCategoriesManager _categoriesManager;
        private readonly IAttachmentsManager _attachmentManager;

        public ProductsCategoriesApiController(IProductsCategoriesManager categoriesManager, IAttachmentsManager attachmentsManager)
        {
            _categoriesManager = categoriesManager;
            _attachmentManager = attachmentsManager;
        }

        // GET: api/ProductsCategories
        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_categoriesManager.GetAll());
        }


        [HttpGet("getLeafCategories")]
        public ActionResult GetLeafCategories()
        {
            return GetStatusCodeResult(_categoriesManager.GetLeafCategories());
        }
        // GET: api/ProductsCategories/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_categoriesManager.GetById(id));
        }

        // POST: api/ProductsCategories
        [HttpPost]
        public ActionResult Post([FromForm] ProductsCategoryDto categoryDto)
        {
            categoryDto.ProfilePicture = _attachmentManager.Save(new SavedFileDto
            {
                attachmentType = AttachmentTypesEnum.Products_Categories,
                CanChangeName = true,
                File = categoryDto.ProfilePictureFile
            });

            return GetStatusCodeResult(_categoriesManager.Insert(categoryDto));
        }

        // PUT: api/ProductsCategories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ProductsCategoryDto categoryDto)
        {
            if (categoryDto.ProfilePictureFile != null) {
                categoryDto.ProfilePicture = _attachmentManager.Save(new SavedFileDto
                {
                attachmentType = AttachmentTypesEnum.Products_Categories,
                CanChangeName = true,
                File = categoryDto.ProfilePictureFile
                });
            }
            return GetStatusCodeResult(_categoriesManager.Update(categoryDto, id));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_categoriesManager.Delete(id));
        }
    }
}
