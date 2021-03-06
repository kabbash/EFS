﻿using Articles.Core.Models;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Lookups.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System;

namespace Trainer.Controllers
{
    [Route("api/Articles/Categories")]
    [ApiController]
    public class ArticlesCategoriesController : BaseController
    {
        protected ILookupService<ArticlesCategoriesDto, ArticlesCategories> _Manager;
        private readonly IAttachmentsManager _attachmentManager;

        public ArticlesCategoriesController(ILookupService<ArticlesCategoriesDto, ArticlesCategories> manager, IAttachmentsManager attachmentsManager)
        {
            _Manager = manager;
            _attachmentManager = attachmentsManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<ResultMessage> Get()
        {
            return GetStatusCodeResult(_Manager.GetAll());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Post([FromForm] ArticlesCategoriesDto category)
        {
            category.ProfilePicture = _attachmentManager.Save(new SavedFileDto
            {
                attachmentType = AttachmentTypesEnum.Articles_Categories,
                CanChangeName = true,
                File = category.ProfilePictureFile
            });

            var success = _Manager.Insert(category);
            return Ok(success);
        }

        [HttpGet("{id}")]
        public ActionResult<ResultMessage> Get(byte id)
        {

            return GetStatusCodeResult(_Manager.GetById(id));
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ResultMessage> Put(int id, [FromForm] ArticlesCategoriesDto category)
        {
            if (category.ProfilePictureFile != null) {
                _attachmentManager.Delete(Uri.UnescapeDataString(category.ProfilePicture));
                category.ProfilePicture = _attachmentManager.Save(new SavedFileDto
                {
                attachmentType = AttachmentTypesEnum.Articles_Categories,
                CanChangeName = true,
                File = category.ProfilePictureFile
                });
            }
              
            return GetStatusCodeResult(_Manager.Update(category, id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return GetStatusCodeResult(_Manager.Delete(id));
        }       
    }

}