using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, UserManager<AppUser> userManager)
        {
            try
            {
                //Seed Delivery Methods
                if (!context.DeliveryMethods.Any())
                {
                    var deliveryData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);

                    if (methods != null)
                    {
                        foreach (var item in methods)
                        {
                            context.DeliveryMethods.Add(item);
                        }
                        await context.SaveChangesAsync();
                    }
                }


                // Seed Users and invite role as admin (admin@sabbay-buy.com)
                if (!userManager.Users.Any(x => x.UserName == "admin@sabbay-buy.com"))
                {
                    var user = new AppUser
                    {
                        UserName = "admin@sabbay-buy.com",
                        Email = "admin@sabbay-buy.com",
                        FirstName = "Admin",
                        LastName = "User"

                    };
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Admin");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
