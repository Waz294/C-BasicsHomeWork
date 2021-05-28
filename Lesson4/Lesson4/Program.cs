using System;
using System.Linq;

namespace Lesson4
{
    class Program
    {
        enum TimeOfTheYear
        {
            Winter, Spring, Summer, Autumn
        }

        //1
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return firstName + " " + lastName + " " + patronymic;
        }

        //3
        static string ConvertTimeOfTheYearToString(TimeOfTheYear input)
        {
            switch (input)
            {
                case TimeOfTheYear.Winter:
                    {
                        return "Зима";
                    }
                case TimeOfTheYear.Spring:
                    {
                        return "Весна";
                    }
                case TimeOfTheYear.Summer:
                    {
                        return "Лето";
                    }
                case TimeOfTheYear.Autumn:
                    {
                        return "Осень";
                    }
            }
            return "";
        }
        //3
        static string GetTimeOfTheYear(int index)
        {
            switch (index)
            {

                case 1:
                case 2:
                case 12:
                    {
                        return ConvertTimeOfTheYearToString(TimeOfTheYear.Winter);
                    }
                case 3:
                case 4:
                case 5:
                    {
                        return ConvertTimeOfTheYearToString(TimeOfTheYear.Spring);
                    }
                case 6:
                case 7:
                case 8:
                    {
                        return ConvertTimeOfTheYearToString(TimeOfTheYear.Summer);
                    }
                case 9:
                case 10:
                case 11:
                    {
                        return ConvertTimeOfTheYearToString(TimeOfTheYear.Autumn);
                    }
                default:
                    {
                        throw new Exception();
                    }
            }
        }
        //4
        static int CalcFibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }
            return CalcFibonacci(number - 1) + CalcFibonacci(number - 2);
        }
        //5
        static bool checkDotAtEnd(string str)
        {
            return str.Last() == '.';
        }
        //5
        static bool checkUpperFirst(string str)
        {
            return char.IsUpper(str.First());
        }
        //5
        static void addDot(ref string str)
        {
            str += '.';
        }
        //5
        static string GetNormalString(string input)
        {
            var splitWord = "предложение";
            var words = input.Split(" ");

            for(var i = 1; i < words.Length - 1; i++)
            {
                if(checkUpperFirst(words[i]) && words[i].ToLower() == splitWord && !checkDotAtEnd(words[i - 1]))
                {
                    addDot(ref words[i - 1]);
                }
                else if(checkUpperFirst(words[i]) && words[i - 1].ToLower() != splitWord && words[i + 1].ToLower() == splitWord && !checkDotAtEnd(words[i - 1]))
                {
                    addDot(ref words[i - 1]);
                }
                else if (checkUpperFirst(words[i + 1]))
                {
                    addDot(ref words[i]);
                }
            }

            addDot(ref words[words.Length - 1]);
            return String.Join(' ', words);
        }

        static void Main(string[] args)
        {
            //1
            Console.WriteLine(GetFullName("Вася", "Пупкин", "Петрович"));
            Console.WriteLine(GetFullName("Петя", "Васечкин", "Антонович"));

            Console.WriteLine();

            //2
            Console.WriteLine("Введите цифры через пробел:");
            var input = Console.ReadLine();

            Console.WriteLine(Array.ConvertAll(input.Split(' '), s => int.Parse(s)).Sum());

            //3
            while (true)
            {
                Console.WriteLine("Введите номер месяца (1-12):");
                input = Console.ReadLine();
                var output = "";
                try
                {
                    output = GetTimeOfTheYear(int.Parse(input));
                }
                catch
                {
                    Console.WriteLine("Некоррекнтый ввод");
                    continue;
                }
                Console.WriteLine(output);
                break;
            }

            //4
            Console.WriteLine(CalcFibonacci(0)); //0
            Console.WriteLine(CalcFibonacci(1)); //1
            Console.WriteLine(CalcFibonacci(5)); //5

            //5
            var str1 = "Предложение один Теперь предложение два Предложение три";

            Console.WriteLine(GetNormalString(str1) + "\n");

            var str2 = "Вот предложение тест Предложение один Теперь ой предложение раз два Предложение Предложение предложение Предложение предложение предложение Предложение три";

            Console.WriteLine(GetNormalString(str2));
        }
    }
}
