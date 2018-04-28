using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public class DevicePanelTypeModel
    {
        public int Id { get; set; }

        public string Token { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public DateTime DT { get; set; }
        public virtual GroupModel Group { get; set; }
        public virtual ICollection<DevicePanelModel> DevicePanel { get; set; }
    }
}
