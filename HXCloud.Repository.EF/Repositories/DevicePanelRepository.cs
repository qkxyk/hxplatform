using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;

namespace HXCloud.Repository.EF.Repositories
{
    public class DevicePanelRepository
    {
        public void Add(DevicePanelModel entity)
        {
            using (var db = new HXContext())
            {
                db.DevicePanel.Add(entity);
                db.SaveChanges();
            }
        }
        public void Save(DevicePanelModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DevicePanelModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Remove(DevicePanelModel entity)
        {
            using (var db = new HXContext())
            {
                //删除相关的数据
                var ddd = db.DeviceDataDefine.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceDataDefine.RemoveRange(ddd);
                var di = db.DeviceImage.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceImage.RemoveRange(di);
                var dv = db.DeviceVideo.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceVideo.RemoveRange(dv);
                var dbd = db.DeviceBaseData.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceBaseData.RemoveRange(dbd);
                var dm = db.DeviceMap.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceMap.RemoveRange(dm);
                var dcd = db.DeviceControlData.Where(a => a.PanelId == entity.Id).ToList();
                db.DeviceControlData.RemoveRange(dcd);
                db.Entry<DevicePanelModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public DevicePanelModel Find(string deviceSn, int panelId)
        {
            using (var db = new HXContext())
            {
                var dpm = db.DevicePanel.Where(a => a.DeviceSn == deviceSn && a.Id == panelId).FirstOrDefault();
                return dpm;
            }
        }


    }
}
