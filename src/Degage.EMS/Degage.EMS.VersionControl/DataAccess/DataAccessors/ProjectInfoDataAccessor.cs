using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degage.DataModel.Orm;
using Degage.Extension;
namespace Degage.EMS.VersionControl
{
    public class ProjectInfoDataAccessor : DataAccessor, IProjectInfoDataAccessor
    {
        public Boolean AddProjectInfo(ProjectInfo info)
        {
            return this.Options.DbProvider.Insert(info).ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }

        public Boolean DeleteProjectInfo(String id)
        {
            return this.Options.DbProvider.
                 Delete<ProjectInfo>().
                 Where(t => t.Id == id).
                 ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
        public Boolean RemoveProjectInfo(String id, Boolean removed)
        {
            var driver = this.Options.DbProvider.
                         Update<ProjectInfo>(() => new ProjectInfo
                         {
                             IsRemoved = removed
                         }).
                         Where(t => t.Id == id);
            return driver.ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
        public ProjectInfo GetProjectInfo(String id)
        {
            var projectInfo = this.Options.DbProvider.
                Select<ProjectInfo>().
                Where(t => t.Id == id).
                ToFirstOrDefault(this.Connection, this.Transaction);
            return projectInfo;
        }

        public List<ProjectInfo> QueryProjectInfos(ProjectInfoCondition condition)
        {
            List<ProjectInfo> infos = null;

            var driver = this.Options.DbProvider.Select<ProjectInfo>();
            if (condition.LastAccessTimeStart.HasValue)
            {
                driver.Where(t => t.LastAccessTime >= condition.LastAccessTimeStart.Value);
            }

            if (condition.LastAccessTimeEnd.HasValue)
            {
                driver.Where(t => t.LastAccessTime <= condition.LastAccessTimeEnd.Value);
            }

            driver.Where(t => t.IsRemoved == condition.IsRemoved);

            infos = driver.ToList(this.Connection, this.Transaction);

            return infos;
        }

        public Boolean UpdateProjectInfo(ProjectInfo modifyInfo)
        {
            return this.Options.DbProvider.Update<ProjectInfo>(() => new ProjectInfo
            {
                CurrentVersionId = modifyInfo.CurrentVersionId,
                LastAccessTime = modifyInfo.LastAccessTime,
                Title = modifyInfo.Title,
                IconFileId = modifyInfo.IconFileId,
                Description = modifyInfo.Description
            }).Where(t => t.Id == modifyInfo.Id).ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }





        public Boolean AddVersionInfo(ProjectVersionInfo info)
        {
            return this.Options.DbProvider.Insert(info).ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }

        public Boolean DeleteVersionInfo(String id)
        {
            return this.Options.DbProvider.
                 Delete<ProjectVersionInfo>().
                 Where(t => t.Id == id).
                 ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
        public Boolean RemoveVersionInfo(String id)
        {
            return this.Options.DbProvider.
                         Update<ProjectVersionInfo>(() => new ProjectVersionInfo
                         {
                             IsRemoved = true
                         }).
                         Where(t => t.Id == id).
                         ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
        public ProjectVersionInfo GetVersionInfo(String id)
        {
            var ProjectVersionInfo = this.Options.DbProvider.Select<ProjectVersionInfo>().Where(t => t.Id == id).ToFirstOrDefault(this.Connection, this.Transaction);
            return ProjectVersionInfo;
        }

        public List<ProjectVersionInfo> QueryVersionInfos(VersionInfoCondition condition)
        {
            List<ProjectVersionInfo> infos = null;
            var driver = this.Options.DbProvider.Select<ProjectVersionInfo>();
            if (condition.ProjectId.IsNullOrEmpty())
            {
                driver.Where(t => t.ProjectId == condition.ProjectId);
            }
            if (condition.IsEnabled.HasValue)
            {
                driver.Where(t => t.IsEnabled == condition.IsEnabled.Value);
            }
            driver.Where(t => t.IsRemoved == condition.IsRemoved);
            infos = driver.ToList(this.Connection, this.Transaction);
            return infos;
        }

        public Boolean EnableVersionInfo(String id, Boolean enabled)
        {
            return this.Options.DbProvider.Update<ProjectVersionInfo>(() => new ProjectVersionInfo
            {
                IsEnabled = enabled
            }).Where(t => t.Id == id).ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }

        public Boolean UpdateVersionInfo(ProjectVersionInfo modifyInfo)
        {
            return this.Options.DbProvider.Update<ProjectVersionInfo>(() => new ProjectVersionInfo
            {
                Major = modifyInfo.Major,
                Minor = modifyInfo.Minor,
                Revised = modifyInfo.Revised,
                Type = modifyInfo.Type,
                Description = modifyInfo.Description,
                LastAccessTime = modifyInfo.LastAccessTime
            }).Where(t => t.Id == modifyInfo.Id).ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
    }
}
