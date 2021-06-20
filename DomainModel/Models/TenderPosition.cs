using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class TenderPosition
    {
        /// <summary>
        /// Наименование позиции
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// Цена за лот
        /// </summary>
        public string Price { get; set; }
    }
}
