using System;
using System.Collections.Generic;

namespace АлгоритмПоСкобочкам_НекрасовЛА
{
    internal class Program
    {
        static void Main()
        {
            bool isExit = false;
            while (isExit == false)
            {
                Console.WriteLine("Введите скобочную последовательность. Для выхода введите 'EXIT'.");
                string input = Console.ReadLine();


                if (input == "EXIT")
                {
                    isExit = true;
                    break;
                }

                if (input.Length <= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод, был пустой ввод, либо введена 1 скобка!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (IsCorrectBrackets(input))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Последовательность правильная!)");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Последовательность неправильная!(");
                }

                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        /// <summary>
        /// Функция на проверку корретной скобочной последовательности
        /// </summary>
        /// <param name="input">Ожидается строка от пользователя</param>
        /// <returns>Тип возвращаемого значения bolean, где true - правильная СП, false - неправильная СП</returns>
        static bool IsCorrectBrackets(string input)
        {
            Stack<char> bracketsStack = new Stack<char>();

            foreach (char bracket in input)
            {
                if (bracket == '(' || bracket == '[' || bracket == '{')
                {
                    bracketsStack.Push(bracket);
                }
                else
                {
                    if (bracketsStack.Count == 0)
                    {
                        return false;
                    }

                    char topBracket = bracketsStack.Pop();
                    if ((bracket == ')' && topBracket != '(') || (bracket == ']' && topBracket != '[') || (bracket == '}' && topBracket != '{'))
                    {
                        return false;
                    }
                }
            }

            return bracketsStack.Count == 0;
        }
    }
}
