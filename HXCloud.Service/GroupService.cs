using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView;
using HXCloud.Model;
using HXCloud.Repository.EF.Repositories;

namespace HXCloud.Service
{
    public class GroupService
    {
        private GroupRepository gr;
        public GroupService()
        {
            gr = new GroupRepository();
        }
        //创建组织
        public GroupViewModel CreateGroup(GroupViewModel gvm)
        {
            //验证用户名存在系统中
            bool bRet = new UserService().CheckUserAccount(gvm.Account);
            if (!bRet)
            {
                gvm.Success = false;
                gvm.Message = "系统中不存在此用户名";
                return gvm;
            }
            //1、生成组织，2、创建该组织的管理员角色，3、添加该用户为该组织的管理员角色     
            GroupViewModel gvmr = new GroupViewModel();
            //检测组织名是否存在
            if (CheckGroupName(gvm.GroupName))
            {
                gvmr.Success = false;
                gvmr.Message = "已存在此组织，请选择其他名称";
            }
            else
            {
                try
                {
                    GroupModel gm = new GroupModel() { GroupName = gvm.GroupName };
                    gr.Add(gm,gvm.Account);                 
                    gvmr.Success = true;
                    gvmr.Message = "添加组织成功";
                }
                catch (Exception ex)
                {
                    gvmr.Success = false;
                    gvmr.Message = ex.Message;
                    return gvmr;
                }
            }
            return gvmr;
        }

        //根据组织名称查找组织数据
        public GroupListViewModel GetGroupList(string Query)
        {
            GroupListViewModel glvm = new GroupListViewModel();
            IEnumerable<GroupModel> gm = gr.FindBy(Query);
            glvm.Success = true;
            foreach (var item in gm)
            {
                GroupViewModel gvm = new GroupViewModel();
                gvm.Token = item.Id;
                gvm.GroupName = item.GroupName;
                gvm.Description = item.Description;
                glvm.listGroup.Add(gvm);
            }
            if (glvm.listGroup.Count <= 0)
            {
                glvm.Message = "没有此组织";
            }
            else
            {
                glvm.Message = "组织";
            }
            return glvm;
        }
        //根据组织标示获取组织数据
        public GroupViewModel GetGroupByToken(string token)
        {
            GroupViewModel gvm = new GroupViewModel();
            gvm.Success = true;
            GroupModel gm = gr.Find(token);
            if (gm != null)
            {
                gvm.Token = gm.Id;
                gvm.Description = gm.Description;
                gvm.GroupName = gm.GroupName;
            }
            gvm.Message = "获取组织成功";
            return gvm;
        }
        //检测组织名是否已存在，存在返回true，不存在返回false
        private bool CheckGroupName(string name)
        {
            bool bRet = false;
            int count = gr.FindBy(name).Count();
            if (count > 0)
            {
                bRet = true;
            }
            return bRet;
        }
    }
}
