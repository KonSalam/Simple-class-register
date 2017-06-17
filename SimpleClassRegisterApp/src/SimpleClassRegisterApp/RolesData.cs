using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleClassRegisterApp
{
    public static class RolesData
    {
        private static readonly string[] roles = new[] {
            "Teacher",
            "Student",
            "Administrator"
        };

        public static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    var create = await roleManager.CreateAsync(new IdentityRole(role));

                    if (!create.Succeeded)
                    {
                        throw new Exception("Failed to create role");
                    }
                }

            }
        }
    }
}