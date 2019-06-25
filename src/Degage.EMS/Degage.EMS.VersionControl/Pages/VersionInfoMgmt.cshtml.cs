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

        public async Task<IActionResult> OnGetAsync()
        {
            return await Task.FromResult(this.Page());
        }

        public async Task<JsonResult> OnGetQueryVersionInfosAsync(VersionInfoCondition condition)
        {
            var infos = await Task.FromResult(this.DataAccessor.QueryVersionInfos(condition));
            return this.CreateJsonResult(true, infos);
        }
        public async Task<JsonResult> OnGetGetVersionInfoAsync(String id)
        {
            var info = await Task.FromResult(this.DataAccessor.GetVersionInfo(id));
            if (info == null)
            {
                return this.CreateJsonResult(false, ResponseMessages.NotFoundInfos);
            }
            return this.CreateJsonResult(true, info);
        }

        public async Task<JsonResult> OnPostUpdateVersionInfoAsync(ProjectVersionInfo info)
        {
            var success = await Task.FromResult(this.DataAccessor.UpdateVersionInfo(info));
            return this.CreateJsonResult(success, success ? ResponseMessages.SuccessedOperation : ResponseMessages.DataOperateFailed);
        }

        public async Task<JsonResult> OnDeleteRemoveVersionInfoAsync(String id)
        {
            //²ÎÊý¼ì²é
            if (id.IsNullOrEmpty())
            {
                return this.CreateJsonResult(false, ResponseMessages.InvaildParameter);
            }
            var success = await Task.FromResult(this.DataAccessor.RemoveVersionInfo(id));
            return this.CreateJsonResult(success, success ? ResponseMessages.SuccessedOperation : ResponseMessages.DataOperateFailed);
        }
    }
}