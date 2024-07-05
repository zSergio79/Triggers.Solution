using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Triggers
{
    public interface IConditionTrigger : ITrigger
    {
        IConditionTrigger And(Func<bool> func);
        IConditionTrigger Or(Func<bool> func);

        IConditionTrigger Clear();
    }
}
