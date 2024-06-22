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

        public LoginModel(IGetAllUsersUseCase getAllUsersUseCase)
        {
            _getAllUsersUseCase = getAllUsersUseCase;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
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

                    if (user.Role.UserRole == UserRole.Employee)
                    {
                        return RedirectToPage("/Projects");
                    }
                    else
                    {
                        return RedirectToPage("/Employees");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing login attempt for username {Username}.", Username);
                throw;
            }
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