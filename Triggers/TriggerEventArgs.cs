using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    public delegate void TriggerEventHandler(object sender, TriggerEventArgs e);
    public class TriggerEventArgs : EventArgs
    {
        public TriggerState State { get; set; }
    }
}
