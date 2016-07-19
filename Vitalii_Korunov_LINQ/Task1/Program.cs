using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        private static string _pathInputFile = "input.txt";
        private static string _pathOutputFile = "output.xml";

        private static IDictionary<string, Bank> _banks = new Dictionary<string, Bank>();
        private static bool _isRepeat = true;
        private static string[] _filters =new string[4];

        static void Main(string[] args)
        {
            ProcessingData(); 
           
            while (_isRepeat)
            {
                ShowMenu();
                SelectAction();
                Console.WriteLine();
            }            
        }

        /// <summary>
        /// Обрабатывает прочитанные данные
        /// </summary>
        private static void ProcessingData() 
        {
            string[] lines = ReadFileHelper.ReadTextFile(_pathInputFile);
            foreach (var line in lines)
            {
                string[] info = line.Split(':', ',');
                string nameBank = info[0];
                if (!_banks.ContainsKey(nameBank))
                {
                    Bank bank = CreateBank(nameBank);
                    CreateCustomer(info[1], DateTime.Parse(info[2]), nameBank);
                }
                else
                {
                    CreateCustomer(info[1], DateTime.Parse(info[2]), nameBank);
                }
            }
        }

        /// <summary>
        /// Отображает меню
        /// </summary>
        private static void ShowMenu() 
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("{0,10} {1}", "1:", "Добавить фамилию к фильтру");
            Console.WriteLine("{0,10} {1}", "2:", "Добавить имя к фильтру");
            Console.WriteLine("{0,10} {1}", "3:", "Добавить отчество к фильтру");
            Console.WriteLine("{0,10} {1}", "4:", "Добавить название банка к фильтру");
            Console.WriteLine("{0,10} {1}", "5:", "Отфильтровать");
            Console.WriteLine("{0,10} {1}", "6:", "Выйти");
        }

        /// <summary>
        /// Выполняет выбранное в меню действие
        /// </summary>
        private static void SelectAction() 
        {
            int selectedNumber = 0;
            int.TryParse(Console.ReadLine(), out selectedNumber);
            switch (selectedNumber)
            {
                case 1:
                    Console.WriteLine("Введите фамилию");
                    string secondName = Console.ReadLine();
                    _filters[0] = secondName;
                    ShowFilterConditions();
                    break;

                case 2:
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    _filters[1] = name;
                    ShowFilterConditions();
                    break;

                case 3:
                    Console.WriteLine("Введите отчество");
                    string patronymic = Console.ReadLine();
                    _filters[2] = patronymic;
                    ShowFilterConditions();
                    break;

                case 4:
                    Console.WriteLine("Введите название банка");
                    string bankName = Console.ReadLine();
                    _filters[3] = bankName;
                    ShowFilterConditions();
                    break;

                case 5:
                    Filter();
                    break;

                case 6:
                    _isRepeat = false;
                    break;
            }
        }

        /// <summary>
        /// Отображает условия фильтра
        /// </summary>
        private static void ShowFilterConditions() 
        {
            Console.WriteLine();
            Console.WriteLine("Условия фильтра: ");
            Console.WriteLine("{0} : {1,10}", "Фамилия", _filters[0]);
            Console.WriteLine("{0}: {1,10}", "Имя", _filters[1]);
            Console.WriteLine("{0}: {1,10}", "Отчество", _filters[2]);
            Console.WriteLine("{0}: {1,10}", "Название банка", _filters[3]);
        }

        private static Bank CreateBank(string nameBank) 
        {
            Bank bank = new Bank(nameBank);
            _banks.Add(nameBank, bank);
            return bank;
        }

        private static Customer CreateCustomer(string fullName, DateTime dateBirth,string nameBank) 
        {
            Customer customer = new Customer(fullName, dateBirth, nameBank);
            _banks[nameBank].Customers.Add(customer);
            return customer;
        }

        /// <summary>
        /// Фильтрует данные
        /// </summary>
        private static void Filter() 
        {
            List<Customer> customers = new List<Customer>();
            foreach (var bank in _banks.Values)
            {
                customers.AddRange(bank.Customers);
            }

            if (!String.IsNullOrWhiteSpace(_filters[0]))
                customers = CustomerFilter.FilterSecondName(customers, _filters[0]);

            if (!String.IsNullOrWhiteSpace(_filters[1]))
                customers = CustomerFilter.FilterName(customers, _filters[1]);

            if (!String.IsNullOrWhiteSpace(_filters[2]))
                customers = CustomerFilter.FilterPatronymic(customers, _filters[2]);

            if (!String.IsNullOrWhiteSpace(_filters[3]))
                customers = CustomerFilter.FilterBankName(customers, _filters[3]);

            WriteHelper.WriteXmlFile<List<Customer>>(_pathOutputFile, customers);
        }        
    }
}
