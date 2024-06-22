namespace DEMOOutOfOfficeApp.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return RedirectToPage("/Login");
        }
    }
}
