using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Repository.EF.Repositories;
using HXCloud.ModelView;
using HXCloud.Model;

namespace HXCloud.Service
{
    //面板类型对外只提供获取全部面板类型的接口
    public class DevicePanelTypeService
    {
        private DevicePanelTypeRepositroy _dptr;
        public DevicePanelTypeService()
        {
            _dptr = new DevicePanelTypeRepositroy();
        }
        //所有注册的用户可见
        public DevicePanelTypeListViewModel Get(string account, string token)
        {
            DevicePanelTypeListViewModel dtlvm = new DevicePanelTypeListViewModel();
            if (account == null || null == token)
            {
                dtlvm.Success = false;
                dtlvm.Message = "只用登录用户才能查看";
                return dtlvm;
            }
            IEnumerable<DevicePanelTypeModel> list = _dptr.Find();
            foreach (var item in list)
            {
                DevicePanelTypeViewModel dtvm = new DevicePanelTypeViewModel()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                dtlvm.list.Add(dtvm);
            }
            dtlvm.Success = true;
            dtlvm.Message = "获取设备面板类型成功";
            return dtlvm;
        }
    }
}
