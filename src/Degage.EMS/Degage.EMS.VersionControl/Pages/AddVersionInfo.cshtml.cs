using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Degage.EMS.VersionControl.Pages
{
    public class AddVersionInfoModel : PageModel
    {
        public String ReturnUrl { get; private set; }
        public async Task<IActionResult> OnGetAsync(String returnUrl)
        {
            this.ReturnUrl = returnUrl;
            return await Task.FromResult(this.Page());
        }
    }
}