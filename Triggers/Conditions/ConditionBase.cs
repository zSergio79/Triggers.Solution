using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers.Conditions
{
    public abstract class ConditionBase : ICondition
    {
        #region .ctor
        protected ConditionBase()
        {
            _andConditions = [];
            _orConditions = [];
        }
        #endregion

        #region Conditions Control
        protected IList<Func<bool>> _andConditions;
        protected IList<Func<bool>> _orConditions;
        public virtual ConditionBase And(Func<bool> func)
        {
            _andConditions.Add(func);
            return this;
        }

        public virtual ConditionBase Or(Func<bool> func)
        {
            _orConditions.Add(func);
            return this;
        }

        public virtual ConditionBase Clear()
        {
            _andConditions.Clear();
            _orConditions.Clear();
            return this;
        }
        #endregion

        #region ICondition

        public virtual bool IsSatisfied()
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
    }
}
