using System;
using System.IO;

namespace Lesson5
{
    class Employee
    {
        public string Name { get; set; }
        public string Function { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }

        public Employee(string Name,
                        string Function,
                        string Email,
                        string Phone,
                        int Salary,
                        int Age)
        {
            this.Name = Name;
            this.Function = Function;
            this.Email = Email;
            this.Phone = Phone;
            this.Salary = Salary;
            this.Age = Age;
        }

        public override string ToString()
        {
            return $"{Name} {Function} {Email} {Phone} {Salary} {Age}";
        }
    }

    class Program
    {

        static string filepath = @".\output.txt";
        static void Main(string[] args)
        {
            //2
            File.WriteAllText(@".\startup.txt", DateTime.Now.ToString("HH:mm"));

            //1
            Console.WriteLine("Enter something");
            var input = Console.ReadLine();
            File.WriteAllText(filepath, input);

            Console.WriteLine("\nEnter digit (0-255)");
            var val = int.Parse(Console.ReadLine());
            if (val > 0 && val <= 255)
            {
                File.WriteAllBytes(@".\test.bin", BitConverter.GetBytes(val));
            }

            var office = new Employee[]
            {
                new Employee("Vasya Pupkin", "Engineer", "pupkin@mail.ru", "+7900000", 50000, 30),
                new Employee("Petya Pupkin", "Engineer", "pupkin1@mail.ru", "+7900001", 50000, 20),
                new Employee("Kate Pupkina", "Engineer", "pupkina@mail.ru", "+7900002", 50000, 45),
                new Employee("Anton Pupkin", "Engineer", "pupkin2@mail.ru", "+7900003", 50000, 33),
                new Employee("Oleg Pupkin", "Engineer", "pupkin@mail.ru", "+7900004", 50000, 55)
            };
            
            foreach(var employee in office)
            {
                if(employee.Age > 40)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }
    }
}
