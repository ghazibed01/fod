using Microsoft.AspNetCore.Identity;

namespace fod.Models
{
    public class User : IdentityUser
    {
       public string Email { get; set; } // Rename one of the email properties                
        public string PasswordHash { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}