using System;
using System.Collections.Generic;
using System.Text;

namespace NABILHACKER4
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            int numberOfCases = int.Parse(Console.ReadLine());
            string keyLog;
            Stack<char> password = new Stack<char>();
            Stack<char> tempPasswordEnd = new Stack<char>();
            for (; numberOfCases > 0; numberOfCases--)
            {
                keyLog = Console.ReadLine();
                password.Clear();
                tempPasswordEnd.Clear();
                for (int i = 0; i < keyLog.Length; i++)
                {
                    if (keyLog[i] == '>')
                    {
                        if (tempPasswordEnd.Count != 0)
                        {
                            password.Push(tempPasswordEnd.Peek());
                            tempPasswordEnd.Pop();
                        }
                    }
                    else if (keyLog[i] == '<')
                    {
                        if (password.Count != 0)
                        {
                            tempPasswordEnd.Push(password.Peek());
                            password.Pop();
                        }
                    }
                    else if (keyLog[i] == '-')
                    {
                        if (password.Count != 0)
                        {
                            password.Pop();
                        }
                    }
                    else
                    {
                        password.Push(keyLog[i]);
                    }
                }
                Stack<char> reversedPassword = new Stack<char>(password.ToArray());
                foreach (char charachter in reversedPassword)
                {
                    sb.Append(charachter);
                }
                if (tempPasswordEnd.Count != 0)
                {
                    foreach (var charachter in tempPasswordEnd)
                    {
                        sb.Append(charachter);
                    }
                }
                sb.AppendLine("");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
