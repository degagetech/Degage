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
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ProjectInfoMgmtModel : PageModel
    {
        protected ILogger<ProjectInfoMgmtModel> Logger { get; set; }
        protected IProjectInfoDataAccessor DataAccessor { get; set; }
        protected IdentifyFactory IdentifyFactory { get; set; }
        public String ProjectId { get; private set; }
        public ProjectInfoMgmtModel(ILogger<ProjectInfoMgmtModel> logger, IProjectInfoDataAccessor accessor, IdentifyFactory identifyFactory)
        {
            this.Logger = logger;
            this.DataAccessor = accessor;
            this.IdentifyFactory = identifyFactory;
        }
        public async Task<JsonResult> OnGetQueryProjectInfosAsync(ProjectInfoCondition condition)
        {
            var infos = await Task.FromResult(this.DataAccessor.QueryProjectInfos(condition));
            return this.CreateJsonResult(true, infos);
        }

        public async Task<IActionResult> OnGetAsync(String id)
        {
            this.ProjectId = id;
            return await Task.FromResult(this.Page());
        }

        public async Task<JsonResult> OnGetGetProjectInfoAsync(String id)
        {
            var projectInfo = await Task.FromResult(this.DataAccessor.GetProjectInfo(id));
            if (projectInfo == null)
            {
                return this.CreateJsonResult(false, ResponseMessages.NotFoundInfos);
            }
            return this.CreateJsonResult(true, projectInfo);
        }

        public async Task<JsonResult> OnPostUpdateProjectInfoAsync(ProjectInfo info)
        {
            //参数检查
            if (info.Title.IsNullOrEmpty())
            {
                return this.CreateJsonResult(false, ResponseMessages.InvaildParameter);
            }
            var success = await Task.FromResult(this.DataAccessor.UpdateProjectInfo(info));
            return this.CreateJsonResult(success, success ? ResponseMessages.SuccessedOperation : ResponseMessages.DataOperateFailed);
        }

        public async Task<JsonResult> OnDeleteRemoveProjectInfoAsync(String id)
        {
            //参数检查
            if (id.IsNullOrEmpty())
            {
                return this.CreateJsonResult(false, ResponseMessages.InvaildParameter);
            }
            var success = await Task.FromResult(this.DataAccessor.RemoveProjectInfo(id,true));
            return this.CreateJsonResult(success, success ? ResponseMessages.SuccessedOperation : ResponseMessages.DataOperateFailed);
        }
    }
}