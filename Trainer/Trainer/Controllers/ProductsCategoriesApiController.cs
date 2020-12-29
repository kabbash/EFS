using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Lookups.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Core.Models;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using System;

namespace Trainer.Controllers
{
    [Route("api/Products/Categories")]
    [ApiController]
    public class ProductsCategoriesApiController : BaseController
    {
        protected ILookupService<ProductsCategoryDto, ProductsCategories> _categoriesManager;

        private readonly IAttachmentsManager _attachmentManager;

        public ProductsCategoriesApiController(ILookupService<ProductsCategoryDto, ProductsCategories> categoriesManager, IAttachmentsManager attachmentsManager)
        {
            _categoriesManager = categoriesManager;
            _attachmentManager = attachmentsManager;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return GetStatusCodeResult(_categoriesManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return GetStatusCodeResult(_categoriesManager.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Put(int id, [FromForm] ProductsCategoryDto categoryDto)
        {
            if (categoryDto.ProfilePictureFile != null) {
                _attachmentManager.Delete(Uri.UnescapeDataString(categoryDto.ProfilePicture));
                categoryDto.ProfilePicture = _attachmentManager.Save(new SavedFileDto
                {
                attachmentType = AttachmentTypesEnum.Products_Categories,
                CanChangeName = true,
                File = categoryDto.ProfilePictureFile
                });
            }
            return GetStatusCodeResult(_categoriesManager.Update(categoryDto, id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_categoriesManager.Delete(id));
        }
    }
}
