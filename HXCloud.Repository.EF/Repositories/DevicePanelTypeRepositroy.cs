using HXCloud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Repository.EF.Repositories
{
    public class DevicePanelTypeRepositroy
    {
        public void Add(DevicePanelTypeModel entity)
        {
            using (var db = new HXContext())
            {
                db.DevicePanelType.Add(entity);
                db.SaveChanges();
            }
        }
        public void Save(DevicePanelTypeModel entity)
        {
            using (var db = new HXContext())
            {
                db.Entry<DevicePanelTypeModel>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Remove(DevicePanelTypeModel entity)
        {
            using (var db = new HXContext())
            {
                //删除相关的数据
                var dp = db.DevicePanel.Where(a => a.TypeId == entity.Id).ToList();
                foreach (var item in dp)
                {
                    var ddd = db.DeviceDataDefine.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceDataDefine.RemoveRange(ddd);
                    var di = db.DeviceImage.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceImage.RemoveRange(di);
                    var dv = db.DeviceVideo.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceVideo.RemoveRange(dv);
                    var dbd = db.DeviceBaseData.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceBaseData.RemoveRange(dbd);
                    var dm = db.DeviceMap.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceMap.RemoveRange(dm);
                    var dcd = db.DeviceControlData.Where(a => a.PanelId == item.Id).ToList();
                    db.DeviceControlData.RemoveRange(dcd);
                }
                db.DevicePanel.RemoveRange(dp);
                db.Entry<DevicePanelTypeModel>(entity).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public IEnumerable<DevicePanelTypeModel> Find(string token)
        {
            using (var db = new HXContext())
            {
                var dpt = db.DevicePanelType.Where(a => a.Token == token).ToList();
                return dpt;
            }
        }
        public IEnumerable<DevicePanelTypeModel> Find()
        {
            using (var db = new HXContext())
            {
                var dpt = db.DevicePanelType.ToList();
                return dpt;
            }
        }
        public DevicePanelTypeModel Find(int panelId)
        {
            using (var db = new HXContext())
            {
                var dpm = db.DevicePanelType.Where(a => a.Id == panelId).FirstOrDefault();
                return dpm;
            }
        }
    }
}
