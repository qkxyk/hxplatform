using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.ModelView;
using HXCloud.Model;
using HXCloud.Repository.EF.Repositories;
using HXCloud.ModelView.BaseData;
using Newtonsoft.Json;

namespace HXCloud.Service
{
    public class DeviceTypeService
    {
        private DeviceTypeRepository _dtr;
        public DeviceTypeService()
        {
            _dtr = new DeviceTypeRepository();
        }

        public DeviceTypeViewModel DeviceTypeAdd(DeviceTypeViewModel dtvm)
        {
            //验证用户权限(只有管理员能添加设备类型)
            #region 验证用户权限
            //首先验证用户是否有权限进行操作
            bool bRet = new UserService().IsAdmin(dtvm.Account, dtvm.Token);
            if (!bRet)
            {
                dtvm.Success = false;
                dtvm.Message = "用户没有添加设备类型的权限";
                return dtvm;
            }
            /*
            UserModel um = new UserRepository().Find(dtvm.Account);
            //非管理员
            
            if (um.UserRole.Role.IsAdmin != 1)
            {
                dtvm.Success = false;
                dtvm.Message = "用户没有添加设备类型的权限";
                return dtvm;
            }*/

            #endregion
            //验证设备类型名称是否已经存在
            DeviceTypeModel dtm = _dtr.Find(dtvm.DeviceTypeName, dtvm.Token);
            if (dtm != null)
            {
                dtvm.Success = false;
                dtvm.Message = "已存在此设备类型";
                return dtvm;
            }
            //添加设备类型
            dtm = new DeviceTypeModel();
            dtm.DeviceTypeName = dtvm.DeviceTypeName;
            dtm.Token = dtvm.Token;
            dtm.Description = dtvm.Description;
            if (dtvm.ParentId == 0)
            {
                dtm.ParentId = null;
            }
            else
            {
                dtm.ParentId = dtvm.ParentId;
            }
            try
            {
                _dtr.Add(dtm);
                dtvm.Id = dtm.Id;
            }
            catch (Exception ex)
            {
                dtvm.Success = false;
                dtvm.Message = "添加设备类型失败" + ex.Message;
                return dtvm;
            }
            dtvm.Success = true;
            dtvm.Message = "添加设备类型成功";
            return dtvm;
        }

        public DeviceTypeListReponseViewModel GetDeviceTypeList(string token)
        {
            DeviceTypeListReponseViewModel dtlrvm = new DeviceTypeListReponseViewModel();
            List<DeviceTypeModel> list = _dtr.FindAll(token);
            foreach (var item in list)
            {
                DeviceTypeViewModel dtvm = new DeviceTypeViewModel();
                dtvm.Id = item.Id;
                dtvm.ParentId = item.ParentId;
                dtvm.Token = item.Token;
                dtvm.DeviceTypeName = item.DeviceTypeName;
                dtvm.Description = item.Description;
                dtlrvm.List.Add(dtvm);
            }
            dtlrvm.Success = true;
            dtlrvm.Message = "获取设备类型列表成功";
            return dtlrvm;
        }
        public ResponseData GetDeviceGroupData(RequestData rd)
        {
            Dictionary<string, int> DicAggregate = new Dictionary<string, int>();
            //获取组织下设备的分组数据(key为类型，value为该类型的设备)
            Dictionary<int, int> Dic = new DeviceService().GetDeviceGroupData(rd.Token);

            //获取设备类型信息(一级）
            List<DeviceTypeModel> list = _dtr.GetFirstLevelType(rd.Token);
            #region 统计数据
            foreach (var item in list)
            {
                string name = item.DeviceTypeName;
                int count = 0;
                //统计一级目录下的设备               
                var ff = Dic.Keys.Contains(item.Id);
                if (ff)
                {
                    count += Dic[item.Id];
                }
                //统计子项目下挂的设备
                IEnumerable<DeviceTypeModel> ldt = _dtr.GetSonID(item.Id, rd.Token);
                foreach (var it in ldt)
                {
                    var a = Dic.ContainsKey(it.Id);
                    if (a)
                    {
                        count += Dic[it.Id];
                    }
                }
                if (DicAggregate.Keys.Contains(name))
                {
                    DicAggregate[name] += count;
                }
                else
                {
                    DicAggregate.Add(name, count);
                }
            }
            #endregion

            string ss = JsonConvert.SerializeObject(DicAggregate);
            ResponseData response = new ResponseData();
            response.Success = true;
            response.Message = ss;
            return response;
        }

        public ResponseData UpdateDeviceType(DeviceTypeViewModel dtvm)
        {
            ResponseData rd = new ResponseData();
            //验证用户权限，只有管理员才能处理
            UserService us = new UserService();
            bool bRet = us.IsAdmin(dtvm.Account, dtvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备类型信息";
            }
            DeviceTypeModel dtm = _dtr.Find(dtvm.Id);
            dtm.ParentId = dtvm.ParentId;
            dtm.Description = dtvm.Description;
            dtm.DeviceTypeName = dtvm.DeviceTypeName;
            try
            {
                _dtr.Save(dtm);
                rd.Success = true;
                rd.Message = "修改设备类型信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "修改设备类型信息失败";
            }
            return rd;
        }

        public ResponseData DeleteDeviceType(DeviceTypeViewModel dtvm)
        {
            ResponseData rd = new ResponseData();
            //验证用户权限，只有管理员才能处理
            UserService us = new UserService();
            bool bRet = us.IsAdmin(dtvm.Account, dtvm.Token);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限删除设备类型信息";
            }
            DeviceTypeModel dtm = _dtr.Find(dtvm.Id);

            try
            {
                _dtr.Remove(dtm);
                rd.Success = true;
                rd.Message = "删除设备类型信息成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备类型信息失败";
            }
            return rd;
        }
    }
}
