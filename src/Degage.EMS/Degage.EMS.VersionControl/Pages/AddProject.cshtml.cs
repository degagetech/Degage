using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Degage.EMS.VersionControl.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class AddProjectModel : PageModel
    {
        protected ILogger Logger { get; set; }
        protected IProjectInfoDataAccessor DataAccessor { get; set; }
        public void OnGet(ILogger<AddProjectModel> logger, IProjectInfoDataAccessor accessor)
        {
            this.Logger = logger;
            this.DataAccessor = accessor;
        }


    }
}