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
        /// <summary>
        /// Структура сотрудника
        /// </summary>
        /// <param name="id">Номер в списке</param>
        /// <param name="dateTimeNow">Дата добавления</param>
        /// <param name="fio">Имя</param>
        /// <param name="age">Фамилия</param>
        /// <param name="height">Отчество</param>
        /// <param name="dateOfBirth">Рост</param>
        /// <param name="placeOfBirth">Возраст</param>
        //private int id;
        //private DateTime dateTimeNow;
        //private string fio;
        //private int age;
        //private int height;
        //private DateTime dateOfBirth;
        //private string placeOfBirth;

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
        private void Print(Workers w)
        {
            Console.WriteLine($"{Convert.ToString(w.Id)} {Convert.ToString(w.DateTimeNow)} {w.Fio} {Convert.ToString(w.Age)} {Convert.ToString(w.Height)} {Convert.ToString(w.DateOfBirth)} {w.PlaceOfBirth}");
        }

        /// <summary>
        /// Метод заполняющий еденицу массивов воркеров
        /// </summary>
        /// <param name="allTextInLines"></param>
        /// <param name="count"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        private Workers Words(string allTextInLines)
        {
            Workers worker = new Workers();

            string[] words = allTextInLines.Split('#');
            for (int i = 0; i < words.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        worker.Id = int.Parse(words[i]);
                        continue;
                    case 1:
                        worker.DateTimeNow = DateTime.Parse(words[i]);
                        continue;
                    case 2:
                        worker.Fio = words[i];
                        continue;
                    case 3:
                        worker.Age = int.Parse(words[i]);
                        continue;
                    case 4:
                        worker.Height = int.Parse(words[i]);
                        continue;
                    case 5:
                        worker.DateOfBirth = DateTime.Parse(words[i]);
                        continue;
                    case 6:
                        worker.PlaceOfBirth = words[i];
                        continue;
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
        public Workers [] PushOfData()
        {
            if (Exsistance())
            {
                string [] listOfString = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
                Workers[] workers = new Workers[listOfString.Length];
                for (int i = 0; i < listOfString.Length; i++)
                {
                    workers[i] = Words(listOfString[i]);
                }
                return workers;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Такого документа не существует, получить данные не получится.");
            }
        }

        /// <summary>
        /// Метод позволяющий читать диапозон данных по id
        /// </summary>
        /// <param name="w"></param>
        /// <param name="startArray"></param>
        /// <param name="endArray"></param>
        public void ReadTheText(int startArray, int endArray)
        {
            Workers[] w = PushOfData();
            for (int i = 0; i < endArray; i++)
            {
                if (w[i].Id >= startArray)
                {
                    Print(w[i]);
                }
                else if (w[i].Id <= startArray)
                {
                    continue;
                }else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Метод позволяющий читать диапозон данных по дате
        /// </summary>
        /// <param name="w"></param>
        /// <param name="startArray"></param>
        /// <param name="endArray"></param>
        public void ReadTheText(DateTime date1, DateTime date2)
        {
            Workers[] w = PushOfData();
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].DateTimeNow >= date1 && w[i].DateTimeNow <= date2)
                {
                    Print(w[i]);
                }
                else
                {
                    continue;
                }
            }
        }
      
        /// <summary>
        /// Метод позволяющий читать конкретный индекс
        /// </summary>
        /// <param name="w"></param>
        /// <param name="startArray"></param>
        /// <param name="endArray"></param>
        public void ReadTheText(int index)
        {
            Workers[] w = PushOfData();
            Print(w[index-1]);

        }

        /// <summary>
        /// Метод позволяющий читать файл целиком
        /// </summary>
        /// <param name="w"></param>
        /// <param name="startArray"></param>
        /// <param name="endArray"></param>
        public void ReadTheText ( )
        {
            Workers[] w = PushOfData();
              for (int i = 0; i < w.Length; i++)
                {
                    Print(w[i]);
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
        private Workers NewWorker( int id)
        {
            Workers worker = new Workers();
            worker.Id = id;
            worker.DateTimeNow = DateTime.Now;
                       
            Console.WriteLine("Введите: ФИО.");
            worker.Fio = Console.ReadLine();
            Console.WriteLine("Введите: Возраст.");
            worker.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите: Рост в см.");
            worker.Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите: дата рождения.");
            worker.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите: место рождения");
            worker.PlaceOfBirth = Console.ReadLine();
            
            return worker;
        }

        /// <summary>
        /// Метод выдающий айди строки
        /// </summary>
        /// <returns></returns>
         private int FindID()
        {
            if (Exsistance())
            {
                string[] listOfClients = File.ReadAllLines(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");

                 return listOfClients.Length + 1;
            }
            else
            {
                return 1;
            }
        }


        public void DeleteElement(int index)
        {
            Workers[] allStuff = PushOfData();
            File.Delete(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt");
            for (int i = 0; i <= allStuff.Length-1; i++)
            {
                if (i < index-1)
                {
                    AddTheString(allStuff[i]);
                }
                else if (i == index-1)
                {
                    continue;
                }
                else if (i > index - 1)
                {
                    allStuff[i-1].Id = i;
                    AddTheString(allStuff[i-1]);
                }
            }
            
        }

        private void AddTheString( Workers newWorker)
        {
            string newString = $"{Convert.ToString(newWorker.Id)}#{Convert.ToString(newWorker.DateTimeNow)}#{newWorker.Fio}#{Convert.ToString(newWorker.Age)}#{Convert.ToString(newWorker.Height)}#{Convert.ToString(newWorker.DateOfBirth)}#{newWorker.PlaceOfBirth}";
            File.AppendAllText(@"C:\Users\User\source\repos\HomeWork\ListOfClients.txt", newString + Environment.NewLine);
        }

        /// <summary>
        /// Метод позволяющий добавить строку в файл
        /// </summary>
        public void AddNewString()
        {
            
            int id = FindID();
            Workers newWorker = NewWorker(id);
            AddTheString(newWorker);

        }
    }
}
