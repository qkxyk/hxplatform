using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.ModelView
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string Account { get; set; }
        public string Message { get; set; }
    }
}
