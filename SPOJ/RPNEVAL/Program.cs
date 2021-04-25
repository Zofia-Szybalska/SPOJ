using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace RPNEVAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            while (true)
            {
                string line;
                bool isError = false;
                double number1, number2;
                Stack<double> numbers = new Stack<double>();
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                string[] characters = line.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < characters.Length; ++i)
                {
                    if (Double.TryParse(characters[i], out double number))
                    {
                        numbers.Push(number);
                    }
                    else if (numbers.Count() < 2)
                    {
                        isError = true;
                        break;
                    }
                    else if (characters[i] == "/")
                    {
                        number1 = numbers.Pop();
                        number2 = numbers.Pop();
                        numbers.Push(number2 / number1);
                    }
                    else if (characters[i] == "*")
                    {
                        number1 = numbers.Pop();
                        number2 = numbers.Pop();
                        numbers.Push(number2 * number1);
                    }
                    else if (characters[i] == "-")
                    {
                        number1 = numbers.Pop();
                        number2 = numbers.Pop();
                        numbers.Push(number2 - number1);
                    }
                    else if (characters[i] == "+")
                    {
                        number1 = numbers.Pop();
                        number2 = numbers.Pop();
                        numbers.Push(number2 + number1);
                    }
                }
                if (isError || numbers.Count() != 1)
                {
                    Console.WriteLine("ERROR");
                }
                else
                {
                    Console.WriteLine(Math.Round(numbers.Peek(), 4));
                }
            }
        }
    }
}
