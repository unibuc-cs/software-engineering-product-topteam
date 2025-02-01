using Microsoft.AspNetCore.Identity;

namespace backend_MT.Data
{
    public static class Seed
    {
        public static async Task InitializeRoles(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                string[] roleNames = { "Profesor", "Elev", "Administrator" };

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                        if (!result.Succeeded)
                        {
                            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                            throw new Exception($"Failed to create role '{roleName}': {errors}");
                        }
                    }
                }
            }
        }
    }
}
