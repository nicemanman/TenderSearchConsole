using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients.Queries
{
    public class TenderGetRequestModel : RequestModel
    {
        /// <summary>
        /// Номер тендера
        /// </summary>
        public string Id { get; set; } = "1763198";

        /// <summary>
        /// Сколько элементов должно быть на странице
        /// </summary>
        public int itemsPerPage { get; set; } = 10;

        /// <summary>
        /// Номер страницы которую необходимо получить
        /// </summary>
        public int page { get; set; } = 1;
    }
}
