namespace Shared.Core.Utilities.Models
{
    public class UserDto : IUserDto
    {
        public string Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
