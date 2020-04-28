using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiLineTuringMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1 Розпізнавання паліндромів
            // Виводить 1, якщо паліндром і 0, якщо ні

            Machine m1 = new Machine();
            m1.ParseCommands("../../Commands/task1.txt");
            Console.WriteLine(m1.Run("0010"));
            m1.PrintProtocol("../../Protocols/task1_1.txt");
            Console.WriteLine(m1.Run("01110"));
            m1.PrintProtocol("../../Protocols/task1_2.txt");

            // task 2 Додавання в двійковій системі

            Machine m2 = new Machine();
            m2.ParseCommands("../../Commands/task2.txt");
            Console.WriteLine(m2.Run("101011101", "1000101"));
            m2.PrintProtocol("../../Protocols/task2.txt");

            // task 3 Подвоєння одиниць

            Machine m3 = new Machine();
            m3.ParseCommands("../../Commands/task3.txt");
            Console.WriteLine(m3.Run("11"));
            m3.PrintProtocol("../../Protocols/task3.txt");

            // task 4 Віднімання в десятковій системі

            Machine m4 = new Machine();
            m4.ParseCommands("../../Commands/task4.txt");
            Console.WriteLine(m4.Run("17723", "1723"));
            m4.PrintProtocol("../../Protocols/task4.txt");
        }
    }
}
