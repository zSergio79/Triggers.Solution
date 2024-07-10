using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggers.Conditions
{
    /// <summary>
    /// Условие
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Проверка выполнения условий
        /// </summary>
        /// <returns>true, если условие выполняется, иначе false</returns>
        bool IsSatisfied();
    }
}
