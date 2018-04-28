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
    public class RoleService
    {
        RoleRepository _rr;
        UserService _us;
        public RoleService()
        {
            _rr = new RoleRepository();
            _us = new UserService();
        }

        public ResponseData CreateRole(RoleViewModel rvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员才能添加角色
            //bool bRet = new UserService().IsAdmin(rvm.a)
            //RoleListViewModel ravm = new RoleListViewModel();
            RoleModel rm = new RoleModel() { IsAdmin = rvm.IsAdmin, Token = rvm.Token, RoleName = rvm.RoleName };
            try
            {
                _rr.Add(rm);
                rd.Success = true;
                rd.Message = "添加角色成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "添加角色失败。" + ex.Message;
            }
            return rd;
        }

        public RoleListViewModel GetRoles(string account, string token)
        {
            //验证用户名和角色是否正确
            RoleListViewModel rlvm = new RoleListViewModel();
            IEnumerable<RoleModel> list = _rr.FindBy(token);
            foreach (var item in list)
            {
                RoleViewModel rvm = new RoleViewModel()
                {
                    Id = item.Id,
                    RoleName = item.RoleName,
                    Token = item.Token,
                    IsAdmin = item.IsAdmin
                };
                rlvm.list.Add(rvm);
            }
            rlvm.Success = true;
            rlvm.Message = "获取角色信息成功";
            return rlvm;
        }

        public RoleModel GetUserRole(string account, string token)
        {
            //需验证用户名和组织是否正确
            var role = _rr.FindUserRole(account, token);
            return role;
        }

        public ResponseData UpdateRole(RoleViewModel rvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员才有权限修改角色信息
            bool bRet = _us.IsAdmin(rvm.Account, rvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "只有管理员才有权限修改角色信息";
                return rd;
            }
            RoleModel rm = _rr.Find(rvm.Id);
            if (rm == null)
            {
                rd.Success = false;
                rd.Message = "该角色信息不存在";
                return rd;
            }
            try
            {
                rm.IsAdmin = rvm.IsAdmin;
                rm.RoleName = rvm.RoleName;
                _rr.Save(rm);
                rd.Success = true;
                rd.Message = "修改角色信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改角色信息失败";
            }
            return rd;
        }

        public ResponseData DeleteRole(RoleViewModel rvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员才有权限删除角色信息
            bool bRet = _us.IsAdmin(rvm.Account, rvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "只有管理员才有权限删除角色信息";
                return rd;
            }
            RoleModel rm = _rr.Find(rvm.Id);
            if (rm == null)
            {
                rd.Success = false;
                rd.Message = "该角色信息不存在";
                return rd;
            }
            try
            {
                _rr.Remove(rm);
                rd.Success = true;
                rd.Message = "删除角色信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除角色信息失败";
            }
            return rd;
        }
    }
}
