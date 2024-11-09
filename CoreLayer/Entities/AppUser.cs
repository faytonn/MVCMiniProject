using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities
{
    public  class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
