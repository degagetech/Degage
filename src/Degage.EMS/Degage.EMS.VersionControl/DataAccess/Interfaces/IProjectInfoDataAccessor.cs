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
        Boolean RemoveProjectInfo(String id,Boolean removed);
        List<ProjectInfo> QueryProjectInfos(ProjectInfoCondition condition);
        ProjectInfo GetProjectInfo(String id);


        Boolean EnableVersionInfo(String id,Boolean enabled);
        Boolean AddVersionInfo(ProjectVersionInfo info);
        /// <summary>
        ///<see cref="ProjectVersionInfo.Id"/> value as update condition
        /// </summary>
        /// <param name="modifyInfo"></param>
        /// <returns></returns>
        Boolean UpdateVersionInfo(ProjectVersionInfo modifyInfo);
        Boolean DeleteVersionInfo(String id);
        Boolean RemoveVersionInfo(String id);
        List<ProjectVersionInfo> QueryVersionInfos(VersionInfoCondition condition);
        ProjectVersionInfo GetVersionInfo(String id);
    }
}
