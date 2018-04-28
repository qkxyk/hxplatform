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
    public class ProjectAffiliateService
    {
        private ProjectAffiliateRepository _par;
        public ProjectAffiliateService()
        {
            _par = new ProjectAffiliateRepository();
        }

        //添加项目附属信息
        public ProjectAffiliateViewModel ProjectAffilateAdd(ProjectAffiliateViewModel mavm)
        {
            //验证用户是否有权限操作
            bool bRet = new UserService().IsAuthProject(mavm.Account, mavm.Token, mavm.ProjectId, 1);
            if (!bRet)
            {
                mavm.Success = false;
                mavm.Message = "用户没有此操作的权限";
                return mavm;
            }
            //主项目不能添加附属信息

            //验证是否存在相同的
            ProjectAffiliateModel mam = _par.FindBy(mavm.ProjectId, mavm.AffiliateName);
            if (mam != null)
            {
                mavm.Success = false;
                mavm.Message = "已存在相同的项目附加数据";
                return mavm;
            }
            //添加
            mam = new ProjectAffiliateModel() { AffiliateName = mavm.AffiliateName, AffiliateValue = mavm.AffiliateValue, ProjectId = mavm.ProjectId };
            try
            {
                _par.Add(mam);
                mavm.Id = mam.Id;
                mavm.Success = true;
                mavm.Message = "添加附属信息成功";
            }
            catch (Exception ex)
            {
                mavm.Success = false;
                mavm.Message = "添加附属信息失败" + ex.Message;
            }
            return mavm;
        }

        //查找项目附属信息
        public ProjectAffiliateListViewModel GetProjectAffilate(string account, string token, int projectId)
        {
            ProjectAffiliateListViewModel malvm = new ProjectAffiliateListViewModel();
            //验证用户是否有权限操作
            bool bRet = new UserService().IsAuthProject(account, token, projectId, 0);
            if (!bRet)
            {
                malvm.Success = false;
                malvm.Message = "用户没有此操作的权限";
                return malvm;
            }
            List<ProjectAffiliateModel> lmam = _par.FindBy(projectId);
            if (lmam.Count() <= 0)
            {
                malvm.Message = "该项目没有添加附属属性";
            }
            else
            {
                malvm.Message = "获取附属属性成功";
            }
            foreach (var item in lmam)
            {
                ProjectAffiliateViewModel mavm = new ProjectAffiliateViewModel()
                {
                    AffiliateName = item.AffiliateName,
                    AffiliateValue = item.AffiliateValue,
                    Id = item.Id,
                    ProjectId = item.ProjectId
                };
                malvm.list.Add(mavm);
            }
            malvm.Success = true;

            return malvm;
        }

        public ResponseData ProjectAffiliateEdit(ProjectAffiliateViewModel pavm)
        {
            ResponseData rd = new ResponseData();
            //验证用户是否有对项目附属属性所对应的一级项目有编辑的权限
            bool bRet = new UserService().IsAuthProject(pavm.Account, pavm.Token, pavm.ProjectId, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有编辑该属性的权限";
                return rd;
            }
            try
            {
                ProjectAffiliateModel pam = new ProjectAffiliateModel();
                pam.Id = pavm.Id;
                pam.AffiliateName = pavm.AffiliateName;
                pam.AffiliateValue = pavm.AffiliateValue;
                pam.ProjectId = pavm.ProjectId;
                _par.Save(pam);
                rd.Success = true;
                rd.Message = "修改附属属性成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "修改附属属性失败！" + ex.Message;
            }
            return rd;
        }

        public ResponseData ProjectAffiliateRemove(ProjectAffiliateViewModel pavm)
        {
            ResponseData rd = new ResponseData();
            //验证用户是否有对项目附属属性所对应的一级项目有编辑的权限
            bool bRet = new UserService().IsAuthProject(pavm.Account, pavm.Token, pavm.ProjectId, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有删除该属性的权限";
                return rd;
            }
            try
            {
                ProjectAffiliateModel pam = _par.Find(pavm.Id);
                if (pam == null)
                {
                    rd.Success = false;
                    rd.Message = "该附属属性不存在";
                    return rd;
                }
                _par.Remove(pam);
                rd.Success = true;
                rd.Message = "删除附属属性成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "删除附属属性失败！" + ex.Message;
            }
            return rd;
        }
    }
}
