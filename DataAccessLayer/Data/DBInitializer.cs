using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCMiniProject.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DBInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public DBInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDBContext dbContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task SeedDataAsync()
        {
            await _dbContext.Database.MigrateAsync();
            await CreateRolesAsync();
            await CreateAdminAsync();
        }

        private async Task CreateRolesAsync()
        {
            var roles = new[] { "Admin", "Moderator", "Member" };
            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role)) continue;

                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task CreateAdminAsync()
        {
            var adminUser = await _userManager.FindByEmailAsync("admin@example.com");

            if (adminUser != null) return;

            var newAdmin = new AppUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                FullName = "Site Admin"
            };

            var result = await _userManager.CreateAsync(newAdmin, "Admin@123");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
}

