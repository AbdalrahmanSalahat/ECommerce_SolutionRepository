using DAL.Db_ContextFolder;
using DAL.Migrations;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public SeedData (ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> UserManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = UserManager;

        } 
        
        public async Task  DataSeeding()
        {
          if((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }
            if (!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(
                    new Category { Name="Phones"},
                    new Category { Name="Laptops"}
                    );
               
            }
           await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeeding()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
          
                await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
                await _roleManager.CreateAsync(new IdentityRole { Name = "Customer " });

            }
            if(!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                     UserName="Abdalrahman17",
                     Name="Abdalrahman Salahat",
                     Email="salahat00@gmail.com",
                     EmailConfirmed = true

                };
                var user2 = new ApplicationUser()
                {
                    UserName = "Hamada12",
                    Name = "Hamada salahat",
                    Email = "Hamada@gmail.com",
                    EmailConfirmed = true

                };

                await _userManager.CreateAsync(user1, "@Abc1234");
                await _userManager.CreateAsync(user2, "@Abc1234");

                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "Customer");

            }
            await _context.SaveChangesAsync();
            
        }
    }
}
