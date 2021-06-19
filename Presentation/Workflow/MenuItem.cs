using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Workflow
{
    public class MenuItem
    {
        public MenuItem(string Name, ConsoleStep step)
        {
            this.Name = Name;
            this.consoleStep = step;
        }
        public MenuItem(string Name, Action step)
        {
            this.Name = Name;
            this.action = step;
        }
        public string Name { get; }
        public ConsoleStep consoleStep;
        public Action action;
    }
}
