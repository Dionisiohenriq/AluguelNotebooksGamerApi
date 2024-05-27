using Microsoft.AspNetCore.Identity;

namespace AluguelNotebooksGamerApi.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
