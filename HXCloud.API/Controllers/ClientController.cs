using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HXCloud.ModelView;
using HXCloud.Service;
using HXCloud.ModelView.BaseData;

namespace HXCloud.API.Controllers
{
    /// <summary>
    /// 组织的客户信息
    /// </summary>
    public class ClientController : ApiController
    {
        private ClientService _cs;
        public ClientController()
        {
            _cs = new ClientService();
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <param name="cvm">客户信息</param>
        /// <returns>返回添加客户信息是否成功</returns>
        [HttpPost]
        public ResponseData Add(ClientViewModel cvm)
        {
            return _cs.ClientAdd(cvm);
        }

        /// <summary>
        /// 获取组织的客户信息
        /// </summary>
        /// <param name="account">用户名称</param>
        /// <param name="token">组织标示</param>
        /// <returns>返回获取的客户信息</returns>
        [HttpGet]
        public ClientListViewModel GetAll(string account, string token)
        {
            return _cs.GetClientList(account, token);
        }

        /// <summary>
        /// 根据客户标示获取客户信息
        /// </summary>
        /// <param name="account"></param>
        /// <param name="token"></param>
        /// <param name="clientId"></param>
        /// <returns>返回客户信息</returns>
        [HttpGet]
        public ClientViewModel Get(string account,string token,int id)
        {
            return _cs.GetClient(account,token,id);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="cvm">客户信息</param>
        /// <returns>返回更新客户信息是否成功</returns>
        [HttpPut]
        public ResponseData Update(ClientViewModel cvm)
        {
            return _cs.UpdateClient(cvm);
        }

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="cvm">客户信息</param>
        /// <returns>返回删除客户信息是否成功</returns>
        [HttpPost]
        public ResponseData Delete(ClientViewModel cvm)
        {
            return _cs.DeleteClient(cvm);
        }
    }
}
