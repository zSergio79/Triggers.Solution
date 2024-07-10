using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Triggers.Conditions;

namespace Triggers
{
    /// <summary>
    /// Условный триггер
    /// </summary>
    public class TriggerConditional : TriggerConditionalBase, IDisposable
    {
        #region fields
        /// <summary>
        /// Таймер для проверки выполнения условий триггера
        /// </summary>
        private readonly Timer _timer;
        /// <summary>
        /// Период проверки условий
        /// </summary>
        private TimeSpan _period = TimeSpan.FromMilliseconds(100);
        #endregion

        #region .ctor
        /// <summary>
        /// Создаёт условный триггер
        /// </summary>
        /// <param name="condition">Условия срабатывания триггера</param>
        /// <param name="period">Период проверки условий</param>
        /// <param name="isStart">Если true, начинается немедленная проверка условий</param>
        public TriggerConditional(ICondition condition, int period = 100, bool isStart = false) : base(condition) 
        {
            _period = TimeSpan.FromMilliseconds(period);
            _timer = new Timer(OnTick, null, Timeout.Infinite, period);
            if (isStart == true) 
                StartListening();
        }
        #endregion

        #region Trigger Tick
        /// <summary>
        /// Проверка условий срабатывания триггера
        /// </summary>
        /// <param name="arg"></param>
        private void OnTick(object? arg)
        {
            State = Condition.IsSatisfied() ? TriggerState.On : TriggerState.Off;
        }
        #endregion

        #region Trigger Control
        /// <summary>
        /// Сброс состояния триггера
        /// </summary>
        /// <param name="isStart">Если true, начинается немедленная проверка условий</param>
        public override void Reset(bool isStart = true)
        {
            StopListening();
            State = TriggerState.Off;

            if (isStart == true)
                StartListening();
        }

        /// <summary>
        /// Начать проверку условий
        /// </summary>
        public override void StartListening()
        {
            _timer.Change(TimeSpan.Zero, _period);
        }

        /// <summary>
        /// Остановить проверку условий
        /// </summary>
        public override void StopListening()
        {
            _timer.Change(Timeout.Infinite, _period.Milliseconds);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Освободить ресурсы
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освободить ресурсы, ибо Timer
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_timer != null) _timer.Dispose();
            }
        }
        #endregion
    }
}
