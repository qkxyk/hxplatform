using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using HXCloud.ModelView;
using HXCloud.Repository.EF.Repositories;
using HXCloud.Common;

namespace HXCloud.Service
{
    /// <summary>
    /// 权限验证分菜单权限验证和项目权限验证(移动端只有项目权限)
    /// 项目权限验证：权限只设最顶级项目的权限，即最顶级项目有查看、编辑和添加/删除权限，其下所有的子项目和设备都有相应的权限
    /// 菜单权限：只有管理员权限才能管理菜单，其他用户只能使用菜单
    /// </summary>
    public class UserService
    {
        private UserRepository ur;
        public UserService()
        {
            ur = new UserRepository();
        }

        //用户注册
        public RegisterUserViewModel ReginsterUser(RegisterUserViewModel ruvm)
        {
            RegisterUserViewModel ruvmr = new RegisterUserViewModel();
            // return ruvmr;
            if (CheckUserAccount(ruvm.Account))
            {
                ruvmr.Success = false;
                ruvmr.Message = "此用户名已存在";
            }
            else
            {
                string strSalt = EncryptData.CreateRandom(4);
                ruvm.Password = EncryptData.EncryptPassword(ruvm.Password, strSalt);
                UserModel um = new UserModel()
                {
                    Account = ruvm.Account,
                    Password = ruvm.Password,
                    UserName = ruvm.RealName,
                    Salt = strSalt,
                    Valide = 0
                };
                try
                {
                    ur.Add(um);
                    ruvmr.Success = true;
                    ruvmr.Message = "注册用户成功";
                }
                catch (Exception ex)
                {
                    ruvmr.Success = false;
                    ruvmr.Message = ex.Message;
                }
            }
            return ruvmr;
        }
        //用户登录(登录成功返回用户的组织标示和该用户的id)
        public LoginViewModel Login(LoginViewModel lvm)
        {
            LoginViewModel lvmr = new LoginViewModel();
            string query = lvm.Account;
            UserModel um = GetUserInfo(lvm.Account);
            if (um == null)
            {
                lvmr.Success = false;
                lvmr.Message = "此用户不存在";
            }
            else
            {
                lvm.Password = EncryptData.EncryptPassword(lvm.Password, um.Salt);
                if (lvm.Password != um.Password)
                {
                    lvmr.Success = false;
                    lvmr.Message = "密码不正确";
                }
                else
                {
                    lvmr.Success = true;
                    lvmr.UserId = um.Id;
                    if (um.Token == null || "" == um.Token)
                    {
                        lvmr.Message = "用户没有加入组织";
                    }
                    else
                    {
                        //检测用户是否已经审核
                        if (!IsCheck(um))
                        {
                            lvmr.Message = "该用户未通过审核，请联系系统管理员";
                            return lvmr;
                        }
                        lvmr.Token = um.Token;
                        lvmr.Message = "用户登录成功";
                    }
                }
            }
            return lvmr;
        }
        //用户修改密码

        //修改用户信息
        public UserModel UpdateUserToken(UserModel um)
        {
            ur.Save(um);
            return um;
        }
        //根据用户名获取用户信息
        public UserModel GetUserInfo(string account)
        {
            //account = "a=>a.Account==" + account;
            UserModel um = ur.Find(account);
            return um;
        }
        //检测用户名是否存在
        public bool CheckUserAccount(string account)
        {
            int count = ur.FindBy(account).Count();
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证用户是否是管理员
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="token">用户所在的组织</param>
        /// <returns>返回用户是否是管理员</returns>
        public bool IsAdmin(string account, string token)
        {
            bool bRet = false;
            UserModel um = ur.FindByUserAndToken(account, token);

            if (um.UserRole == null)
            {
                bRet = false;
            }
            else if (um.UserRole.Role == null)
            {
                bRet = false;
            }
            else if (um.UserRole.Role.IsAdmin == 1)
            {
                bRet = true;
            }

            return bRet;
        }
        /// <summary>
        /// 验证用户是否有权限进行操作
        /// </summary>
        /// <param name="account">用户账号</param>
        /// <param name="token">用户所在组织</param>
        /// <param name="projectId">项目标示</param>
        /// <param name="operate">操作标示，0为查看，1为编辑，2为删除</param>
        /// <param name="recursion">验证用户项目是否需要递归操作，默认为1需要递归，0时不需要递归</param>
        /// <returns></returns>
        public bool IsAuthProject(string account, string token, int projectId, int operate, int recursion = 1)
        {
            bool bRet = false;
            if (IsAdmin(account, token))
            {
                bRet = true;
                return bRet;
            }
            //获取最高一层项目编号(只验证最高一层权限)
            if (recursion == 1)
            {
                projectId = new ProjectService().GetRootId(projectId);
            }
            List<RoleProjectModel> lrm = ur.Find(account).UserRole.Role.RoleProject.ToList();
            if (lrm.Count() <= 0)
            {
                return bRet;
            }
            if (operate == 0)
            {
                bRet = true;
                return bRet;
            }
            else
            {
                RoleProjectModel rmm = lrm.Find(a => a.ProjectId == projectId && a.TypeId >= (RoleProject)operate);
                if (rmm != null)
                {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool IsCheck(UserModel um)
        {
            if (IsAdmin(um.Account, um.Token))
            {
                return true;
            }
            else if (um.Valide == 1)//非管理员需要审核
            {
                return true;
            }
            return false;
        }

        public UserUpdateViewModel UserUpdateToken(UserUpdateViewModel uvvm)
        {
            //UserUpdateViewModel uuvm = new UserUpdateViewModel();
            UserModel um = GetUserInfo(uvvm.Account);
            if (um == null)
            {
                uvvm.Success = false;
                uvvm.Message = "用户名不存在";
                return uvvm;
            }
            GroupModel gm = new GroupRepository().FindByName(uvvm.GroupName);
            if (gm == null)
            {
                uvvm.Success = false;
                uvvm.Message = "组织名称不存在";
                return uvvm;
            }
            um.Token = gm.Id;
            try
            {
                ur.Save(um);
                uvvm.Success = true;
                uvvm.Message = "加入组织成功，请等待管理员审核";
            }
            catch (Exception ex)
            {
                uvvm.Success = false;
                uvvm.Message = "加入组织失败" + ex.Message;
            }
            return uvvm;
        }
    }
}
