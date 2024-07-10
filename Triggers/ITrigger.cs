using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers
{
    /// <summary>
    /// Основной интерфейс триггера
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        /// Состояние (On - сработал, Off - не сработал)
        /// </summary>
        TriggerState State { get; }
        /// <summary>
        /// Начать прослушивание триггера
        /// </summary>
        void StartListening();
        /// <summary>
        /// Остановить прослушивание триггера
        /// </summary>
        void StopListening();

        /// <summary>
        /// Сбросить триггер
        /// </summary>
        /// <param name="isStart">начать прослушивание по сбросу</param>
        void Reset(bool isStart = true);

        /// <summary>
        /// Событие изменения состояния триггера
        /// </summary>
        event TriggerEventHandler TriggerStateChange;
    }
}
