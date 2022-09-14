namespace DSALGO.Algorithm.String {
    public static class ExpressionConverter {
        private static int prec(char c) {
            if (c == '+' || c == '-') return 1;
            if (c == '*' || c == '/' || c == '%') return 2;
            if (c == '^') return 3;
            return -1;
        }
        private static bool IsOperator(char c) {
            return "+-*/^".Contains(c);
        }
        public static bool IsLetterOrDigit(char c) {
            return char.IsLetterOrDigit(c);
        }
        public static string Infix2Postfix(string infix) {

            string result = "";
            Stack<char> stack = new();

            for (int i = 0; i < infix.Length; i++) {
                char c = infix[i];

                if (IsOperator(c)) {
                    while (stack.Count > 0 && prec(c) <= prec(stack.Peek())) {
                        result += stack.Pop();
                    }
                    stack.Push(c);
                }
                else if (IsLetterOrDigit(c)) result += c;

                else if (c == '(') stack.Push('(');

                else if (c == ')') {
                    while (stack.Count > 0 && stack.Peek() != '(') {
                        result += stack.Pop();
                    }
                    if (stack.Count > 0 && stack.Peek() != '(') {
                        return "Invalid Infix Expression";
                    }
                    else {
                        stack.Pop();
                    }
                }
                else {
                    return "Invalid Infix Expression";
                }
            }
            while (stack.Count > 0) {           // add the remain to ouput
                result += stack.Pop();
            }
            return result;
        }
        public static string Infix2Prefix(string infix) {
            string rstr = ReverseString(infix);
            string tmp = Infix2Postfix(rstr);
            return ReverseString(tmp);
        }
        public static string Postfix2Infix(string postfix) {
            Stack<string> stack = new();
            for (int i = 0; i < postfix.Length; i++) {
                char c = postfix[i];
                if (IsLetterOrDigit(c)) stack.Push(c.ToString());
                if (IsOperator(c)) {
                    string oprt2 = stack.Pop();
                    string oprt1 = stack.Pop();
                    stack.Push($"({oprt1}{c}{oprt2})");
                }
            }
            return stack.Peek();
        }
        public static string Prefix2Infix(string prefix) {
            string rstr = ReverseString(prefix);
            Stack<string> stack = new();
            for (int i = 0; i < rstr.Length; i++) {
                char c = rstr[i];
                if (IsLetterOrDigit(c)) stack.Push(c.ToString());
                if (IsOperator(c)) {
                    string oprt1 = stack.Pop();
                    string oprt2 = stack.Pop();
                    stack.Push($"({oprt1}{c}{oprt2})");
                }
            }
            return stack.Peek();
        }
        public static int CalcPostfix(string postfix) {
            Stack<int> stack = new();
            for (int i = 0; i < postfix.Length; i++) {
                char c = postfix[i];
                if (IsLetterOrDigit(c)) {
                    stack.Push(c - '0');
                }
                else if (IsOperator(c)) {
                    int oprt2 = stack.Pop();
                    int oprt1 = stack.Pop();
                    if (c == '+') stack.Push(oprt1 + oprt2);
                    else if (c == '-') stack.Push(oprt1 - oprt2);
                    else if (c == '*') stack.Push(oprt1 * oprt2);
                    else if (c == '/') stack.Push(oprt1 / oprt2);
                    else if (c == '%') stack.Push(oprt1 % oprt2);
                    else if (c == '^') stack.Push((int)Math.Pow(oprt1, oprt2));
                }
            }
            return stack.Peek();
        }
        public static int CalcPrefix(string prefix) {
            throw new NotImplementedException();
        }
        private static string ReverseString(string s) {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            for (int i = 0; i < chars.Length; i++) {
                if (chars[i] == ')') chars[i] = '(';
                else if (chars[i] == '(') chars[i] = ')';
            }
            return new string(chars);
        }
    }
}