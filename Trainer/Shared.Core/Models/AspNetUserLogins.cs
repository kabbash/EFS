using System;
using System.Collections.Generic;

namespace Shared.Core.Models
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
