using System;
using System.Text;
using System.IO;

namespace HomeWork
{
    class Program
    {
        static string NewString(int countOfString)
        {
            StringBuilder newString = new StringBuilder("");
            
            newString.Append($"{countOfString}#{DateTime.Now}#");

            Console.WriteLine("Введите: ФИО.");
            string FIO = Console.ReadLine();
            newString.Append($"{FIO}#");
            Console.WriteLine("Введите: Возраст.");
            string Age = Console.ReadLine();
            newString.Append($"{Age}#");
            Console.WriteLine("Введите: Рост в см.");
            string Height = Console.ReadLine();
            newString.Append($"{Height}#");
            Console.WriteLine("Введите: дата рождения.");
            string dateOfBirth = Console.ReadLine();
            newString.Append($"{dateOfBirth}#");
            Console.WriteLine("Введите: место рождения");
            string placeOfBirth = Console.ReadLine();
            newString.Append($"{placeOfBirth}#");
            
            string finishedString = Convert.ToString(newString);
            return finishedString;
        }

        static void ReadListOfClients()
        {
            
            FileInfo list = new FileInfo(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
            if (list.Exists)
            {
                Console.WriteLine("Вы хотите вывести весь текст(1) или определенную строку(2)?");
                var count = Console.ReadLine();
                string[] listOfClients = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
                switch (int.Parse(count))
                {
                    case 1:
                        for (int i = 0; i < listOfClients.Length; i++)
                        {
                            string[] words = Words(listOfClients, i);
                            for (int f = 0; f < words.Length; f++)
                            {
                                Console.Write(words[f]+ "\t");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите строку которую хотите вывести целым числом.");
                        do
                        {
                            int countOfString = int.Parse(Console.ReadLine());
                            if (countOfString - 1 >= 0 && countOfString - 1 < listOfClients.Length)
                            {
                                string[] words = Words(listOfClients, countOfString-1);
                                for (int f = 0; f < words.Length; f++)
                                {
                                    Console.Write(words[f] + "\t");
                                }
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели число больше, чем есть значений в списке. Попробуйте еще раз.");
                            }
                        } while (true);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Такого файла не существует.");
            }
        }

        static void AddNewString()
        {
            int count;
            FileInfo list = new FileInfo(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
            if (list.Exists)
            {
                string[] listOfClients = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
                
                count = listOfClients.Length + 1;
            }
            else
            {
                count = 1;
            }

            string newString = NewString(count);

            File.AppendAllText(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt", newString + Environment.NewLine);
        }

        static string[] Words(string[] allTextInLines, int count)
        {
                        
           string [] words = allTextInLines[count].Split('#');
            
           return words;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в список сотрудников. Что вы хотите сделать: Прочитать список(1) или добавить новую строку(2)?");
            int count = int.Parse(Console.ReadLine());
            switch (count)
            {
                case 1:
                    ReadListOfClients();
                    break;
                case 2:
                    AddNewString();
                    break;
                default:
                    break;
            }


        }
    }
}
