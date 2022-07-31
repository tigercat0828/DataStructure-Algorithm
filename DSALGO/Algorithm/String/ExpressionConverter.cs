using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSALGO.Algorithm.String {
    public static class ExpressionConverter {
        private static int prec(char c) {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/') return 2;
            if (c == '^') return 3;
            return -1;
        }
        public static string Infix2Postfix(string infix) {
            
            string result = "";
            Stack<char> stack = new();
            
            for (int i = 0; i < infix.Length; i++) {
                char c = infix[i];
                
                if ("+-*/^".Contains(c)) {      // case : operator
                    while (stack.Count > 0 && prec(c) <= prec(stack.Peek())) {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }

                else if (c == '(') {            // case : ()
                    stack.Push('(');
                }
                else if (c == ')') {
                    while (stack.Count > 0 && stack.Peek() != '(') {
                        result += stack.Pop();
                    }
                    stack.Pop();
                }
                else {          // char.IsLetterOrDigit(c)
                    result += c;
                }
            }
            while (stack.Count > 0) {           // add the remain to ouput
                result += stack.Pop();
            }
            return result;
        }
        public static string Infix2Prefix(string infix) {
            throw new NotImplementedException();
        }   
        public static string Postfix2Infix(string postfix) {
            throw new NotImplementedException();
        }
        public static string Prefix2Infix(string prefix) {
            throw new NotImplementedException();
        }
    }
}