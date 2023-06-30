using System;
using System.Text;
using System.IO;
using System.Linq;

namespace HomeWork
{
    class Program
    {
       

        

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
