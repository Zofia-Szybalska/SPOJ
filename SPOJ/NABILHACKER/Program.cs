using System;
using System.Collections.Generic;
using System.Text;

namespace NABILHACKER {
    class Program {
        static void Main(string[] args) {
            var sb = new StringBuilder();
            int numberOfCases = int.Parse(Console.ReadLine());
            string keyLog = "";
            string passwordString = "";
            List<char> password = new List<char>();
            int index = 0;
            for (int i = 0; i < numberOfCases; i++) {
                keyLog = Console.ReadLine();
                index = 0;
                passwordString = "";
                password.Clear();
                for (int j = 0; j < keyLog.Length; j++) {
                    if (keyLog[j] == '<') {
                        index--;
                        if(j + index >= 0) {
                            index--;
                        }
                    }
                    else if (keyLog[j] == '>') {
                        if (j + index <= password.Count - 1) {
                            index++;
                        }
                        index--;
                    }
                    else if (keyLog[j] == '-') {
                        index--;
                        if (j + index >= 0) {
                            password.RemoveAt(j + index);
                            index--;
                        }
                    }
                    else {
                        password.Insert(j + index, keyLog[j]);
                    }
                }
                foreach(char charachter in password) {
                    passwordString += charachter;
                }
                sb.AppendLine(passwordString.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
