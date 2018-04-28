using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXCloud.Model;
using System.Data.Entity.ModelConfiguration;


namespace HXCloud.Model.ModelMaps
{
  public  class ClientModelMap:EntityTypeConfiguration<ClientModel>
    {
        public ClientModelMap()
        {
            ToTable("Client").HasKey(a=>a.Id);
            //1对多关系
            HasRequired(a => a.Group).WithMany(a => a.Client).HasForeignKey(a => a.Token).WillCascadeOnDelete(false);
        }
    }
}
