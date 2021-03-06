﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
   public class DeviceControlDataModelMap:EntityTypeConfiguration<DeviceControlDataModel>
    {
        public DeviceControlDataModelMap()
        {
            ToTable("DeviceControlData").HasKey(a => a.Id);

            //1对多关系
            HasRequired(a => a.Device).WithMany(a => a.DeviceControlData).HasForeignKey(a => a.DeviceSn);
            HasRequired(a => a.DevicePanel).WithMany(a => a.DeviceControlData).HasForeignKey(a => a.PanelId);
            HasRequired(a => a.DeviceDataDefine).WithMany(a => a.DeviceControl).HasForeignKey(a => a.DataDefineId);
        }
    }
}
