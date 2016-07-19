using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class CustomerFilter
    {
        /// <summary>
        /// Фильтрует список клиентов по заданной фамилии
        /// </summary>
        /// <param name="customers">Список клиентов, который нужно отфильтровать</param>
        /// <param name="secondName">Фамилия, по которой фильтруется список</param>
        public static List<Customer> FilterSecondName(List<Customer> customers, string secondName)
        {
            return customers.Where(c => c.SecondName.Equals(secondName)).ToList();
        }

        /// <summary>
        /// Фильтрует список клиентов по заданному имени
        /// </summary>
        /// <param name="customers">Список клиентов, который нужно отфильтровать</param>
        /// <param name="name">Имя, по которому фильтруется список</param>
        public static List<Customer> FilterName(List<Customer> customers, string name)
        {
            return customers.Where(c => c.Name.Equals(name)).ToList();
        }

        /// <summary>
        /// Фильтрует список клиентов по заданному отчеству
        /// </summary>
        /// <param name="customers">Список клиентов, который нужно отфильтровать</param>
        /// <param name="patronymic">Отчество, по которому фильтруется список</param>
        public static List<Customer> FilterPatronymic(List<Customer> customers, string patronymic)
        {
            return customers.Where(c => c.Patronymic.Equals(patronymic)).ToList();
        }

        /// <summary>
        /// Фильтрует список клиентов по заданному названию банка
        /// </summary>
        /// <param name="customers">Список клиентов, который нужно отфильтровать</param>
        /// <param name="bankName">Название банка, по которому фильтруется список</param>
        public static List<Customer> FilterBankName(List<Customer> customers, string bankName)
        {
            return customers.Where(c => c.BankName.Equals(bankName)).ToList();
        }
    }
}
