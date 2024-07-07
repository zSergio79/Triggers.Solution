using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers.Conditions
{
    public interface ICondition
    {
        bool IsSatisfied();
    }
}
