using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IdentityContext _identityContext;
    private readonly SeedService _seedService;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _seedService = seedService;
        _roleManager = roleManager;
    }

    public IdentityContext Get_identityContext()
    {
        return _identityContext;
    }

    public async Task<bool> SignUpAsync(UserSignUpViewModel model, IdentityContext _identityContext)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";
            
            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            IdentityUser identityUser = model;
            _=await _userManager.CreateAsync(identityUser, model.Password);

            _=await _userManager.AddToRoleAsync(identityUser, roleName);

            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;

            object value = _identityContext.UserProfiles.Add(userProfileEntity);
            _=await _identityContext.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }



    public async Task<bool> SignInAsync(UserSignInViewModel model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }
        catch { return false; }
    }


    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }
}
