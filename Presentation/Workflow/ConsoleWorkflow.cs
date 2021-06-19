using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Workflow
{
    public class ConsoleWorkflow : IConsoleWorkflow
    {
        private readonly List<IConsoleStep> steps;
        public ConsoleWorkflow(List<IConsoleStep> steps)
        {
            this.steps = steps;
        }
        public bool Stop { get; set; } = false;
        public IConsoleStep CurrentConsoleStep { get; set; }
        public int CurrentConsoleStepIndex { get; set; }
        public async Task Execute()
        {
            int index = 0;
            if (!Stop)
                foreach (var step in steps)
                {
                    CurrentConsoleStep = step;
                    CurrentConsoleStepIndex = index;
                    index++;

                    await step.Function?.Invoke();
                }
        }

        public void Add(IConsoleStep step) 
        {
            steps.Insert(CurrentConsoleStepIndex, step);
        }
    }
}
