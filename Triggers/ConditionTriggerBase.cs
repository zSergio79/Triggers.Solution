using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Triggers
{
    public abstract class ConditionTriggerBase : IConditionTrigger
    {
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
        protected ConditionTriggerBase()
        {
            _andConditions = new List<Func<bool>>();
            _orConditions = new List<Func<bool>>();
        }
        #endregion

        #region Conditions Control
        protected IList<Func<bool>> _andConditions;
        protected IList<Func<bool>> _orConditions;
        public virtual IConditionTrigger And(Func<bool> func)
        {
            _andConditions.Add(func);
            return this;
        }

        public virtual  IConditionTrigger Or(Func<bool> func)
        {
            _orConditions.Add(func);
            return this;
        }

        public virtual IConditionTrigger Clear()
        {
            _andConditions.Clear();
            _orConditions.Clear();
            return this;
        }

        protected virtual bool IsConditions()
        {
            var result = false;
            if (_andConditions.Count > 0) 
            {
                result = _andConditions.All(t => t.Invoke());
            }
            if (_orConditions.Count > 0) 
            {
                result |= _orConditions.Any(t => t.Invoke());
            }
            return result;
        }
        #endregion

        #region Trigger Control
        public abstract void Reset(bool isStart = false);

        public abstract void StartListening();

        public abstract void StopListening();
        #endregion
    }
}
