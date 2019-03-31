using Shared.Core.Settings.Sub;

namespace Shared.Core.Settings
{
    public class AppSettings
    {
        public AuthenticationSettings AuthenticationSettings { get; set; }
        public ApplicationUrlsSettings AppUrlsSettings  { get; set; }
        public AppPathsSettings AppPathsSettings { get; set; }        
        public EmailSettings EmailSettings { get; set; }
    }
}
