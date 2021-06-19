﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Workflow
{
    public interface IConsoleWorkflow
    {
        IConsoleStep CurrentConsoleStep { get; set; }
        bool Stop { get; set; }
        Task Execute();
        void Add(IConsoleStep step);
    }
}
