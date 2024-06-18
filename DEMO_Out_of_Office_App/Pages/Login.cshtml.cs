using DEMOOutOfOfficeApp.Core.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using DEMOOutOfOfficeApp.Common.Enums;

namespace DEMOOutOfOfficeApp.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public LoginModel(IGetAllUsersUseCase getAllDataUseCase)
        {
            _getAllUsersUseCase = getAllDataUseCase;
        }

        //Loging Authentication mechanism
        public async Task<IActionResult> OnPostAsync()
        {
            var users = await _getAllUsersUseCase.ExecuteAsync();
            var user = users.SingleOrDefault(u => u.Username == Username && u.PasswordHash == GetMd5Hash(Password));

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("EmployeeID", user.EmployeeID.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.UserRole.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                };

                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity), authProperties);

                var userRoleClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (user.Role.UserRole == UserRole.Employee)
                {
                    return RedirectToPage("/Projects/Projects");
                }
                else
                {
                    return RedirectToPage("/Employees/Employees");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
