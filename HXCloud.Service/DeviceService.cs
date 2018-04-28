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
    public class DeviceService
    {
        DeviceRepository _dr;
        public DeviceService()
        {
            _dr = new DeviceRepository();
        }
        public DeviceViewModel DeviceAdd(DeviceViewModel dvm)
        {
            #region 验证用户是否有权限添加设备
            bool bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, dvm.ProjectId.Value, 3);
            if (!bRet)
            {
                dvm.Success = false;
                dvm.Message = "用户没有权限进行添加设备";
                return dvm;
            }
            #endregion

            #region 验证节点是否为叶子节点
            ProjectService ms = new ProjectService();
            bRet = ms.IsLeafProject(dvm.ProjectId.Value, dvm.Token);
            if (!bRet)
            {
                dvm.Success = false;
                dvm.Message = "非叶子节点不能添加设备";
                return dvm;
            }
            #endregion

            #region 验证在此节点下是否有此设备(同一个叶子节点下不允许设备重名)
            DeviceModel dm = _dr.Find(dvm.Token, dvm.DeviceName, dvm.ProjectId.Value);
            if (dm != null)
            {
                dvm.Success = false;
                dvm.Message = "此设备名称已存在";
                return dvm;
            }

            //验证设备编号是否重复(设备编号全局)
            dm = _dr.Find(dvm.DeviceSn, dvm.Token);
            if (dm != null)
            {
                dvm.Success = false;
                dvm.Message = "此设备已存在系统中";
                return dvm;
            }
            #endregion
            //获取项目的顶级编号
            int pid = new ProjectService().GetRootId(dvm.ProjectId.Value);
            #region 添加设备
            try
            {
                DeviceModel dmm = new DeviceModel();
                dmm.ProjectId = dvm.ProjectId;
                dmm.DeviceName = dvm.DeviceName;
                dmm.DeviceSn = Guid.NewGuid().ToString("N");
                dmm.DeviceNo = dvm.DeviceNo;
                dmm.TypeId = dvm.TypeId;
                dmm.Token = dvm.Token;
                dmm.ProductTime = DateTime.Now;
                dmm.UseTime = DateTime.Now;
                dmm.PId = pid;
                dmm.DeviceDescription = dvm.DeviceDescription;
                _dr.Add(dmm);
                dvm.Success = true;
                dvm.Message = "添加设备成功";
            }
            catch (Exception ex)
            {
                dvm.Success = false;
                dvm.Message = "添加设备失败 " + ex.Message;
                return dvm;
            }
            #endregion
            return dvm;
        }



        /// <summary>
        /// 查找项目下的设备列表
        /// </summary>
        /// <param name="token">组织标示</param>
        /// <param name="projectId">项目标示</param>
        public DeviceListViewModel FindMenuDevices(string token, int projectId, string userName)
        {
            DeviceListViewModel dlvm = new DeviceListViewModel();

            #region 验证用户是否有权限查看该节点
            bool bRet = new UserService().IsAuthProject(userName, token, projectId, 0);
            if (!bRet)
            {
                //用户没有权限查看 
                dlvm.Success = false;
                dlvm.Message = "用户没有权限查看该项目下的设备";
                return dlvm;
            }
            #endregion

            //查找节点信息

            List<ProjectModel> list = new List<ProjectModel>();
            //查找所有叶子节点
            list = FindMenu(projectId, token, list);
            foreach (var item in list)
            {
                List<DeviceModel> ldm = _dr.Find(item.Id, item.Token);
                foreach (var dm in ldm)
                {
                    DeviceViewModel dvm = new DeviceViewModel();
                    dvm.DeviceName = dm.DeviceName;
                    dvm.DeviceSn = dm.DeviceSn;
                    dvm.DeviceNo = dm.DeviceNo;
                    dvm.DeviceDescription = dm.DeviceDescription;
                    dvm.ProjectId = dm.ProjectId;
                    dvm.Token = dm.Token;
                    dvm.TypeId = dm.TypeId;
                    dvm.UseTime = dm.UseTime;
                    dvm.ProductTime = dm.ProductTime;
                    dlvm.list.Add(dvm);
                }
            }
            dlvm.Success = true;
            dlvm.Message = "获取该项目下的设备成功";
            return dlvm;
        }

        /// <summary>
        /// 递归查找所有叶子节点
        /// </summary>
        /// <param name="mm">节点数据</param>
        /// <returns>返回该节点下的所有叶子节点</returns>
        public List<ProjectModel> FindMenu(int projectId, string token, List<ProjectModel> lmm)
        {
            ProjectModel mm = new ProjectService().FindProject(projectId, token);
            List<ProjectModel> list = new List<ProjectModel>();
            if (mm.ProjectType != (ProjectType)2)
            {
                foreach (var item in mm.Child)
                {
                    list = FindMenu(item.Id, token, lmm);
                }
            }
            else
            {
                lmm.Add(mm);
            }
            return lmm;
        }

        public DeviceViewModel FindDevice(string account, string token, string deviceSn)
        {
            DeviceViewModel dvm = new DeviceViewModel();
            DeviceModel dm = FindDevice(deviceSn, token);
            if (dm == null)
            {
                dvm.Success = false;
                dvm.Message = "不存在该设备";
                return dvm;
            }
            dvm.Success = true;
            dvm.Message = "获取设备信息成功";
            dvm.ProjectId = dm.ProjectId;
            dvm.ProductTime = dm.ProductTime;
            dvm.UseTime = dm.UseTime;
            dvm.TypeId = dm.TypeId;
            dvm.DeviceName = dm.DeviceName;
            dvm.DeviceDescription = dm.DeviceDescription;
            dvm.DeviceSn = dm.DeviceSn;
            dvm.DeviceNo = dm.DeviceNo;
            return dvm;
        }

        public DeviceModel FindDevice(string deviceSn, string token)
        {
            DeviceModel dm = _dr.Find(deviceSn, token);
            return dm;
        }
        /// <summary>
        /// 获取设备的分组数据
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetDeviceGroupData(string token)
        {
            Dictionary<int, int> Dic = _dr.DeviceGroupType(token);
            return Dic;
        }

        public bool CheckDeviceAuth(DeviceModel dm, string account, string token, int type)
        {
            bool bRet = false;
            int pid = dm.PId;//获取设备所属的项目（一级项目）
            if (pid == 0)//设备没有添加所属的一级项目，此时需要递归获取一级项目编号
            {
                pid = dm.ProjectId.Value;
                bRet = new UserService().IsAuthProject(account, token, pid, type);//获取用户是否有权限修改设备信息
            }
            else
            {
                bRet = new UserService().IsAuthProject(account, token, pid, 2, 0);//获取用户是否有权限修改设备信息(此时的项目编号为一级项目编号)
            }
            return bRet;
        }

        //修改设备的基本信息
        public ResponseData UpdateDevice(DeviceViewModel dvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = _dr.Find(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "不存在此设备，请确认";
                return rd;
            }
            #region 验证用户权限
            bool bRet = false;
            int pid = dm.PId;//获取设备所属的项目（一级项目）
            if (pid == 0)//设备没有添加所属的一级项目，此时需要递归获取一级项目编号
            {
                pid = dm.ProjectId.Value;
                bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, pid, 2);//获取用户是否有权限修改设备信息
            }
            else
            {
                bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, pid, 2, 0);//获取用户是否有权限修改设备信息(此时的项目编号为一级项目编号)
            }
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备信息";
                return rd;
            }
            #endregion

            #region 修改设备信息
            dm.DeviceName = dvm.DeviceName;
            if (dm.DeviceNo != dvm.DeviceNo)//要修改设备编号在系统中是否存在
            {
                int count = _dr.FindByDeviceNo(dvm.DeviceNo, dvm.Token);
                if (count > 0)
                {
                    rd.Success = false;
                    rd.Message = "系统中已存在此设备编号，请确认";
                    return rd;
                }
            }
            dm.DeviceNo = dvm.DeviceNo;
            dm.TypeId = dvm.TypeId;
            dm.ProjectId = dvm.ProjectId;
            dm.DeviceDescription = dvm.DeviceDescription;
            pid = new ProjectService().GetRootId(dvm.ProjectId.Value);
            dm.PId = pid;
            try
            {
                _dr.Save(dm);
                rd.Success = true;
                rd.Message = "修改设备信息成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "修改设备信息失败" + ex.Message;
            }

            #endregion
            return rd;
        }
        //修改设备的位置信息
        public ResponseData UpdateDevicePosition(DeviceViewModel dvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = _dr.Find(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "不存在此设备，请确认";
                return rd;
            }
            #region 验证用户权限
            bool bRet = CheckDeviceAuth(dm, dvm.Account, dvm.Token, 2);
            //int pid = dm.PId;//获取设备所属的项目（一级项目）
            //if (pid == 0)//设备没有添加所属的一级项目，此时需要递归获取一级项目编号
            //{
            //    pid = dm.ProjectId.Value;
            //    bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, pid, 2);//获取用户是否有权限修改设备信息
            //}
            //else
            //{
            //    bRet = new UserService().IsAuthProject(dvm.Account, dvm.Token, pid, 2, 0);//获取用户是否有权限修改设备信息(此时的项目编号为一级项目编号)
            //}
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限修改设备位置信息";
                return rd;
            }
            #endregion
            #region 修改设备的位置信息
            dm.Position = dvm.Position;
            try
            {
                _dr.Save(dm);
                rd.Success = true;
                rd.Message = "修改设备位置信息成功";
            }
            catch (Exception ex)
            {
                rd.Success = false;
                rd.Message = "修改设备位置信息失败" + ex.Message;
            }
            #endregion
            return rd;
        }
        //删除设备
        public ResponseData DeleteDevice(DeviceViewModel dvm)
        {
            ResponseData rd = new ResponseData();
            //获取设备信息
            DeviceModel dm = _dr.Find(dvm.DeviceSn, dvm.Token);
            if (dm == null)
            {
                rd.Success = false;
                rd.Message = "不存在此设备，请确认";
                return rd;
            }
            #region 验证用户权限
            bool bRet = CheckDeviceAuth(dm, dvm.Account, dvm.Token, 2);
            if (!bRet)
            {
                rd.Success = false;
                rd.Message = "用户没有权限删除设备";
                return rd;
            }
            #endregion
            //删除设备，连带删除设备的其他信息
            try
            {
                _dr.Remove(dvm.DeviceSn);
                rd.Success = true;
                rd.Message = "删除设备成功";
            }
            catch (Exception)
            {
                rd.Success = false;
                rd.Message = "删除设备失败";
            }
            return rd;
        }
    }

}
