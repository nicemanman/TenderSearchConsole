using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Common
{
    public interface IContainer
    {
        void Register<TService, TImplementation>(string serviceName = null) where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>(string serviceName = null);
        bool IsRegistered<TService>(string serviceName = null);
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}
