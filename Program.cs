using System;
using System.Text;
using System.IO;
using System.Linq;

namespace HomeWork
{
    class Program
    {
        static void SortOfData(Workers[] w)
        {
            Console.WriteLine("Выберите по какому параметру хотите провести сортировку: ФИО(1), возраст(2), рост (3), дата рождения(4), место рождения(5)");
            // ПРидумать метод сортировки с выбором параметра сортировки
        }

        static void Main(string[] args)
        {
            Workers w = new Workers();
            Console.WriteLine("Добро пожаловать в список сотрудников. Что вы хотите сделать: Прочитать список(1) или добавить новую строку(2), удалить ненужную строку (3)?");
            int count = int.Parse(Console.ReadLine());
            switch (count)
            {
                case 1:
                    Console.WriteLine("Вы хотите прочитать файл целиком(1), какую-то конкретную строку(2), Какой-то диапазон значений(3), какой-то диапазон дат(4)?");
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
                        case "4":
                            Console.WriteLine("Выберете дату начальной и конечной строки диапозона в формате (28/12/2019).");
                            w.ReadTheText(Convert.ToDateTime(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()));
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
