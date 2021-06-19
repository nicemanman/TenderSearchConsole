﻿using Presentation.Common;
using Presentation.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public abstract class BaseScreen : IView
    {
        public event Action<Dictionary<string, object>> ParametersSelected;
        public event Action<int> MenuRowSelected;

        public void Close(IView nextView)
        {
            Console.Clear();
        }

        public void InvokeInput(List<string> parametersNames)
        {
            var dict = new Dictionary<string, object>();
            foreach (var name in parametersNames)
            {
                var value = Console.ReadLine();
                dict.Add(name, value);
            }
            ParametersSelected?.Invoke(dict);
        }

        public virtual void Show() 
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Ошибка: "+errorMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Исключение:\n"+ex.StackTrace);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void ShowSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void InvokeMenuInput()
        {
            bool menuRowSelected = false;
            int menuRowNumber = 0;
            while (!menuRowSelected)
            {
                Console.WriteLine();
                Console.WriteLine("Введите номер пункта меню");
                string menuRowNumberString = Console.ReadLine();
                if (!int.TryParse(menuRowNumberString, out var integerMenuRowNumber))
                {
                    Console.WriteLine("Введен некорректный номер пункта меню, попробуйте еще раз");
                }
                else
                {
                    menuRowSelected = true;
                    menuRowNumber = integerMenuRowNumber;
                }
            }
            if (menuRowSelected)
            {
                MenuRowSelected?.Invoke(menuRowNumber);
            }
        }
    }
}
