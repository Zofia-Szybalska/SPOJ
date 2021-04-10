using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NABILHACKER2 {
    class Program {
        static void Main(string[] args) {
            var sb = new StringBuilder();
            int numberOfCases = int.Parse(Console.ReadLine());
            string keyLog;
            LinkedList<char> password = new LinkedList<char>();
            Stack<char> tempPasswordEnd = new Stack<char>();
            for (; numberOfCases > 0; numberOfCases--){
                keyLog = Console.ReadLine();
                password.Clear();
                tempPasswordEnd.Clear();
                for (int i = 0; i< keyLog.Length; i++) {
                    if (keyLog[i] == '>') {
                        if (tempPasswordEnd.Count != 0) {
                            password.AddLast(tempPasswordEnd.Peek());
                            tempPasswordEnd.Pop();
                        }
                    }
                    else if (keyLog[i] == '<') {
                        if (password.Count != 0) {
                            tempPasswordEnd.Push(password.Last());
                            password.RemoveLast();
                        }
                    }
                    else if (keyLog[i] == '-') {
                        if (password.Count != 0) {
                            password.RemoveLast(); 
                        }
                    }
                    else {
                        password.AddLast(keyLog[i]);
                    }
                }
                foreach (char charachter in password) {
                    sb.Append(charachter);
                }
                if (tempPasswordEnd.Count != 0) {
                    foreach(var letter in tempPasswordEnd) {
                        sb.Append(letter);
                    }
                }
                sb.AppendLine("");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
