using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXCloud.Model
{
    public interface IProjectAffiliate : IBase<ProjectAffiliateModel>
    {
        ProjectAffiliateModel Find(int id);
        IEnumerable<ProjectAffiliateModel> FindBy(int projectId);
    }
}
