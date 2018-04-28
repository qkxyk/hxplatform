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
    public class ClientService
    {
        private ClientRepository _cr;
        public ClientService()
        {
            _cr = new ClientRepository();
        }

        public ResponseData ClientAdd(ClientViewModel cvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员才能添加客户信息
            #region 验证用户权限
            //首先验证用户是否有权限进行操作
            /*
            UserModel um = new UserRepository().FindByUserAndToken(cvm.Account, cvm.Token);//.Find(cvm.Account);
            //非管理员
            
            if (um.UserRole.Role.IsAdmin != 1)
            {
                cvm.Success = false;
                cvm.Message = "用户没有添加客户的权限";
                return cvm;
            }*/
            bool bRet = new UserService().IsAdmin(cvm.Account, cvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有添加客户的权限";
                return rd;
            }

            #endregion
            ClientModel cm = new ClientModel()
            {
                ClientName = cvm.ClientName,
                Address = cvm.Address,
                Linkman = cvm.Linkman,
                ClientSn = cvm.ClientSn,
                Telephone = cvm.Telephone,
                Mobile = cvm.Mobile,
                Description = cvm.Description,
                Token = cvm.Token
            };
            _cr.Add(cm);
            //cvm.Id = cm.Id;
            rd.Success = true;
            rd.Message = "添加各户成功";
            return rd;
        }

        public ClientListViewModel GetClientList(string account, string token)
        {
            ClientListViewModel clvm = new ClientListViewModel();
            List<ClientModel> list = _cr.FindAll(token);
            foreach (var item in list)
            {
                ClientViewModel cbvm = new ClientViewModel();
                cbvm.Id = item.Id;
                cbvm.ClientName = item.ClientName;
                cbvm.Address = item.Address;
                cbvm.Linkman = item.Linkman;
                cbvm.ClientSn = item.ClientSn;
                cbvm.Telephone = item.Telephone;
                cbvm.Mobile = item.Mobile;
                cbvm.Description = item.Description;
                cbvm.Token = item.Token;
                clvm.list.Add(cbvm);
            }
            clvm.Success = true;
            clvm.Message = "获取客户信息成功";
            return clvm;
        }

        public ClientViewModel GetClient(string account, string token, int id)
        {
            ClientModel cm = _cr.Find(id);
            ClientViewModel cvm = new ClientViewModel();
            if (cm != null)
            {
                cvm.Address = cm.Address;
                cvm.ClientName = cm.ClientName;
                cvm.ClientSn = cm.ClientSn;
                cvm.Description = cm.Description;
                cvm.Linkman = cm.Linkman;
                cvm.Mobile = cm.Mobile;
                cvm.Telephone = cm.Telephone;
                cvm.Id = cm.Id;
            }
            else
            {
                cvm.Success = false;
                cvm.Message = "此客户信息不存在";
            }
            return cvm;
        }

        public ResponseData UpdateClient(ClientViewModel cvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员有权限进行修改客户信息
            bool bRet = new UserService().IsAdmin(cvm.Account, cvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "只有管理员才能修改客户信息";
                return rd;
            }
            ClientModel cm = _cr.Find(cvm.Id);
            if (cm == null)
            {
                rd.Success = false;
                rd.Message = "客户信息不存在，请确认";
                return rd;
            }
            try
            {
                cm.Address = cvm.Address;
                cm.ClientName = cvm.ClientName;
                cm.ClientSn = cvm.ClientSn;
                cm.Description = cvm.Description;
                cm.Linkman = cvm.Linkman;
                cm.Mobile = cvm.Mobile;
                cm.Telephone = cvm.Telephone;
                _cr.Save(cm);
                rd.Success = true;
                rd.Message = "修改客户信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改客户信息失败";
            }
            return rd;
        }
        public ResponseData DeleteClient(ClientViewModel cvm)
        {
            ResponseData rd = new ResponseData();
            //只有管理员有权限进行删除客户信息,删除客户信息时需要把管理的项目信息的客户信息置为NULL
            bool bRet = new UserService().IsAdmin(cvm.Account, cvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "只有管理员才能删除客户信息";
                return rd;
            }
            ClientModel cm = _cr.Find(cvm.Id);
            if (cm == null)
            {
                rd.Success = false;
                rd.Message = "客户信息不存在，请确认";
                return rd;
            }
            try
            {
                _cr.Remove(cm);
                rd.Success = true;
                rd.Message = "删除客户信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除客户信息失败";
            }
            return rd;
        }
    }
}
