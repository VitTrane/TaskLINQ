using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class ReadFileHelper
    {
        /// <summary>
        /// Читает файл и возвращает массив прочитанных строк
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static string[] ReadTextFile(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                if (!File.Exists(path))
                    File.Create(path);

                using (var streamReader = new StreamReader(path, Encoding.Default))
                {
                    while (!streamReader.EndOfStream)
                    {
                        lines.Add(streamReader.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("При чтении файла произошла ошибка");
            }

            return lines.ToArray();
        }
    }
}
