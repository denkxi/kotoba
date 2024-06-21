using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public List<Dictionary> Dictionaries { get; set; } = new List<Dictionary>();
    }
}