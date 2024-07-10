using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Triggers.Conditions;


namespace Triggers
{
    /// <summary>
    /// Базовый класс для триггеров
    /// </summary>
    public abstract class TriggerConditionalBase : ITrigger
    {
        #region Conditions
        /// <summary>
        /// Условия срабатывания триггера
        /// </summary>
        private ICondition condition;
        public virtual ICondition Condition { get => condition; set => condition = value; }
        #endregion

        #region Trigger State
        /// <summary>
        /// Состояние триггера.
        /// Изменение вызовет событие TriggerStateChange
        /// </summary>
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
        /// <summary>
        /// Создаёт условный триггер
        /// </summary>
        /// <param name="condition">Условия срабатывания триггера</param>
        /// <exception cref="ArgumentNullException">При condition == null</exception>
        protected TriggerConditionalBase(ICondition condition)
        {
            Condition = condition ?? throw new ArgumentNullException();
        }
        #endregion

        #region Trigger Control
        /// <summary>
        /// Сброс состояния триггера
        /// </summary>
        /// <param name="isStart">если true, начинается прослушивание условий</param>
        public abstract void Reset(bool isStart = false);

        /// <summary>
        /// Начать проверку условий срабатывания триггера
        /// </summary>
        public abstract void StartListening();

        /// <summary>
        /// Остановить проверку условий срабатывания триггера
        /// </summary>
        public abstract void StopListening();
        #endregion
    }
}
