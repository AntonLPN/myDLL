using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

//Задание 1.
//Создайте собственную библиотеку классов для выполнения следующих операций:
//1.Создание файла
//2.Запись в файл
//3.	Считывание из файла
//Предусмотрите возможность возникновения исключительной ситуации. Используйте библиотеку для работы с программой «Записная книжка»

namespace myDLL
{
    public class Class1
    {
        /// <summary>
        /// Создает папку с названием TEST_FOLDER
        /// </summary>
        /// <returns> string name_directory </returns>
        public string Create_directory()
        {
            string name_directory = "TEST_FOLDER";
            DirectoryInfo directory = new DirectoryInfo(name_directory);
            name_directory = @"TEST_FOLDER\";
            directory.Create();
            //возвращает путь с именем папки
            return name_directory;
        }

        /// <summary>
        /// Создает файл txt в папке TEST_FOLDER
        /// </summary>
        /// <param name="name_file_without_format"></param>
        public void Creat_file_txt(string name)
        {
            string dir = Path.Combine(this.Create_directory(),name+".txt");//аргументы путь к папке и название создаваемого файла с указанием расширения
         
            FileStream filestream = new FileStream(dir, FileMode.Create);
            filestream.Close();
        }

        /// <summary>
        /// Метод получения в массив перечня всех файлов txt хранящихся в папке TEST_FOLDER
        /// </summary>
        /// <returns> string [] </returns>
        public string [] all_file_txt()
        {

            //заносим названия всех файлов в массив строк
            string[] all_recordings = Directory.GetFiles(this.Create_directory(), "*.txt");//добавляем патерн txt для поиска только текстовых файлов

            return all_recordings;
        }

        /// <summary>
        /// Открывает блокнот для вввода напрямую текста
        /// </summary>
        /// <param name="name_file_without_format"></param>
        public void Write_to_the_file_txt(string name_file)
        {
            System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            Proc.StartInfo.FileName = this.Create_directory()+name_file+".txt";

            Proc.Start();
            Proc.Close();
        }

        /// <summary>
        /// Считывает информацию из файла в строку 
        /// </summary>
        /// <param name="name_file_without_format"></param>
        /// <returns>StremReader</returns>
        public string ReadFile(string name_file)
        {

            using (StreamReader sr = File.OpenText(this.Create_directory()+name_file+".txt"))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
