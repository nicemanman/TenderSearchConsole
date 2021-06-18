﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Workflow
{
    public interface IConsoleWorkflow
    {
        bool Stop { get; set; }
        Task Execute();
    }
}
