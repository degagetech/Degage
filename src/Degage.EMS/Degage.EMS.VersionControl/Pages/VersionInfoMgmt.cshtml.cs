using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Degage.Extension;

namespace Degage.EMS.VersionControl.Pages
{
    public class VersionInfoMgmtModel : PageModel
    {
        protected ILogger<VersionInfoMgmtModel> Logger { get; set; }
        protected IProjectInfoDataAccessor DataAccessor { get; set; }
        protected IdentifyFactory IdentifyFactory { get; set; }
        public VersionInfoMgmtModel(ILogger<VersionInfoMgmtModel> logger, IProjectInfoDataAccessor accessor, IdentifyFactory identifyFactory)
        {
            this.Logger = logger;
            this.DataAccessor = accessor;
            this.IdentifyFactory = identifyFactory;
        }

        public void OnGet()
        {
        }
    }
}