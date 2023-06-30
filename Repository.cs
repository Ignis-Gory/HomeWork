using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork
{
    public struct Workers
    {
        /// <summary>
        /// Обозначение переменных
        /// </summary>
        private int id;
        private DateTime dateTimeNow;
        private string fio;
        private int age;
        private int height;
        private DateTime dateOfBirth;
        private string placeOfBirth;

        /// <summary>
        /// Обозначение доступов к параметрам
        /// </summary>
        /// <param ></param>
        public int Id { get; set; }
        public DateTime DateTimeNow { get; set; }
        public string Fio { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        /// <summary>
        /// Метод позволяющий вывести строку на консоль
        /// </summary>
        /// <param name="w"></param>
        public void Print(Workers w)
        {
            Console.WriteLine($"{Convert.ToString(w.Id)} {Convert.ToString(w.DateTimeNow)} {w.Fio} {Convert.ToString(w.Age)} {Convert.ToString(w.Heiht)} {Convert.ToString(w.DateOfBirth)} {w.PlaceOfBirth}");
        }

        /// <summary>
        /// Метод заполняющий еденицу массивов воркеров
        /// </summary>
        /// <param name="allTextInLines"></param>
        /// <param name="count"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        private Workers Words(string allTextInLines, Workers worker)
        {

            string[] words = allTextInLines.Split('#');
            for (int i = 0; i < words.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        worker.Id = int.Parse(words[i]);
                        break;
                    case 2:
                        worker.DateTimeNow = DateTime.Parse(words[i]);
                        break;
                    case 3:
                        worker.Fio = words[i];
                        break;
                    case 4:
                        worker.Age = int.Parse(words[i]);
                        break;
                    case 5:
                        worker.Heiht = int.Parse(words[i]);
                        break;
                    case 6:
                        worker.DateOfBirth = DateTime.Parse(words[i]);
                        break;
                    case 7:
                        worker.PlaceOfBirth = words[i];
                        break;
                    default:
                        break;
                }
                    
            }

            return worker;
        }

        /// <summary>
        /// Метод позволяющий проверить файл на действительность и его существование
        /// </summary>
        private bool Exsistance ()
        {
            FileInfo list = new FileInfo(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
            if (list.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод, позволяющий загрузить данные из файла в структуру
        /// </summary>
        /// <returns></returns>
        public Workers [] pushOfData()
        {
            if (Exsistance())
            {
                string [] listOfString = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
                Workers[] workers = new Workers[listOfString.Length];
                for (int i = 0; i < listOfString.Length; i++)
                {
                    Words(listOfString[i], workers[i]);
                }
                return workers;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Такого документа не существует, получить данные не получится.");
            }
        }

        /// <summary>
        /// Метод позволяющий читать файл целиком, конкретный индекс или диапозон данных по индексу
        /// </summary>
        /// <param name="w"></param>
        /// <param name="startArray"></param>
        /// <param name="endArray"></param>
        public void ReadTheText (Workers [] w, int startArray = -1, int endArray = -1)
        {
            w = pushOfData();
            if (startArray == -1 || endArray == -1)
            {
                for (int i = 0; i < w.Length; i++)
                {
                    Print(w[i]);
                } 
            }
            else if (endArray == -1 || startArray-1>= 0 || startArray - 1 < w.Length)
            {
                Print(w[startArray]);
            }
            else if (startArray - 1 >= 0 || startArray - 1 < w.Length|| endArray - 1 >= 0 || endArray - 1 < w.Length || endArray > startArray)
            {
                for (int i = startArray - 1; i < endArray-1; i++)
                {
                    Print(w[i]);
                }
            }
            else
            {
                Console.WriteLine("Вы допустили какую-то ошибку при вводе параметров - попробуйте еще раз.");
            }

        }

        //public void ReadListOfClients()
        //{

        //    FileInfo list = new FileInfo(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
        //    if (list.Exists)
        //    {
        //        Console.WriteLine("Вы хотите вывести весь текст(1) или определенную строку(2)?");
        //        var count = Console.ReadLine();
        //        string[] listOfClients = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
        //        switch (int.Parse(count))
        //        {
        //            case 1:
        //                for (int i = 0; i < listOfClients.Length; i++)
        //                {
        //                    string[] words = Words(listOfClients, i);
        //                    for (int f = 0; f < words.Length; f++)
        //                    {
        //                        Console.Write(words[f] + "\t");
        //                    }
        //                    Console.WriteLine();
        //                }
        //                break;
        //            case 2:
        //                Console.WriteLine("Введите строку которую хотите вывести целым числом.");
        //                do
        //                {
        //                    int countOfString = int.Parse(Console.ReadLine());
        //                    if (countOfString - 1 >= 0 && countOfString - 1 < listOfClients.Length)
        //                    {
        //                        string[] words = Words(listOfClients, countOfString - 1);
        //                        for (int f = 0; f < words.Length; f++)
        //                        {
        //                            Console.Write(words[f] + "\t");
        //                        }
        //                        Console.WriteLine();
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Вы ввели число больше, чем есть значений в списке. Попробуйте еще раз.");
        //                    }
        //                } while (true);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Такого файла не существует.");
        //    }
        //}

        /// <summary>
        /// Метод позволяющий создать данные по нововму рабочему;
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private Workers NewWorker(Workers worker, int id)
        {
            worker.Id = id;
            worker.DateTimeNow = DateTime.Now;
                       
            Console.WriteLine("Введите: ФИО.");
            worker.Fio = Console.ReadLine();
            Console.WriteLine("Введите: Возраст.");
            worker.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите: Рост в см.");
            worker.Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите: дата рождения.");
            Console.WriteLine("Введите: место рождения");
            worker.PlaceOfBirth = Console.ReadLine();
            
            return worker;
        }


    }
}
