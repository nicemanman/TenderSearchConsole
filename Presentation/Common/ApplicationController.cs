
using Core;
using DomainModel.Requests;
using DomainModel.RestClients;
using DomainModel.Services;
using DomainModel.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Common
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;
        private static ApplicationController instance;

        /// <summary>
        /// Получить контейнер с зависимостями
        /// </summary>
        public static ApplicationController Current
        {
            get
            {
                if (instance == null)
                    instance = new ApplicationController(LightInjectContainer.Current);

                instance
                .RegisterService<IService, Service>()
                .RegisterService<ITenderService, TenderService>()
                .RegisterService<IService, TenderService>(ServiceNames.TenderService)
                .RegisterService<INetClient, TenderNetClient>(ServiceNames.TenderService)
                ;
                
                return instance;
            }
        }
        public static IContainer ContainerInstance
        {
            get => Current._container;
        }
        private ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IConsoleView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IApplicationController RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }


        public IApplicationController RegisterService<TModel, TImplementation>(string serviceName = null)
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>(serviceName);
            return this;
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();
            //Просто получаем презентер и раним его
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();
        }

        public async Task Run<TPresenter, TArgument>(TArgument argumnent) where TPresenter : class, IPresenter<TArgument>
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();

            var presenter = _container.Resolve<TPresenter>();
            await presenter.Run(argumnent);
        }
    }
}
