using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class DefenseOfConsolas
    {
        public DefenseOfConsolas() {
            Console.Title = "Defense of Consolas";

            Console.Write("Target row? ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Target column? ");
            int column = int.Parse(Console.ReadLine());

            var positions = new [] { (row, column - 1), (row - 1, column), (row, column + 1), (row + 1, column) };

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Deploy to: ");

            foreach (var position in positions) { 
                Console.WriteLine(position.ToString());
            }

            Console.Beep();
        }
    }
}
