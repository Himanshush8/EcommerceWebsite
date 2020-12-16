using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Booby",
                        Street = "Street no. 1",
                        City = "New Delhi",
                        State = "Delhi",
                        Zipcode = "110045"
                    }
                };
                await userManager.CreateAsync(user, "Qwerty@1");
            }
        }
    }
}