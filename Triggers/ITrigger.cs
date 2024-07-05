using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    public interface ITrigger
    {
        TriggerState State { get; }
        void StartListening();
        void StopListening();

        void Reset(bool isStart = true);

        event TriggerEventHandler TriggerStateChange;
    }
}
