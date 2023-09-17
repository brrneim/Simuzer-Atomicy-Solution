using Atomicy.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Atomicy.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Ali",
                LastName = "Demir",
                UserName = "alidemir",
                Email = "ali@test.com",
                EmailConfirmed = true,
                Firm = false,
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Sample01!");
            }
            var testUser = new ApplicationUser
            {
                FirmName = "Kolay Nakliyat",
                FirstName = "Şahin",
                LastName = "Pakır",
                UserName = "sahinpakir",
                Email = "sahin@test.com",
                EmailConfirmed = true,
                Firm = true,
            };

            user = await userManager.FindByEmailAsync(testUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(testUser, "Sample01!");
            }

        }
    }
}