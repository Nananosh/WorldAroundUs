using Microsoft.AspNetCore.Identity;

namespace WorldAroundUs.Models
{
    public class User : IdentityUser

    {
        public string UserImageUrl { get; set; }
    }
}