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
    public class SysMenuService
    {
        private SysMenuRepository _sm;
        public SysMenuService()
        {
            _sm = new SysMenuRepository();
        }

        //添加菜单
        public ResponseData AddMenu(SysMenuViewModel smvm)
        {
            ResponseData rd = new ResponseData();
            //验证用户权限（只有管理员才能添加菜单）
            bool bRet = new UserService().IsAdmin(smvm.Account, smvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "该用户没有添加菜单的权限";
                return rd;
            }
            //验证菜单编号和菜单名称是否重合
            var mm = _sm.FindByName(smvm.Name, smvm.Token);
            if (mm != null)
            {
                rd.Success = false;
                rd.Message = "此菜单已添加";
                return rd;
            }
            try
            {
                SysMenuModel smm = new SysMenuModel()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Name = smvm.Name,
                    MenuType = (MenuTypes)smvm.MenuType,
                    Icon = smvm.Icon,
                    Url = smvm.Url,
                    Token = smvm.Token,
                    Remarks = smvm.Remarks
                };
                if (smvm.ParentId == "" || null == smvm.ParentId)
                {
                    smm.ParentId = null;
                }
                else
                {
                    smm.ParentId = smvm.ParentId;
                }
                _sm.Add(smm);
                rd.Success = true;
                rd.Message = "添加菜单成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "添加菜单失败" + ex.Message;
            }
            return rd;
        }

        //获取组织内的所有菜单
        public SysMenuListViewModel GetAllMenu(string token, string account)
        {
            SysMenuListViewModel sml = new SysMenuListViewModel();
            bool bRet = new UserService().IsAdmin(account, token);
            if (!bRet)
            {
                sml.Success = false;
                sml.Message = "用户没有权限查看菜单";
                return sml;
            }
            List<SysMenuModel> list = _sm.FindMenu(token);
            foreach (var item in list)
            {
                SysMenuViewModel smvm = new SysMenuViewModel()
                {
                    Id = item.Id,
                    Icon = item.Icon,
                    MenuType = (int)item.MenuType,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    Remarks = item.Remarks,
                    Url = item.Url
                };
                sml.list.Add(smvm);
            }
            sml.Success = true;
            sml.Message = "获取菜单成功";
            return sml;
        }

        public SysMenuListViewModel GetUserMenu(string account, string token)
        {
            List<SysMenuModel> list = _sm.FindMenu(token);
            bool bAdmin = new UserService().IsAdmin(account, token);
            if (!bAdmin)
            {
                //获取用户组
                RoleModel rm = new RoleService().GetUserRole(account, token);
                //获取角色对应的菜单
               // list.Where(a=>a.Id)
                // int role = new
            }
            return null;
        }
    }
}
