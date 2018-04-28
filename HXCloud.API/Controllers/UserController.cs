using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.Service;

namespace HXCloud.API.Controllers
{

    /// <summary>
    /// 用户功能
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="lvm">输入用户名和密码</param>
        /// <returns>返回用户是否登录成功，如果用户登录成功，则通过返回成功和用户所属的组织</returns>
        [HttpPost]
        public LoginViewModel Login(LoginViewModel lvm)
        {
            UserService us = new UserService();
            lvm = us.Login(lvm);
            return lvm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvm"></param>
        [HttpPost]
        public void ChangePassword(LoginViewModel lvm)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvm"></param>
        [HttpPost]
        public void UpdateUser(LoginViewModel lvm)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruvm"></param>
        /// <returns></returns>
        [HttpPost]
        public RegisterUserViewModel Register(RegisterUserViewModel ruvm)
        {
            UserService us = new UserService();
            ruvm = us.ReginsterUser(ruvm);
            return ruvm;
        }

        /// <summary>
        /// 更新用户组织信息
        /// </summary>
      ///<param name="uvvm">用户信息</param>
        /// <returns>返回是否更新成功信息</returns>
        [HttpPost]
        public UserUpdateViewModel UserUpdateToken(UserUpdateViewModel uvvm)
        {
            UserService us = new UserService();
            return us.UserUpdateToken(uvvm);
        }
    }
}
