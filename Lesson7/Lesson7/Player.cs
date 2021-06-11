using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Player
    {
        public char Symbol { get; set; }

        public Player(char Symbol)
        {
            this.Symbol = Symbol;
        }

        public virtual void Move()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + Consts.field.Size);
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + Consts.field.Size);
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!Consts.field.IsCellValid(y, x));
            Consts.field.SetSym(y, x, Symbol);
        }
    }
}