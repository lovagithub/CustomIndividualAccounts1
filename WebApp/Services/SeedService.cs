using Microsoft.AspNetCore.Identity;

namespace WebApp.Services;

public class SeedService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {

        if (!await _roleManager.RoleExistsAsync("admin"))
            _=await _roleManager.CreateAsync(new IdentityRole("admin"));

        if (!await _roleManager.RoleExistsAsync("user"))
            _=await _roleManager.CreateAsync(new IdentityRole("user"));
    }
}
