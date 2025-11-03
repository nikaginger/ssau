using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение: ");
        string romanExpression = Console.ReadLine();
        romanExpression = romanExpression.Replace(" ", "");
        string romanExpression2 = AddGapByArtemFadeev(romanExpression);
        string arabicExpression = ConvertRomanToArabic(romanExpression2);
        string expression = ToPostFix(arabicExpression);
        Console.WriteLine(GetValue(expression));
        Console.ReadLine();
    }

    public static string ConvertRomanToArabic(string romanExpression)
    {
        Dictionary<char, int> romanToArabic = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        string[] expressionParts = romanExpression.Split(' ');
        string arabicExpression = "";

        foreach (string part in expressionParts)
        {
            if (int.TryParse(part, out _)) // Если часть является числом, оставляем ее без изменений
            {
                arabicExpression += part + " ";
            }
            else if (part == "+" || part == "*" || part == "/" || part == "-" || part == "(" || part == ")")
            {
                arabicExpression += part + " ";
            }
            else // Если часть является римской цифрой, переводим ее в арабскую и добавляем к арабскому выражению
            {
                int arabicNumber = 0;
                int previousValue = 0;

                foreach (char romanDigit in part)
                {
                    int currentValue = romanToArabic[romanDigit];

                    if (previousValue < currentValue)
                    {
                        arabicNumber += currentValue - 2 * previousValue;
                    }
                    else
                    {
                        arabicNumber += currentValue;
                    }

                    previousValue = currentValue;
                }

                arabicExpression += arabicNumber + " ";
            }
        }

        return arabicExpression.Trim();
    }
    static int GetValue(string input)
    {
        string[] tokens = input.Split(' ');

        Stack<double> stack = new Stack<double>();

        foreach (string token in tokens)
        {
            // Если элемент является числом, помещаем его в стек
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                // Если элемент является оператором, выполняем соответствующую операцию над двумя числами из стека
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                switch (token)
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        break;
                    case "*":
                        stack.Push(operand1 * operand2);
                        break;
                    case "/":
                        stack.Push(operand1 / operand2);
                        break;
                    default:
                        Console.WriteLine("Некорректный оператор");
                        break;
                }
            }
        }
        return (int)stack.Pop();
    }

    static string ToPostFix(string input)
    {
        string[] tokens = input.Split(' ');
        

        Stack<string> operatorStack = new Stack<string>();

        string output = "";

        foreach (string token in tokens)
        {

            if (double.TryParse(token, out double number))
            {
                output += token + " ";
            }
            else if (IsOperator(token))
            {
                // Если элемент является оператором, проверяем его приоритет и добавляем в результат соответствующим образом

                while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()) && GetOperatorPriority(token) <= GetOperatorPriority(operatorStack.Peek()))
                {
                    output += operatorStack.Pop() + " ";
                }

                operatorStack.Push(token);
            }
            else if (token == "(")
            {
                operatorStack.Push(token);
            }
            else if (token == ")")
            {
                // Если элемент является закрывающей скобкой, выталкиваем операторы из стека в результат до открывающей скобки
                while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                {
                    if (operatorStack.Count == 1)
                    {
                        output += operatorStack.Pop();
                    }
                    else
                    {
                        output += operatorStack.Pop() + " ";
                    }
                }
                operatorStack.Pop();
            }
        }
        while (operatorStack.Count > 0)
        {
            
            if (operatorStack.Count == 1)
            {
                output += operatorStack.Pop();
            }
            else
            {
                output += operatorStack.Pop() + " ";
            }
        }
        return output;
    }

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    static int GetOperatorPriority(string token)
    {
        switch (token)
        {
            case "+":
            case "-":
                return 1;
            case "*":
            case "/":
                return 2;
            default:
                return 0;
        }
    }

    static string AddGapByArtemFadeev(string input)
    {
        string input2 = char.ToString(input[0]);
        var dict = new Dictionary<char, int>(){
            {'(', 0},
            {')', 0},
            {'-', 1},
            {'+', 1},
            {'/', 1},
            {'*', 1},
            {'I', 2},
            {'V', 2},
            {'X', 2},
            {'L', 2},
            {'C', 2},
            {'D', 2},
            {'M', 2}
        };
        for (int i = 0; i < input.Length - 1; i++)
        {
            /*if ((dict[input[i]] == 1) && (dict[input[i+1]] == 1)) {
                Console.WriteLine("Некорректное выражение. ");
            }
            if ((dict[input[i]] == 0) && (dict[input[i + 1]] == 0)) {
                Console.WriteLine("Некорректное выражение. ");
            } */
            if (dict[input[i]] != dict[input[i + 1]])
            {
                input2 += " " + char.ToString(input[i + 1]);
            }
            else
            {
                input2 += char.ToString(input[i + 1]);
            }
        }
        
        return input2;
    }
}