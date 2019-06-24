using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Degage.EMS.VersionControl.Pages
{
    public class ErrorModel : PageModel
    {
        public String ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(String message)
        {
            this.ErrorMessage = message;
            return await Task.FromResult(this.Page());
        }
    }
}