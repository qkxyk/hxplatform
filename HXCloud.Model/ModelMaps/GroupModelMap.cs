using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HXCloud.Model;

namespace HXCloud.Model.ModelMaps
{
    public class GroupModelMap:EntityTypeConfiguration<GroupModel>
    {
        public GroupModelMap()
        {
            ToTable("Group").HasKey(a => a.Id);
        }
    }
}
