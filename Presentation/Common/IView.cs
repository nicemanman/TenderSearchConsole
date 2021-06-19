
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Common
{
    public interface IView
    {
        void Wait(string text);
        void Wait(Progress<string> progres);
        void StopWaiting();
        void Show();
        void Close();
    }
}
