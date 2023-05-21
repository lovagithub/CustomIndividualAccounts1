﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class LoginController1 : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    public LoginController1(SignInManager<CustomIdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserLoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Incorrect email address or password");
        }

        return View(viewModel);
    }
}
