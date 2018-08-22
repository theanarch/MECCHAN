using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MECCHAN.Pages
{
    public class SignupModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly MECCHANDbContext context;

        public SignupModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, MECCHANDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //context.Add();
            await context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


    }
}