using System;
using System.Collections.Generic;
using System.IO;
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

            //uploadedFile.Bytes = System.IO.File.ReadAllBytes(Path.Combine(@"I:\EFS_Project\EFS\Trainer\Trainer\Tmp\m.jpg")); ;
            //uploadedFile.FileName = "magdy.jpg";
            ////_attachmentManager.Upload(uploadedFile);
            //_attachmentManager.Save(new SaveFileDto()
            //{
            //    attachmentType = Shared.Core.Utilities.AttachmentTypes.Product,
            //    FileName = "Product1.jpg",
            //    SubFolderName = "1",
            //    TempPath = _attachmentManager.Upload(uploadedFile).Data.ToString()
            //});

            return GetStatusCodeResult(_attachmentManager.Upload(uploadedFile));
        }

        [HttpPost]
        public ActionResult SaveFile(SaveFileDto fileDto)
        {
            return Ok(_attachmentManager.Save(fileDto));
        }
    }
}