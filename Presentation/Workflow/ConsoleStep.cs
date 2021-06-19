using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Workflow
{
    public class ConsoleStep : IConsoleStep
    {
        public ConsoleStep(Func<Task> Function, Dictionary<int, MenuItem> menuItems)
        {
            this.Function = Function;
            this.menuItems = menuItems;
        }
        public Func<Task> Function {get;}

        public Dictionary<int, MenuItem> menuItems { get; }
    }
}
