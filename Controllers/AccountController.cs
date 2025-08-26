using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartTrack.Data;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // 🔹 Register (GET)
    [HttpGet]
    public IActionResult Register() => View();

    // 🔹 Register (POST)
    [HttpPost]
    public async Task<IActionResult> Register(string email, string password)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View();
    }

    // 🔹 Login (GET)
    [HttpGet]
    public IActionResult Login() => View();

    // 🔹 Login (POST)
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid login attempt");
        }

        return View();
    }

    // 🔹 Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // 🔹 Access Denied
    public IActionResult AccessDenied() => View();
}
