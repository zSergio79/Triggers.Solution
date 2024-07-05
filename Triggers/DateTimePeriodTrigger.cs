using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    public sealed class DateTimePeriodTrigger : ConditionTrigger
    {
        #region .ctor
        public DateTimePeriodTrigger(DateTime start, DateTime finish, int period = 100, bool isStart = false) : base(period, isStart) 
        {
            if (start > finish)
                throw new ArgumentException("Start time need less Finish time.");
            this
                .And(() => DateTime.Now >= start)
                .And(() => DateTime.Now <= finish);
        }
        #endregion
    }
}
