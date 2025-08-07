using Microsoft.AspNetCore.Identity;

namespace CorporateAPI.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string? NameSurname { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public bool Admin { get; set; } = false;
    }
}
