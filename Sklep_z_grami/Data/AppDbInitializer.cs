using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sklep_z_grami.Data.Static;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Shop
                if (!context.Shops.Any())
                {
                    context.Shops.AddRange(new List<Shop>()
                    {
                        new Shop()
                        {
                            Nazwa = "Morele.net",
                            Logo = "https://www.morele.net/assets/src/images/socials/morele_logo_fb.png",
                            Lokalizacja = "al. Jana Pawła II 43b, 31-864 Kraków"
                        },
                        new Shop()
                        {
                            Nazwa = "RTV EURO AGD",
                            Logo = "https://galeriamlociny.pl/app/uploads/wayfinder/url_logo/3048.png",
                            Lokalizacja = "Podgórska 34, 31-536 Kraków"
                        },
                    });
                    context.SaveChanges();
                }

                //Publisher
                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            Nazwa = "Techland",
                            ImageURL = "https://static.wikia.nocookie.net/dyinglight/images/8/81/Techland_logo.jpg/revision/latest?cb=20150222012934&path-prefix=pl",
                            Opis = "Polskie przedsiębiorstwo zajmujące się produkcją, wydawaniem gier komputerowych. Firma posiada biura we Wrocławiu, Warszawie i Ostrowie Wielkopolskim"
                        },
                        new Publisher()
                        {
                            Nazwa = "Valve",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/a/ab/Valve_logo.svg",
                            Opis = "amerykański producent gier komputerowych. Valve jest twórcą serii Half-Life oraz Counter-Strike. W 2003 przedsiębiorstwo uruchomiło platformę dystrybucji cyfrowej Steam."
                        }
                    });
                    context.SaveChanges();
                }

                //Game
                if (!context.Games.Any())
                {
                    context.Games.AddRange(new List<Game>()
                    {
                        new Game()
                        {
                            Nazwa = "Dying Light 2",
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/6/6d/Dying_Light_2_cover_art.jpg/220px-Dying_Light_2_cover_art.jpg",
                            Opis = "Dying Light 2 to pierwszoosobowa gra akcji z otwartym światem",
                            Cena = 178.99,
                            Category = Category.Akcja,
                            PublisherId = 1,
                            ShopId = 1
                        },
                    });
                    context.SaveChanges();
                }        
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@game.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Gaming@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@game.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Gaming@1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
