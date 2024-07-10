using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers.Conditions
{
    /// <summary>
    /// Базовый класс условия
    /// </summary>
    public abstract class ConditionBase : ICondition
    {
        #region .ctor
        /// <summary>
        /// Создать условие
        /// </summary>
        protected ConditionBase()
        {
            _andConditions = [];
            _orConditions = [];
        }
        #endregion

        #region Conditions Control
        /// <summary>
        /// Список условий по 'И'
        /// </summary>
        protected IList<Func<bool>> _andConditions;
        /// <summary>
        /// Список условий по 'ИЛИ'
        /// </summary>
        protected IList<Func<bool>> _orConditions;
        /// <summary>
        /// Добавить условие по 'И'
        /// </summary>
        /// <param name="func">delegate проверки условия</param>
        /// <returns>self</returns>
        public virtual ConditionBase And(Func<bool> func)
        {
            _andConditions.Add(func);
            return this;
        }

        /// <summary>
        /// Добавить условие по 'ИЛИ'
        /// </summary>
        /// <param name="func">delegate проверки условия</param>
        /// <returns>self</returns>
        public virtual ConditionBase Or(Func<bool> func)
        {
            _orConditions.Add(func);
            return this;
        }

        /// <summary>
        /// Очистка условий
        /// </summary>
        /// <returns></returns>
        public virtual ConditionBase Clear()
        {
            _andConditions.Clear();
            _orConditions.Clear();
            return this;
        }
        #endregion

        #region ICondition
        /// <summary>
        /// Проверка условий
        /// </summary>
        /// <returns>true - условие выполняется, иначе false</returns>

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
