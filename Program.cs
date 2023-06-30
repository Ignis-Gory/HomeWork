using System;
using System.Text;
using System.IO;
using System.Linq;

namespace HomeWork
{
    class Program
    {
                      
               
        static void Main(string[] args)
        {
            Workers w = new Workers();
            Console.WriteLine("Добро пожаловать в список сотрудников. Что вы хотите сделать: Прочитать список(1) или добавить новую строку(2), удалить ненужную строку (3)?");
            int count = int.Parse(Console.ReadLine());
            switch (count)
            {
                case 1:
                    Console.WriteLine("Вы хотите прочитать файл целиком(1), какую-то конкретную строку(2), Какой-то диапазон значений?");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            w.ReadTheText();
                            break;
                        case "2":
                            Console.WriteLine("Выберете номер строки, которую хотите прочитать.");
                            w.ReadTheText(int.Parse(Console.ReadLine()));
                            break;
                        case "3":
                            Console.WriteLine("Выберете номер начальной и конечной строки диапозона.");
                            w.ReadTheText(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    w.AddNewString();
                    break;
                case 3:
                    Console.WriteLine("Введите номер строки которую хотите удалить");
                    int countOfString = int.Parse(Console.ReadLine());
                    w.DeleteElement(countOfString);
                    break;
                default:
                    break;
            }


        }
    }
}
