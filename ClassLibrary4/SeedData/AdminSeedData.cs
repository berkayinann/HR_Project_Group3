using HR_Project_Group3_Domain.Entities;
using HR_Project_Group3_Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project_Group3_Persistence.SeedData
{
    public class AdminSeedData
    {

        public static async void Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext _context)
        {
            if (!_context.Users.Any(u => u.UserName == "admin"))
            {
                AppUser user = new AppUser
                {
                    UserName = "admin",
                    Email = "berkay.inan@bilgeadamboost.com",
                    EmailConfirmed = true,
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                };

                IdentityResult adminResult = await userManager.CreateAsync(user, "Berkay12345");

                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";

                await roleManager.CreateAsync(adminRole);

                AppUser createdUser = await userManager.FindByNameAsync("admin");

                await userManager.AddToRoleAsync(createdUser, adminRole.Name);



                AppUser owner = new AppUser
                {
                    UserName = "owner",
                    Email = "berkay.inan@bilgeadamboost.com",
                    EmailConfirmed = true,
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                };

                IdentityResult ownerResult = await userManager.CreateAsync(owner, "Berkay12345");

                IdentityRole ownerRole = new IdentityRole();
                ownerRole.Name = "SiteOwner";

                await roleManager.CreateAsync(ownerRole);

                AppUser createdOwner = await userManager.FindByNameAsync("owner");

                await userManager.AddToRoleAsync(createdOwner, ownerRole.Name);

                SiteManager siteOwner = new SiteManager
                {
                    FirstName = "berkay",
                    LastName = "inan",
                    TCNO = "12345678910",
                    PhoneNumber = "05392224322",
                    AppUserId = owner.Id,
                    BirthDate = Convert.ToDateTime("1997/07/03"),
                    City = "Istanbul",
                    ImagePath = "",
                    BirthPlace = "Uskudar",
                    JobId = 1,
                    District = "Maltepe",
                    Status = Status.Active,
                    AddressDetail = "Ataturk Caddesi 34840",
                    CreatedDate = DateTime.Now
                };
                _context.SiteManagers.Add(siteOwner);


         
            }
        }

    }
}

