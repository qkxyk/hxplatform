using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
  public  interface IProject:IBase<ProjectModel>
    {
        ProjectModel Find(int id);
    }
}
