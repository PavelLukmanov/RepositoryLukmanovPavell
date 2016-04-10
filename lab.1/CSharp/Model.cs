using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{   /// <summary>
/// Представляет общую информацию о любом виде транспорта
/// </summary>
    public interface IVehicle
    {   
        /// <summary>
        /// Название транспорта
        /// </summary>
        
        string ModelName { set; get; }
        /// <summary>
        /// Год выпуска
        /// </summary>
        int DateOfManufacture { set; get; }
        /// <summary>
        /// Пробег
        /// </summary>
        int Distance { set; get; }
        /// <summary>
        /// методы для расчета расхода топлива
        /// </summary>
        /// <param name="Distance">Расстояние</param>
        /// <returns>количество топлива</returns>
        int GoTheDistance(int Distance);
      
    }
}
