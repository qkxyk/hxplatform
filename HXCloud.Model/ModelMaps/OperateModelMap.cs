using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;

namespace HXCloud.Model.ModelMaps
{
  public  class OperateModelMap:EntityTypeConfiguration<OperateModel>
    {
        public OperateModelMap()
        {
            ToTable("Operate").HasKey(a => a.Id);
        }
    }
}
