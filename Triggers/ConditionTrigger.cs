using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    public class ConditionTrigger : ConditionTriggerBase, IDisposable
    {
        #region fields
        private readonly Timer _timer;
        private TimeSpan _period = TimeSpan.FromMilliseconds(100);
        #endregion

        #region .ctor
        public ConditionTrigger(int period = 100, bool isStart = false) : base() 
        {
            _period = TimeSpan.FromMilliseconds(period);
            _timer = new Timer(OnTick, null, Timeout.Infinite, period);
            if (isStart == true) 
                StartListening();
        }
        #endregion

        #region Trigger Tick
        private void OnTick(object? arg)
        {
            State = IsConditions() ? TriggerState.On : TriggerState.Off;
        }
        #endregion

        #region Trigger Control
        public override void Reset(bool isStart = true)
        {
            StopListening();
            State = TriggerState.Off;

            if (isStart == true)
                StartListening();
        }

        public override void StartListening()
        {
            _timer.Change(TimeSpan.Zero, _period);
        }

        public override void StopListening()
        {
            _timer.Change(Timeout.Infinite, _period.Milliseconds);
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
