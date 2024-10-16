﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using oai_poc_backend.Data_Transfer_Objects.From_client;
using oai_poc_backend.Models;
using System.Security.Claims;

namespace oai_poc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginData)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(loginData.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.PasswordSignInAsync(userName: loginData.Email, password: loginData.Password, isPersistent: loginData.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Email, loginData.Email),
                        //Add custom claim for the organization id to enable accessing this in controllers.
                        new Claim("OrganizationId", user.OrganizationId.ToString())
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginData.RememberMe,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                return Ok();

            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return Ok(new { message = "User successfully logged out" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Internal server while logging out. Please try again later." });
            }

        }
    }
}
