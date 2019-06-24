using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degage.DataModel.Orm;

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
        public Boolean RemoveProjectInfo(String id)
        {
            return this.Options.DbProvider.
                         Update<ProjectInfo>(()=>new ProjectInfo {
                              
                         }).
                         Where(t => t.Id == id).
                         ExecuteNonQuery(this.Connection, this.Transaction) > 0;
        }
        public ProjectInfo GetProjectInfo(String id)
        {
            var projectInfo = this.Options.DbProvider.Select<ProjectInfo>().Where(t => t.Id == id).ToFirstOrDefault(this.Connection, this.Transaction);
            return projectInfo;
        }

        public List<ProjectInfo> QueryProjectInfos(ProjectInfoCondition condition)
        {
            List<ProjectInfo> infos = null;
            if (!String.IsNullOrEmpty(condition.Id))
            {
                var projectInfo = this.Options.DbProvider.Select<ProjectInfo>().Where(t => t.Id == condition.Id).ToFirstOrDefault(this.Connection, this.Transaction);
                infos = new List<ProjectInfo>();
                infos.Add(projectInfo);
                return infos;
            }

            var driver = this.Options.DbProvider.Select<ProjectInfo>();
            if (condition.LastAccessTimeStart.HasValue)
            {
                driver.Where(t => t.LastAccessTime >= condition.LastAccessTimeStart.Value);
            }

            if (condition.LastAccessTimeEnd.HasValue)
            {
                driver.Where(t => t.LastAccessTime <= condition.LastAccessTimeEnd.Value);
            }
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
    }
}
