using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        enum Month
        {
            January = 1,
            February = 2,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        enum DayOfWeek
        {
            Monday = 0b1000000,
            Tuesday = 0b0100000,
            Wednesday = 0b0010000, 
            Thursday = 0b0001000, 
            Friday = 0b0000100, 
            Saturday = 0b0000010, 
            Sunday = 0b0000001
        }

        public static void OfficeSchedule(int inputMask, string officeName)
        {
            string workDays = "";

            foreach(DayOfWeek day in ((int[])Enum.GetValues(typeof(DayOfWeek))).Reverse())
            {
                if ((inputMask & (int)day) == (int)day)
                {
                    workDays += day + ", ";
                }
            }

            workDays = workDays.Remove(workDays.Length - 2);

            Console.WriteLine($"Расписание для офиса {officeName}: {workDays}");
        }

        public static void OfficeScheduleAlternative(int inputMask, string officeName)
        {
            Func<string, bool> InMiddle = str =>
            {
                return str.Length > 0 && str.Substring(str.Length - 3, 3).Contains("по");
            };

            Func<int, int, bool> IsOneWorkDay = (today, seqStart) =>
            {
                return seqStart >= 0 && today - 1 == seqStart;
            };

            string workDays = "";

            int seqStart = -1;
            int[] days = (int[])Enum.GetValues(typeof(DayOfWeek));
            days = days.Reverse().ToArray();
            for (var i = 0; i < days.Count(); i++)
            {
                if ((inputMask & days[i]) == days[i])
                {
                    if (workDays.Length == 0)
                    {
                        workDays += "с " + (DayOfWeek)days[i] + " по ";
                        seqStart = i;
                    }
                    else if (workDays.Length > 0 && !InMiddle(workDays))
                    {
                        workDays += "с " + (DayOfWeek)days[i] + " по ";
                        seqStart = i;
                    }

                    if (i == days.Count() - 1)
                    {
                        if(IsOneWorkDay(i, seqStart))
                            workDays = workDays.Remove(workDays.Length - ("c " + (DayOfWeek)days[i] + " по ").Length);
                        workDays += (DayOfWeek)days[i];
                    }
                }
                else if (InMiddle(workDays))
                {
                    if(IsOneWorkDay(i, seqStart))
                    {
                        workDays = workDays.Remove(workDays.Length - ("c " + (DayOfWeek)days[seqStart] + " по ").Length);
                    }

                    workDays += (DayOfWeek)days[i - 1] + " ";
                }
            }
            Console.WriteLine($"Расписание для офиса {officeName}: {workDays}");
        }

        static void Main(string[] args)
        {
            //1
            Console.WriteLine("1.");
            double avgTemperature;
            while (true)
            {
                Console.WriteLine("Введите минимальную и максимальную температуру за сутки (через запятую):");

                var input = Console.ReadLine();

                try
                {
                    var temperatures = Array.ConvertAll(input.Split(','), int.Parse);
                    avgTemperature = Queryable.Average(temperatures.AsQueryable());
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Введите числа через запятую.");
                    continue;
                }
                break;
            }

            Console.WriteLine($"Средняя темепратура за сутки: {avgTemperature}");


            Console.WriteLine("\n2.");
            //2
            int monthNumber;
            while (true)
            {
                Console.WriteLine("Введите номер текущего месяца:");

                var input = Console.ReadLine();
                monthNumber = int.Parse(input);

                if (!monthNumber.Equals(null))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число.");
                }
            }

            Console.WriteLine($"Текущий месяц: {(Month)monthNumber}");


            Console.WriteLine("\n3., 5.");
            //3
            if (monthNumber % 2 == 0)
            {
                Console.WriteLine("Номер месяца четный.");
            }
            else
            {
                Console.WriteLine("Номер месяца нечетный.");
            }

            //5
            var winterMonths = new int[] { 1, 2, 12 };
            if (winterMonths.Contains(monthNumber) && avgTemperature > 0)
            {
                Console.WriteLine("Дождливая зима.");
            }


            Console.WriteLine("\n4.");
            //4
            var products = new Dictionary<string, double>() {
                    { "Хлеб", 56.5 },
                    { "Молоко", 75 },
                    { "Яйца", 82.5 }
            };

            double sum = 0;
            foreach (var product in products)
            {
                sum += product.Value;
            }

            var heading = "Кассовый чек";
            var organization = "ООО \"Рога и копыта\"";
            var time = new DateTime(2021, 5, 21, 15, 45, 40);
            var delimiter = new string('_', 25);

            Console.WriteLine(organization.PadLeft(25));
            Console.WriteLine(heading.PadLeft(20));
            Console.WriteLine(time.ToString("dd.MM.yyy HH:mm:ss"));
            Console.WriteLine(delimiter);

            int i = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"{i++}. {product.Key} \t {product.Value} руб.");
            }
            Console.WriteLine(delimiter);
            Console.WriteLine($"ИТОГ \t\t {sum} руб.");
            Console.WriteLine(delimiter);


            Console.WriteLine("\n6.");
            //6
            //Вариация, как нагляднее, по-моему
            var workDays = 0b1111100;
            var officeName = "test";
            OfficeSchedule(workDays, officeName);
            OfficeSchedule(0b1110110, "strange office");

            //Вариация, как в примере
            OfficeScheduleAlternative(0b1110110, "strange office1");
            OfficeScheduleAlternative(0b1010101, "strange office2");
            OfficeScheduleAlternative(0b1110111, "strange office3");
            OfficeScheduleAlternative(0b0110111, "strange office4");
        }
    }
}