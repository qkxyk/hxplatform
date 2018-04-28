using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class DevicePanelTypeViewModel:ResponseBase
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public DateTime DT { get; set; }
    }
}
