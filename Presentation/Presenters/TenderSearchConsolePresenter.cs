
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
            View.ParametersSelected += View_ParametersSelected;
            View.MenuRowSelected += View_MenuRowSelected;
            View_Restart();
        }

        private void View_MenuRowSelected(int obj)
        {

            if (workflow.CurrentConsoleStep.menuItems.TryGetValue(obj, out var menuItem)) 
            {
                if (menuItem.consoleStep != null) menuItem.consoleStep.Function();
                else menuItem.action?.Invoke();
            }
        }

        private void View_Restart()
        {
            View.ShowSuccessMessage("Добро пожаловать в программу для поиска тендеров!");
            //можно добавить любое количество шагов, поменять их местами
            
            var invokeTenderNumberStep = new ConsoleStep(InvokeTenderNumberInput,
                new Dictionary<int, MenuItem>()
                {
                    { 1, new MenuItem("Перейти на следующую страницу", GoToNextPage)},
                    { 2, new MenuItem("Перейти на предыдущую страницу", GoToPrevPage)},
                    { 3, new MenuItem("Перейти в начало", ()=> { View_Restart(); })}
                });

            var startStep = new ConsoleStep(InvokeTenderNumberInput,
                new Dictionary<int, MenuItem>()
                {
                    { 1, new MenuItem("Поиск тендера по номеру", invokeTenderNumberStep)}
                });

            workflow = new ConsoleWorkflow(new List<IConsoleStep>()
            {
                startStep, invokeTenderNumberStep
            });
            while (!workflow.Stop)
                workflow.Execute().Wait();
        }

        private void GoToNextPage() 
        {
        
        }

        private void GoToPrevPage() 
        {
        
        }

        private void View_ParametersSelected(Dictionary<string, object> obj)
        {
            Info = obj;
        }
        
        private Task InvokeTenderNumberInput()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("TenderNumber","Номер тендера (или его часть)");
            View.ShowMessage("Введите параметры (каждый параметр с новой строчки):");
            
            var index = 1;
            foreach (var parameter in parameters.Keys)
            {
                var paramName = parameters[parameter];
                View.ShowMessage($"{index}.{paramName}");
                index++;
            }
            View.InvokeInput(parameters.Keys.ToList());
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
