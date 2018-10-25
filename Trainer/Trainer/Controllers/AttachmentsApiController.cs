using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trainer.Controllers
{
    [Route("api/Attachments")]
    [ApiController]
    public class AttachmentsController : BaseController
    {
        private readonly IAttachmentsManager _attachmentManager;
        public AttachmentsController(IAttachmentsManager attachmentManager)
        {
            _attachmentManager = attachmentManager;
        }
        [HttpPost("UploadFile")]
        public ActionResult UploadFile(UploadFileDto uploadedFile)
        {
            return GetStatusCodeResult(_attachmentManager.Upload(uploadedFile));
        }

        [HttpPost]
        public ActionResult SaveFile(SaveFileDto fileDto)
        {
            return Ok(_attachmentManager.Save(fileDto));
        }
    }
}