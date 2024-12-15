using Microsoft.AspNetCore.Identity;

public static class RoleSeeder
{
    public static async Task Initialize(IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager)
    {
        var roleNames = new[] { "Teacher", "Student" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
