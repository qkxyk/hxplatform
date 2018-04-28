using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public class ClientListViewModel : ResponseBase
    {
        public ClientListViewModel()
        {
            list = new List<ClientViewModel>();
        }
        public List<ClientViewModel> list { get; set; }
    }
}
