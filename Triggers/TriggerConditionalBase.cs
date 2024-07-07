using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Triggers.Conditions;


namespace Triggers
{
    public abstract class TriggerConditionalBase : ITrigger
    {
        #region Conditions
        private ICondition condition;
        public virtual ICondition Condition { get => condition; set => condition = value; }
        #endregion

        #region Trigger State
        protected TriggerState _state = TriggerState.Off;
        public virtual TriggerState State
        {
            get => _state;
            set 
            {
                if (_state != value)
                {
                    _state = value;
                    TriggerStateChange?.Invoke(this, new TriggerEventArgs { State = value });
                }
            }
        }
        #endregion

        #region Events
        public event TriggerEventHandler? TriggerStateChange;
        #endregion

        #region .ctor
        protected TriggerConditionalBase(ICondition condition)
        {
            Condition = condition ?? throw new ArgumentNullException();
        }
        #endregion

        #region Trigger Control
        public abstract void Reset(bool isStart = false);

        public abstract void StartListening();

        public abstract void StopListening();
        #endregion
    }
}
