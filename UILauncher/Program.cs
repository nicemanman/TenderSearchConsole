using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace UILauncher
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var controller = ApplicationController.Current;
            controller.RegisterView<ITenderSearchView, MainView>();
            controller.RegisterInstance(new ApplicationContext());
            controller.Run<TenderSearchPresenter>();
        }
    }
}
