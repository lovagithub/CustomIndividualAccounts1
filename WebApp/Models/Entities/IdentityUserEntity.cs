using WebApp.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Models.Entities
{
    public class IdentityUserEntity : IdentityUser
    {
        [ProtectedPersonalData]
        public string? FirstName { get; set; }

        [ProtectedPersonalData]
        public string? LastName { get; set; }


        public static implicit operator User(IdentityUserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
        }
    }
}
