using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
namespace Degage.EMS.VersionControl
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
        }
        public async Task<IActionResult> OnGetAsync()
        {

            return await Task.FromResult(this.Page());
        }
   
    }
}