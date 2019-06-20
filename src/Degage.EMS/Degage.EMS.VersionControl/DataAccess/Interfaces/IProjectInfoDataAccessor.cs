using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    public interface IProjectInfoDataAccessor : IDataAccessor
    {
        Boolean AddProjectInfo(ProjectInfo info);
        /// <summary>
        ///<see cref="ProjectInfo.Id"/> value as update condition
        /// </summary>
        /// <param name="modifyInfo"></param>
        /// <returns></returns>
        Boolean UpdateProjectInfo(ProjectInfo modifyInfo);
        Boolean DeleteProjectInfo(String id);
        List<ProjectInfo> SelectProjectInfos(ProjectInfoCondition condition);
        ProjectInfo GetProjectInfo(String id);
    }
}
