using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    /// <summary>
    /// Делегат события изменения состояния триггера
    /// </summary>
    /// <param name="sender">Триггер вызвавший событие</param>
    /// <param name="e">Аргумент события</param>
    public delegate void TriggerEventHandler(object sender, TriggerEventArgs e);
    /// <summary>
    /// Аргумент события изменения состояния триггера
    /// </summary>
    public class TriggerEventArgs : EventArgs
    {
        /// <summary>
        /// Состояние триггера
        /// </summary>
        public TriggerState State { get; set; }
    }
}
