using System;
using System.Collections.Generic;
using System.Text;

namespace CalcWhitStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string funny = "✔🤔👀";
            string expression = Console.ReadLine();
            var result = Evaluate(expression);

        }
        static double Evaluate(string expression)
        {
            string validSymbol = "+-*/";
            Stack<char> operators = new Stack<char>();
            Stack<double> numbers = new Stack<double>();

            for (int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];
                if (symbol == '(')
                {
                    operators.Push(symbol);
                }
                else if (symbol == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        char operat = operators.Pop();
                        double paramTwo = numbers.Pop();
                        double paramOne = numbers.Pop();
                        double newValue = ApplyOperation(operat, paramOne, paramTwo);
                        numbers.Push(newValue);
                    }

                    operators.Pop();
                }
                else if (validSymbol.Contains(symbol))
                {
                    while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(symbol))
                    {
                        char operat = operators.Pop();
                        double paramTwo = numbers.Pop();
                        double paramOne = numbers.Pop();
                        double newValue = ApplyOperation(operat, paramOne, paramTwo);
                        numbers.Push(newValue);
                    }

                    operators.Push(symbol);
                }
                else if (Char.IsDigit(symbol) || symbol == '.')
                {
                    StringBuilder number = new StringBuilder(); 
                    while (Char.IsDigit(symbol) || symbol == '.')
                    {
                        number.Append(symbol);
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }

                        symbol = expression[i];
                    }

                    i--;
                    numbers.Push(double.Parse(number.ToString()));
                }
            }

            while (operators.Count > 0)
            {
                char operat = operators.Pop();
                double paramTwo = numbers.Pop();
                double paramOne = numbers.Pop();
                double newValue = ApplyOperation(operat, paramOne, paramTwo);
                numbers.Push(newValue);
            }

            return numbers.Pop();
        }

        static double ApplyOperation(char operation, double operandOne, double operandTwo)
        {
            switch (operation)
            {
                case '+': return operandOne + operandTwo;
                case '-': return operandOne - operandTwo;
                case '*': return operandOne * operandTwo;
                case '/': return operandOne / operandTwo;
                default: return 0.0;
            }
        }

        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;
            }
        }
    }
}
