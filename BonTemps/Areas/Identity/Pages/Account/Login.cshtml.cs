using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BonTemps.Models;
using BonTemps.Data;

namespace BonTemps.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<Klant> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private UserManager<Klant> _usermanager;
        private ApplicationDbContext _context;

        public LoginModel(SignInManager<Klant> signInManager, ILogger<LoginModel> logger, ApplicationDbContext context, UserManager<Klant> usermanager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _usermanager = usermanager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="U heeft nog geen e-mail adres ingevuld.")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "U heeft nog geen wachtwoord ingevuld.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    //var user = await _usermanager.FindByEmailAsync(Input.Email);
                    //var role = await _usermanager.GetRolesAsync(user);

                    //string CurrentRole = role[0];

                    //switch (CurrentRole)
                    //{
                    //    case "Manager":
                    //        return RedirectToAction("Index", "Manager", new { area = "Manager" });
                    //        break;
                    //    case "Chef":
                    //        return RedirectToAction("Index", "ChefBoard", new { area = "Chef" });
                    //        break;
                    //    case "Bediening":
                    //        return RedirectToAction("Index", "Systeem");
                    //        break;
                    //    case "Klant":
                    //        break;
                    //    default:
                    //        break;
                    //}

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
