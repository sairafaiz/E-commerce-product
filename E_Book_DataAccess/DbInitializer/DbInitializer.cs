using E_Book_DataAccess.Data;
using E_Book_Models.Model;
using E_Book_Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(UserManager<IdentityUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             ApplicationDbContext db)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            //migration if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();



                    if (!_roleManager.RoleExistsAsync(SD.Role_User_Cust).GetAwaiter().GetResult())
                    {
                        _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Cust)).GetAwaiter().GetResult();
                        _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp)).GetAwaiter().GetResult();
                        _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                        _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();


                        //if roles are not created , then we will create admin user as well

                        _userManager.CreateAsync(new ApplicationUser
                        {
                            UserName = "admin@dotnetmastery.com",
                            Email = "admin@dotnetmastery.com",
                            Name = "Bhrugen",
                            PhoneNumber = "1121234",
                            StreetAddress = "test 123",
                            State = "IL",
                            PostalCode = "23422",
                            City = "Chicago"
                            
                        }, "Admin123*").GetAwaiter().GetResult();

                        ApplicationUser user = _db.applicationUser.FirstOrDefault(u => u.Email == "admin@dotnetmastery.com");

                        _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //create roles if they are not created


        }
    }
}
