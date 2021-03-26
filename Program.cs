using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Notebook_1
{
    class Notebook
    {
        public static List<Contact> notebook = new List<Contact>();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Создать контакт");
                Console.WriteLine("2. Редактирование контакта");
                Console.WriteLine("3. Удаление контакта");
                Console.WriteLine("4. Просмотр контакта");
                Console.WriteLine("5. Просмотр всех контактов");
                int n = int.Parse(Console.ReadLine());
                int i = 0;
                

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Введите фамилию (обязательно):");
                        string surename = Console.ReadLine();
                        Console.WriteLine("Введите имя (обязательно):");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите отчество (необязательно):");
                        string secondname = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона (обязательно, только цифры):");
                        string phoneNum = Console.ReadLine();
                        Console.WriteLine("Введите страну (обязательно):");
                        string country = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения (необязательно):");
                        string birthday = Console.ReadLine();
                        Console.WriteLine("Введите организацию (необязательно):");
                        string organization = Console.ReadLine();
                        Console.WriteLine("Введите должность (необязательно):");
                        string position = Console.ReadLine();
                        Console.WriteLine("Введите примечание (необязательно):");
                        string note = Console.ReadLine();
                        Contact man = new Contact(surename, name, secondname, phoneNum, country, birthday, organization, position, note);
                        var results = new List<ValidationResult>();
                        var context = new ValidationContext(man);
                        if (!Validator.TryValidateObject(man, context, results, true))
                        {
                            foreach (var error in results)
                            {
                                Console.WriteLine(error.ErrorMessage);
                            }
                        }
                        else if (Validator.TryValidateObject(man, context, results, true))
                        {
                            man.Id = i;
                            notebook.Add(man);
                            i++;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите ID контакта");
                        int r = int.Parse(Console.ReadLine());
                        Console.WriteLine("Выберете какое поле требуется изменить:");
                        Console.WriteLine("1. Имя");
                        Console.WriteLine("2. Фамилию");
                        Console.WriteLine("3. Отчество");
                        Console.WriteLine("4. Номер телефона");
                        Console.WriteLine("5. Страна");
                        Console.WriteLine("6. Дата рождения");
                        Console.WriteLine("7. Организация");
                        Console.WriteLine("8. Должность");
                        Console.WriteLine("9. Примечание");
                        int m = int.Parse(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine("Введите ID контакта");
                        int j = int.Parse(Console.ReadLine());
                        RemoveContact(j, notebook);
                        break;

                    case 4:
                        Console.WriteLine("Введите ID контакта");
                        int k = int.Parse(Console.ReadLine());
                        WatchContact(k, notebook);
                        break;

                    case 5:
                        WatchContacts(notebook);
                        break;

                    default:
                        Console.WriteLine("Данная команда отсутствует");
                        break;
                }
            }
            
        }

        public static void RemoveContact(int n, List<Contact> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Контактов нет");
            }

            if (n > notebook.Count - 1)
            {
                Console.WriteLine("Такого номера не существует");
            }

            notebook.RemoveAt(n);
        }

        public static void WatchContact(int n, List<Contact> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Контактов нет");
            }

            if (n > notebook.Count - 1)
            {
                Console.WriteLine("Такого номера не существует");
            }

            Console.WriteLine();
            foreach(var item in notebook)
            {
                if (item.Id == n)
                {
                    Console.WriteLine("a. ID: " + item.Id);
                    Console.WriteLine("b. Фамилия: " + item.Surename);
                    Console.WriteLine("c. Имя: " + item.Name);
                    Console.WriteLine("d. Отчество: " + item.Secondname);
                    Console.WriteLine("e. Номер телефона: " + item.PhoneNum);
                    Console.WriteLine("f. Страна: " + item.Country);
                    Console.WriteLine("g. День рождения: " + item.Birthday);
                    Console.WriteLine("h. Организация: " + item.Organization);
                    Console.WriteLine("i. Должность: " + item.Position);
                    Console.WriteLine("j. Примечание: " + item.Note);
                    Console.WriteLine();
                }
            }
        }
        public static void WatchContacts(List<Contact> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Контактов нет");
            }
            else
            {
                Console.WriteLine();
                foreach (var item in notebook)
                {
                    Console.WriteLine("a. Фамилия: " + item.Surename);
                    Console.WriteLine("b. Имя: " + item.Name);
                    Console.WriteLine("c. Номер телефона: " + item.PhoneNum);
                    Console.WriteLine();
                }
            }
        }
    }


    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Не введена фамилия")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина фамилии")]
        [RegularExpression(@".*[А-яЁё].*", ErrorMessage = "В фамилии должны быть только русские буквы")]
        public string Surename { get; set; }
        [Required(ErrorMessage = "Не введено имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        [RegularExpression(@".*[А-яЁё].*", ErrorMessage = "В имени должны быть только русские буквы")]
        public string Name { get; set; }
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Недопустимая длина отчества")]
        [RegularExpression(@".*[А-яЁё].*", ErrorMessage = "В отчестве должны быть только русские буквы")]
        public string Secondname { get; set; }
        [Required(ErrorMessage = "Не введен номер")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "Недопустимая длина номера телефона")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "В номере телефона должны быть только цифры")]
        public string PhoneNum { get; set; }
        [Required(ErrorMessage = "Не введена страна")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия страны")]
        [RegularExpression(@".*[А-яЁё].*", ErrorMessage = "В названии страны должны быть только русские буквы")]
        public string Country { get; set; }
        [RegularExpression(@"\b(?<day>\d{1,2})/(?<month>\d{1,2})/(?<year>\d{2,4})\b", ErrorMessage = "Неверно введена дата рождения")]
        public string Birthday { get; set; }
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Недопустимая длина названия организации")]
        [RegularExpression(@".*[А-яЁё].*", ErrorMessage = "В названии организации должны быть только русские буквы")]
        public string Organization { get; set; }
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Недопустимая длина должности")]
        public string Position { get; set; }
        public string Note { get; set; }

        public Contact(string surename, string name, string secondname, string phoneNum, string country, string birthday, string organization, string position, string note)
        {
            Surename = surename; 
            Name = name; 
            Secondname = secondname; 
            PhoneNum = phoneNum; 
            Country = country;
            Birthday = birthday;
            Organization = organization;
            Position = position;
            Note = note;
        }
    }
}


