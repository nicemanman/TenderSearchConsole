
using DomainModel.Models;
using DomainModel.Requests;
using DomainModel.Requests.TenderServiceRequests;
using DomainModel.Responses;
using DomainModel.RestClients.Queries;
using DomainModel.Services.IServices;
using Presentation.Common;
using Presentation.Views;
using Presentation.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Presenters
{
    public class TenderSearchConsolePresenter : BasePresenter<ITenderSearchConsoleView>
    {
        
        private Dictionary<string, object> Info = new Dictionary<string, object>();

        private ConsoleWorkflow workflow;
        private readonly IService service;
        public TenderSearchConsolePresenter(IApplicationController controller, ITenderSearchConsoleView view, ITenderService service) : base(controller, view)
        {
            this.service = service;
            var response = service.GetTenderDocumentationAsync(new TenderGetRequest("1768199")).Result;
            if (response.IsValid && response is ITenderGetResponse tenderServiceGetResponse)
            {
                View.ShowSuccessMessage("Удачно получена информация от сервера");
            }
            else 
            {
                View.ShowErrorMessage(response.ValidationResult.Messages[0]);
            }
            View.ParametersSelected += View_ParametersSelected;

            //можно добавить любое количество шагов, поменять их местами
            workflow = new ConsoleWorkflow(new List<IConsoleStep>()
            {
                
            });
            while (!workflow.Stop)
                workflow.Execute().Wait();
        }

        private void View_ParametersSelected(Dictionary<string, object> obj)
        {
            Info = obj;
        }
        
        private Task InvokeParametersInput()
        {
            var parameters = new Response();
            View.ShowMessage("Введите параметры (каждый параметр с новой строчки):");
            if (!parameters.IsValid) 
            {
                ShowErrors(parameters.ValidationResult);
                return Task.CompletedTask;
            }
            var index = 1;
            foreach (var parameter in parameters.Info.Keys)
            {
                var paramName = parameters.Info[parameter];
                View.ShowMessage($"{index}.{paramName}");
                index++;
            }
            View.InvokeInput(parameters.Info.Keys.ToList());
            return Task.CompletedTask;
        }

        
        private void ShowErrors(ValidationResult result) 
        {
            foreach (var message in result.Messages)
            {
                View.ShowErrorMessage(message);
            }
        }
        
        
    }
}
