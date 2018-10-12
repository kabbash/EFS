using Attachments.Core.Interfaces;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Attachments.Core.Services
{
    public class AttachmentsManager : IAttachmentsManager
    {
        public string UploadTempPath => Configurations.UploadTempPath;
        public ResultMessage Upload(byte[] file, string fileName)
        {
            try
            {
                string fullPath = Path.Combine(UploadTempPath, fileName);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                using (System.IO.FileStream fs = fileStream)
                {
                    fs.Write(file, 0, file.Length);
                }
                return new ResultMessage()
                {
                    Data = fullPath,
                    Message = "Uploaded Successfully", //to be configurable
                    Status = (int)ResultStatus.Success
                };
            }
            catch (Exception ex)
            {
                //log ex error in file
                return new ResultMessage()
                {
                    Message = "Error",
                    Status = (int)ResultStatus.Error
                };
            }
        }
    }
}
