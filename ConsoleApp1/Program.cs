using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDLL;
using System.IO;



//Задание 1.
//Создайте собственную библиотеку классов для выполнения следующих операций:
//1.Создание файла
//2.Запись в файл
//3.	Считывание из файла
//Предусмотрите возможность возникновения исключительной ситуации. Используйте библиотеку для работы с программой «Записная книжка»

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            myDLL.Class1 test = new Class1();
            test.Create_directory();//создаем папку с названием TEST_FOLDER

            do
            {
                Console.WriteLine("1-Создать файл");
                Console.WriteLine("2-Записать в файл");
                Console.WriteLine("3-Считать с файла");
                Console.WriteLine("4-Показать название файлов в папке и путь к ним");
                
                Console.Write(">>");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        {
                            Console.Write("Введите название файла >>");
                            string name_file = Console.ReadLine();
                            test.Creat_file_txt(name_file);
                         

                        }
                        break;


                    case 2:
                        {
                            Console.Write("Введите название фала без указания формата txt :>>");
                            string name_file = Console.ReadLine();
                            test.Write_to_the_file_txt(name_file);

                        }
                        break;


                    case 3:
                        {
                            Console.Write("Введите название файла без указания формата : >>");
                            string name_file = Console.ReadLine();
                            try
                            {
                                Console.WriteLine(test.ReadFile(name_file));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                               
                            }
                           
                        }break;
                    case 4:
                        {
                            foreach (string item in test.all_file_txt())
                            {
                                Console.WriteLine(item);
                                using (StreamReader stream = File.OpenText(item))
                                {

                                    Console.WriteLine(stream.ReadToEnd());
                                }
                            }
                        }
                        break;



                    default:
                        break;
                }


            } while (menu!=0);


        }
    }
}
