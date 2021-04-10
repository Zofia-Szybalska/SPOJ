using System;
using System.Collections.Generic;
using System.Text;

namespace NABILHACKER3 {
    class Program {
        static void Main(string[] args) {
            var sb = new StringBuilder();
            int numberOfCases = int.Parse(Console.ReadLine());
            string keyLog, passwordString;
            int rightCount, leftCount;
            Stack<char> password = new Stack<char>(1000000);
            for(; numberOfCases > 0; numberOfCases--) {
                keyLog = Console.ReadLine();
                rightCount = 0;
                leftCount = 0;
                password = new Stack<char>();
                passwordString = "";
                for (int i = 0; i < keyLog.Length; i++) {
                    if (keyLog[i] == '>') {
                        if (password.Count != 0 && rightCount - leftCount < 0) {
                            rightCount++;
                        }
                        continue;
                    }
                    else if (keyLog[i] == '<') {
                        if (password.Count != 0 && Math.Abs(rightCount - leftCount) < (password.Count -1)) {
                            leftCount++;
                        }
                        continue;
                    }
                    else if (keyLog[i] == '-') {
                        if (password.Count == 0) {
                            continue;
                        }
                        else if (rightCount - leftCount >= 0) {
                            password.Pop();
                        }
                        else {
                            List<char> temp = new List<char>();
                            for (int j = rightCount - leftCount; j < 0; j++) {
                                temp.Add(password.Peek());
                                password.Pop();
                            }
                            password.Pop();
                            for (int j = temp.Count - 1; j >= 0; j--) {
                                password.Push(temp[j]);
                            }
                        }
                    }
                    else { 
                        if(rightCount-leftCount >= 0 || password.Count == 0) {
                            password.Push(keyLog[i]);
                        }
                        else {
                            Stack<char> temp = new Stack<char>();
                            for (long j = rightCount - leftCount; j < 0; j++) {
                                temp.Push(password.Peek());
                                password.Pop();
                            }
                            password.Push(keyLog[i]);
                            foreach(var item in temp) {
                                password.Push(item);
                            }
                        }
                    }
                }
                Stack<char> stack2 = new Stack<char>(password.ToArray());
                foreach (char letter in stack2) {
                    passwordString += letter;
                }
                sb.AppendLine(passwordString);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
