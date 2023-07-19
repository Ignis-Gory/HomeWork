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

            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; i < w.Length; i++)
                    {
                        for (int j = 0; j < w.Length - 1; j++)
                        {
                            if (String.Compare(w[j].Fio, w[j + 1].Fio) == 1)
                            {
                                Workers temp = w[j];
                                w[j] = w[j + 1];
                                w[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case "2":
                    for (int i = 0; i < w.Length; i++)
                    {
                        for (int j = 0; j < w.Length - 1; j++)
                        {
                            if (w[j].Age > w[j + 1].Age)
                            {
                                Workers temp = w[j];
                                w[j] = w[j + 1];
                                w[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case "3":
                    for (int i = 0; i < w.Length; i++)
                    {
                        for (int j = 0; j < w.Length - 1; j++)
                        {
                            if (w[j].Height > w[j + 1].Height)
                            {
                                Workers temp = w[j];
                                w[j] = w[j + 1];
                                w[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case "4":
                    for (int i = 0; i < w.Length; i++)
                    {
                        for (int j = 0; j < w.Length - 1; j++)
                        {
                            if (w[j].DateOfBirth > w[j + 1].DateOfBirth)
                            {
                                Workers temp = w[j];
                                w[j] = w[j + 1];
                                w[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case "5":
                    for (int i = 0; i < w.Length; i++)
                    {
                        for (int j = 0; j < w.Length - 1; j++)
                        {
                            if (String.Compare( w[j].PlaceOfBirth, w[j + 1].PlaceOfBirth) == 1)
                            {
                                Workers temp = w[j];
                                w[j] = w[j + 1];
                                w[j + 1] = temp;
                            }
                        }
                    }
                    break;
                default:
                    break;
                    
            }
            for (int i = 0; i < w.Length; i++)
            {
                Console.WriteLine($"{Convert.ToString(w[i].Id)} {Convert.ToString(w[i].DateTimeNow)} {w[i].Fio} {Convert.ToString(w[i].Age)} {Convert.ToString(w[i].Height)} {Convert.ToString(w[i].DateOfBirth)} {w[i].PlaceOfBirth}");
            }

            // ПРидумать метод сортировки с выбором параметра сортировки
        }

        static void Main(string[] args)
        {
            Workers w = new Workers();
            string choice = "да";
            do
            {
                Console.WriteLine("Добро пожаловать в список сотрудников. Что вы хотите сделать: Прочитать список(1) или добавить новую строку(2), удалить ненужную строку (3)?");
                int count = int.Parse(Console.ReadLine());
                
                switch (count)
                {
                    case 1:

                        do
                        {
                            Console.WriteLine("Вы хотите прочитать файл целиком(1), какую-то конкретную строку(2), Какой-то диапазон значений(3), какой-то диапазон дат(4), показать отсортерованный файл(5)?");
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
                                case "5":
                                    SortOfData(w.PushOfData());
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine("Хотите повторить действие?");
                            choice = Console.ReadLine();
                        } while (choice == "да" || choice == "Да");

                        break;
                    case 2:
                        do
                        {
                            w.AddNewString();
                            Console.WriteLine("Хотите повторить действие?");
                            choice = Console.ReadLine();
                        } while (choice == "да" || choice == "Да");

                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Введите номер строки которую хотите удалить");
                            int countOfString = int.Parse(Console.ReadLine());
                            w.DeleteElement(countOfString);
                            Console.WriteLine("Хотите повторить действие?");
                            choice = Console.ReadLine();
                        } while (choice == "да" || choice == "Да");

                        break;
                    default:
                        break;
                }
                Console.WriteLine("Хотите повторить действие?");
                choice = Console.ReadLine();
            } while (choice == "да" || choice == "Да");
            
            


        }
    }
}
