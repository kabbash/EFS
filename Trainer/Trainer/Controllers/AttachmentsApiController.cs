using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attachments.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Trainer.Controllers
{
    [Route("api/Attachments")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentsManager _attachmentManager;
        public AttachmentsController(IAttachmentsManager attachmentManager)
        {
            _attachmentManager = attachmentManager;
        }
        public JsonResult UploadFile(byte[] pFileBytess, string pFileName)
        {
            //validate here or in manager ?!
            return new JsonResult(_attachmentManager.Upload(pFileBytess, pFileName));
        }
    }
}