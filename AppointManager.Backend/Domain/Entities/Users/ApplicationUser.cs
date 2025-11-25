using Microsoft.AspNetCore.Identity;

namespace AppointManager.Backend.Domain.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
