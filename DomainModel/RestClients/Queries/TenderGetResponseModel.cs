using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RestClients.Queries
{
    public class TenderGetResponseModel : RequestModel
    {
        /// <summary>
        /// Сколько всего найдено страниц
        /// </summary>
        public int totalpages { get; set; }
        /// <summary>
        /// Текущая страницы
        /// </summary>
        public int currpage { get; set; }
        /// <summary>
        /// Сколько всего записей найдено
        /// </summary>
        public int totalrecords { get; set; }
        /// <summary>
        /// Список тендеров
        /// </summary>
        public List<InvData> invData { get; set; } = new List<InvData>();
        
        
    }
    public class InvData 
    {

        /// <summary>
        /// Текущий статус
        /// </summary>
        public int TradeState { get; set; }

        /// <summary>
        /// Наименование статуса тендера
        /// </summary>
        public string TradeStateName { get; set; }

        /// <summary>
        /// Наименование заказчика
        /// </summary>
        public string CustomerFullName { get; set; }

        /// <summary>
        /// Наименование тендера
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// Номер тендера
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// НМЦ цена в рублях
        /// </summary>
        public decimal InitialPrice { get; set; }

        /// <summary>
        /// Дата окончания подачи заявок в UTC
        /// </summary>
        public string FillingApplicationEndDate { get; set; }
        public DateTime FillingApplicationEndDateTime 
        {
            get 
            {
                if (string.IsNullOrWhiteSpace(PublicationDate))
                {
                    return DateTime.Now;
                }
                var date = DateTime.Parse(FillingApplicationEndDate);
                //TODO: Приведение к текущему часовому поясу надо сделать более универсальным,
                //но не хватило времени
                return date.ToUniversalTime().AddHours(7);
            }
        }

        /// <summary>
        /// Дата публикации в UTC
        /// </summary>
        public string PublicationDate { get; set; }
        public DateTime PublicationDateTime 
        { 
            get
            {
                if (string.IsNullOrWhiteSpace(PublicationDate)) 
                {
                    return DateTime.Now;
                }
                var date = DateTime.Parse(PublicationDate);
                //TODO: Приведение к текущему часовому поясу надо сделать более универсальным,
                //но не хватило времени
                return date.ToUniversalTime().AddHours(7);
            } 
        }

        /// <summary>
        /// ID заказчика
        /// </summary>
        public int OrganizationID { get; set; }

        /// <summary>
        /// ID источника
        /// </summary>
        public int SourcePlatform { get; set; }

        /// <summary>
        /// Имя источника
        /// </summary>
        public string SourcePlatformName { get; set; }

        /// <summary>
        /// Документация тендера
        /// </summary>
        public List<documentation> documentation { get; set; }

        /// <summary>
        /// Извещение тендера
        /// </summary>
        public TenderNotice notice { get; set; } = new TenderNotice();
    }
    public class documentation
    {
        public string UploadDate { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
