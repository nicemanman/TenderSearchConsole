using Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Views
{
    public interface ITenderSearchConsoleView : IConsoleView
    {
        event Action LeftArrowPressed;
        event Action RightArrowPressed;
        event Action Restart;
    }
}
