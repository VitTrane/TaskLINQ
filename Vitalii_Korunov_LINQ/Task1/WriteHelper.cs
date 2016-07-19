using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    public static class WriteHelper
    {
        /// <summary>
        /// Записывает объект в xml файл
        /// </summary>
        /// <typeparam name="T">Тип записываемого объекта</typeparam>
        /// <param name="path">Путь к файлу</param>
        /// <param name="obj">Объект, который нужно записать</param>
        public static void WriteXmlFile<T>(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path, false))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(writer, obj);
            }
        }
    }
}
