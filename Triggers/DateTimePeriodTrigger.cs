using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Triggers.Conditions;

namespace Triggers
{
    /// <summary>
    /// Условный триггер временного периода
    /// </summary>
    public sealed class DateTimePeriodTrigger : TriggerConditional
    {
        #region .ctor
        /// <summary>
        /// Создаёт триггер периода,
        /// при start <= DateTime.Now <= finish состояние триггера On,
        /// иначе Off
        /// </summary>
        /// <param name="start">Начало временного периода</param>
        /// <param name="finish">Конец временного периода</param>
        /// <param name="period">Частота опроса условий</param>
        /// <param name="isStart">При true начинается опрос условий</param>
        /// <exception cref="ArgumentException"></exception>
        public DateTimePeriodTrigger(DateTime start, DateTime finish, int period = 100, bool isStart = false) :
            base(new PeriodCondition(start,finish), period, isStart) 
        {
            if (start > finish)
                throw new ArgumentException("Start time need less Finish time.");
        }
        #endregion

        /// <summary>
        /// Условие временного периода
        /// </summary>
        protected class PeriodCondition : ConditionBase
        {
            public PeriodCondition(DateTime start, DateTime finish) : base() 
            {
                this
                    .And(() => DateTime.Now >= start)    //Начало периода
                    .And(() => DateTime.Now <= finish);  //Конец периода
            }

        }
    }
}
