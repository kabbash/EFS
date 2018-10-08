using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shared.Core.Utilities
{
    public static class Configurations
    {
        public static string UploadTempPath
        {
            get
            {
                return Path.GetTempPath(); // to be moved to configuration file
            }
        }

    }
}
