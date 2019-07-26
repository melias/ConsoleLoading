using System;
using System.Threading;

namespace App
{
    internal class Program
    {
        internal static void ClearLines()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        private static string LoadingCircle(int currently)
        {
            if (currently == 0)
                return " | ";
            switch (currently)
            {
                case 1: return " / ";
                case 2: return " - ";
                case 3: return " \\ ";
                case 4: return " | ";
                case 5: return " / ";
                case 6: return " - ";
                case 7: return " \\ ";
            }
            return string.Empty;
        }

        private static string LoadingProgressBar(int currently, int onePorcent)
        {
            var itens = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            var currentlyPorcent = currently / onePorcent;
            var oneChar = "█";
            for (int i = 0; i < currentlyPorcent; i++)
            {
                if (i == 0)
                {
                    itens[0] = oneChar;
                }
                else
                if (i % 10 == 0)
                {
                    var index = i / 10;
                    itens[index] = oneChar;
                }
            }
            return $"{string.Join("", itens)} {currentlyPorcent:000}%";
        }

        private static void Main(string[] args)
        {
            var numberChoise = string.Empty;

            do
            {
                ClearLines();
                MainScreen();
                numberChoise = Console.ReadLine();
                switch (numberChoise)
                {
                    case "1":
                        ClearLines();
                        TestLoading();
                        numberChoise = "2";
                        break;

                    default:
                        ClearLines();
                        MainScreen();
                        break;
                }
            } while (numberChoise != "2");

            Console.WriteLine($"");
            Console.WriteLine($"Done!");
            Console.WriteLine($"Press any key to exit...");
            Console.Read();
        }

        private static void MainScreen()
        {
            Console.WriteLine("Choise and press enter: ");
            Console.WriteLine(" - 1 to Test Loading");
            Console.WriteLine(" - 2 to Exit");
            Console.Write(": ");
        }

        private static void TestLoading()
        {
            ClearLines();
            var load = 0;
            for (int i = 0; i < 1001; i++)
            {
                ClearLines();
                Console.WriteLine($"{i:0000} {LoadingCircle(load)} {LoadingProgressBar(i, 10)}");
                Thread.Sleep(50);
                load++;
                if (load == 8)
                    load = 0;
            }
        }
    }
}