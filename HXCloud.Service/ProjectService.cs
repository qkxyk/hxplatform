using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.ModelView;
using HXCloud.Repository.EF.Repositories;
using HXCloud.ModelView.BaseData;

namespace HXCloud.Service
{
    public class ProjectService
    {
        private ProjectRepository _mr;
        public ProjectService()
        {
            _mr = new ProjectRepository();
        }
        //项目名称不能重复，项目可以作为项目的一部分（可以添加附属信息）

        public bool CheckProjectName(string projectName, string Token)
        {
            bool bRet = false;
            return bRet;
        }

        public ProjectAddViewModel AddProject(ProjectAddViewModel mavm)
        {          
            //首先验证用户是否有权限进行操作
            bool bRet = new UserService().IsAuthProject(mavm.Account, mavm.Token, mavm.ParentId, 2);
            if (!bRet)
            {
                mavm.Success = false;
                mavm.Message = "用户没有添加项目的权限";
                return mavm;
            }
            #region 验证用户权限 废弃
            /*
            UserModel um = new UserRepository().Find(mavm.Account);
            //非管理员
            //注：此处存在问题，需斟酌一下
            if (um.UserRole.Role.IsAdmin != 1)
            {
                //验证用户在最高一层项目上是否有权限
                var m = um.UserRole.Role.RoleProject.Where(a => a.ProjectId == mavm.ParentId);
                if (m.Count() > 0)
                {
                    var n = m.Select(a => a.TypeId != 0);
                    if (n.Count() == 0)
                    {
                        mavm.Success = false;
                        mavm.Message = "用户没有添加项目的权限";
                        return mavm;
                    }
                }
            }*/
            #endregion
            //验证此项目是否已存在

            ProjectModel mm = new ProjectModel();
            mm.ProjectName = mavm.ProjectName;
            mm.Token = mavm.Token;
            if (mavm.ParentId == 0)
            {
                mm.ParentId = null;
            }
            else
            {
                mm.ParentId = mavm.ParentId;
            }
            mm.ProjectType = (ProjectType)mavm.ProjectType;
            mm.Cate = 0;
            mm.level = 0;
            mm.Type = 0;
            mm.StartTime = DateTime.Now;
            //检测是否终端节点，如果是终端节点则不允许再添加节点
            if (mm.ParentId.HasValue)
            {
                ProjectModel mf = _mr.Find(mm.ParentId.Value);
                if (mf.ProjectType == (ProjectType)2)
                {
                    mavm.Success = false;
                    mavm.Message = "终端节点下不允许添加节点";
                    return mavm;
                }
            }

            ProjectModel mr = _mr.FindByName(mm);
            if (mr != null)
            {
                mavm.Success = false;
                mavm.Message = "已存在此项目";
                return mavm;
            }
            _mr.Add(mm);
            mavm.Success = true;
            mavm.Message = "添加项目成功";
            return mavm;
        }

        public bool IsLeafProject(int projectId, string token)
        {
            bool bRet = false;
            ProjectModel mm = _mr.Find(projectId, token);
            if (mm.ProjectType == (ProjectType)2)
            {
                bRet = true;
            }
            return bRet;
        }

        /// <summary>
        /// 查询包含子项目信息的项目信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ProjectModel FindProject(int projectId, string token)
        {
            ProjectModel mm = _mr.FindMenuAndChild(projectId, token);
            return mm;
        }

        /// <summary>
        /// 获取用户所能看到的所有主项目
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ProjectListViewModel FindUserMainProject(string account, string token)
        {
            //获取组织的项目
            var mm = _mr.FindMainMenu(token);
            ProjectListViewModel mlvm = new ProjectListViewModel();
            foreach (var item in mm)
            {
                //验证用户是否有此主项目的查看权限
                bool bRet = new UserService().IsAuthProject(account, token, item.Id, 0);
                if (bRet)
                {
                    ProjectViewModel mvm = new ProjectViewModel() { Id = item.Id, ProjectType = (int)item.ProjectType, Name = item.ProjectName, Token = item.Token };
                    mlvm.list.Add(mvm);
                }
            }
            mlvm.Success = true;
            mlvm.Message = "获取主项目成功";
            return mlvm;
        }

        public ProjectListViewModel FindUserSubProject(string account, string token, int projectId)
        {
            ProjectListViewModel mlvm = new ProjectListViewModel();
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                mlvm.Success = true;
                mlvm.Message = "用户没有查看此项目的权限";
                return mlvm;
            }
            var mm = _mr.FindByParentId(projectId, token);
            foreach (var item in mm)
            {
                ProjectViewModel mvm = new ProjectViewModel() { Id = item.Id, ClientId = item.ClientId, ProjectType = (int)item.ProjectType, ParentId = item.ParentId, Name = item.ProjectName, Token = item.Token };
                mlvm.list.Add(mvm);
            }
            mlvm.Success = true;
            mlvm.Message = "获取项目成功";
            return mlvm;
        }

        public ProjectListViewModel FindUserProject(string account, string token)
        {
            var mm = _mr.FindMainMenu(token);
            ProjectListViewModel mlvm = new ProjectListViewModel();
            foreach (var item in mm)
            {
                //验证用户是否有此主项目的查看权限
                bool bRet = new UserService().IsAuthProject(account, token, item.Id, 0);
                if (bRet)
                {
                    ProjectViewModel mvm = new ProjectViewModel() { Id = item.Id, ProjectType = (int)item.ProjectType, Name = item.ProjectName, Token = item.Token };
                    mlvm.list.Add(mvm);
                }
            }
            mlvm.Success = true;
            mlvm.Message = "获取用户项目成功";
            return mlvm;
        }

        public ProjectListViewModel GetUserAllProject(string account, string token)
        {
            ProjectListViewModel mlvm = new ProjectListViewModel();
            var mm = _mr.FindMenuByType(token);
            foreach (var item in mm)
            {
                //验证用户是否有权限查看
                bool bRet = new UserService().IsAuthProject(account, token, item.Id, 0);
                if (bRet)
                {
                    ProjectViewModel mvm = new ProjectViewModel() { Id = item.Id, ClientId = item.ClientId, ProjectType = (int)item.ProjectType, ParentId = item.ParentId, Name = item.ProjectName, Token = item.Token };
                    mlvm.list.Add(mvm);
                }
            }
            mlvm.Success = true;
            mlvm.Message = "获取项目成功";
            return mlvm;
        }

        /// <summary>
        /// 获取最高一级项目的编号
        /// </summary>
        /// <param name="projectId">项目或者场站编号</param>
        /// <returns>返回最高一级项目的编号</returns>
        public int GetRootId(int projectId)
        {
            var project = _mr.Find(projectId);
            if (project.ParentId.HasValue)
            {
                return GetRootId(project.ParentId.Value);
            }
            return project.Id;
        }

        public ResponseData UpdateProject(ProjectViewModel pvm)
        {
            ResponseData rd = new ResponseData() { Success = true, Message = "修改项目信息成功" };
            //验证用户是否有权限修改
            bool bRet = new UserService().IsAuthProject(pvm.Account,pvm.Token,pvm.ParentId.Value,2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改项目信息";
                return rd;
            }
            ProjectModel pm = new ProjectModel();
            return rd;
        }
    }
}
