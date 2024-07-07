using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Triggers.Conditions;

namespace Triggers
{
    public sealed class DateTimePeriodTrigger : TriggerConditional
    {
        #region .ctor
        public DateTimePeriodTrigger(DateTime start, DateTime finish, int period = 100, bool isStart = false) : base(new PeriodCondition(start,finish), period, isStart) 
        {
            if (start > finish)
                throw new ArgumentException("Start time need less Finish time.");
        }
        #endregion

        protected class PeriodCondition : ConditionBase
        {
            public PeriodCondition(DateTime start, DateTime finish) : base() 
            {
                this
                    .And(() => DateTime.Now >= start)
                    .And(() => DateTime.Now <= finish);
            }

        }
    }
}
