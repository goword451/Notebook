using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    class Notebook
    {
        private static List<Contact> notebook = new List<Contact>();
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Создать контакт");
                Console.WriteLine("2. Редактирование контакта");
                Console.WriteLine("3. Удаление контакта");
                Console.WriteLine("4. Просмотр контакта");
                Console.WriteLine("5. Просмотр всех контактов");
                int phMenu;
                string sIn = Console.ReadLine();
                if (int.TryParse(sIn, out phMenu) == false )
                {
                    while (int.TryParse(sIn, out phMenu) == false)
                    {
                        Console.WriteLine("Ничего не выбрано. Выберете пункт:");
                        sIn = Console.ReadLine();
                    }
                }
                phMenu = int.Parse(sIn);
                int i = 0;
                switch (phMenu)
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
                        Console.WriteLine("Введите дату рождения (необязательно, разделять знаком точки):");
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
                        if(notebook.Count != 0)
                        {
                            Console.WriteLine("Введите ID контакта");
                            int editId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Выберете какое поле требуется изменить:");
                            Console.WriteLine("1. Фамилия");
                            Console.WriteLine("2. Имя");
                            Console.WriteLine("3. Отчество");
                            Console.WriteLine("4. Номер телефона");
                            Console.WriteLine("5. Страна");
                            Console.WriteLine("6. Дата рождения");
                            Console.WriteLine("7. Организация");
                            Console.WriteLine("8. Должность");
                            Console.WriteLine("9. Примечание");
                            Console.WriteLine("10. Назад в меню");
                            int phEdit;
                            string sInEd = Console.ReadLine();
                            if (int.TryParse(sInEd, out phEdit) == false)
                            {
                                while (int.TryParse(sIn, out phEdit) == false)
                                {
                                    Console.WriteLine("Ничего не выбрано. Выберете пункт:");
                                    sIn = Console.ReadLine();
                                }
                            }
                            phEdit = int.Parse(sInEd);
                            switch (phEdit)
                            {
                                case 1:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новую фамилию (обязательно):");
                                            string surenameEdit = Console.ReadLine();
                                            string oldSurename = edContact.Surename;
                                            edContact.Surename = surenameEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Surename = oldSurename;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 2:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новое имя (обязательно):");
                                            string nameEdit = Console.ReadLine();
                                            string oldName = edContact.Name;
                                            edContact.Surename = nameEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Name = oldName;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 3:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новое отчество (необязательно):");
                                            string secondnameEdit = Console.ReadLine();
                                            string oldSecondname = edContact.Secondname;
                                            edContact.Surename = secondnameEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Secondname = oldSecondname;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 4:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новый номер телефона (обязательно, только цифры):");
                                            string phNumEdit = Console.ReadLine();
                                            string oldPhoneNum = edContact.PhoneNum;
                                            edContact.PhoneNum = phNumEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.PhoneNum = oldPhoneNum;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 5:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новую страну (обязательно):");
                                            string countryEdit = Console.ReadLine();
                                            string oldCountry = edContact.Country;
                                            edContact.Country = countryEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Country = oldCountry;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 6:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новую дату рождения (необязательно, разделять знаком точки):");
                                            string birthdayEdit = Console.ReadLine();
                                            string oldBirthday = edContact.Birthday;
                                            edContact.Birthday = birthdayEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Country = oldBirthday;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 7:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новую организацию (необязательно):");
                                            string orgEdit = Console.ReadLine();
                                            string oldOrg = edContact.Organization;
                                            edContact.Organization = orgEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Organization = oldOrg;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 8:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новую должность (необязательно):");
                                            string posEdit = Console.ReadLine();
                                            string oldPos = edContact.Position;
                                            edContact.Position = posEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Position = oldPos;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 9:
                                    foreach (Contact edContact in notebook)
                                    {
                                        if (edContact.Id == editId)
                                        {
                                            Console.WriteLine("Введите новое примечание (необязательно):");
                                            string noteEdit = Console.ReadLine();
                                            string oldNote = edContact.Note;
                                            edContact.Note = noteEdit;
                                            var resultsEd = new List<ValidationResult>();
                                            var contextEd = new ValidationContext(edContact);
                                            if (!Validator.TryValidateObject(edContact, contextEd, resultsEd, true))
                                            {
                                                edContact.Note = oldNote;
                                                foreach (var error in resultsEd)
                                                {
                                                    Console.WriteLine(error.ErrorMessage);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case 10:
                                    break;

                                default:
                                    Console.WriteLine("Данный пункт меню отсутствует");
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Контактов нет");
                            break;
                        }
                        
                    case 3:
                        Console.WriteLine("Введите ID контакта");
                        int removeId = int.Parse(Console.ReadLine());
                        RemoveContact(removeId, notebook);
                        break;

                    case 4:
                        Console.WriteLine("Введите ID контакта");
                        int showId = int.Parse(Console.ReadLine());
                        ShowContact(showId, notebook);
                        break;

                    case 5:
                        ShowContacts(notebook);
                        break;

                    default:
                        Console.WriteLine("Данная команда отсутствует");
                        break;
                }
            }
            
        }

        private static void RemoveContact(int id, List<Contact> notebook)
        {
                if (id < 0)
                {
                    Console.WriteLine("ID должно быть положительным или 0");
                }

                if (notebook.Count == 0)
                {
                    Console.WriteLine("Контактов нет");
                }

                if (id > notebook.Count - 1)
                {
                    Console.WriteLine("Такого номера не существует");
                }

                notebook.RemoveAt(id);
        }

        private static void ShowContact(int id, List<Contact> notebook)
        {
            if (id < 0)
            {
                Console.WriteLine("ID должно быть положительным или 0");
            }

            if (notebook.Count == 0)
            {
                Console.WriteLine("Контактов нет");
            }

            if (id > notebook.Count - 1)
            {
                Console.WriteLine("Такого номера не существует");
            }

            Console.WriteLine();
            foreach(Contact contact in notebook)
            {
                if (contact.Id == id)
                {
                    Console.WriteLine("a. ID: " + contact.Id);
                    Console.WriteLine("b. Фамилия: " + contact.Surename);
                    Console.WriteLine("c. Имя: " + contact.Name);
                    Console.WriteLine("d. Отчество: " + contact.Secondname);
                    Console.WriteLine("e. Номер телефона: " + contact.PhoneNum);
                    Console.WriteLine("f. Страна: " + contact.Country);
                    Console.WriteLine("g. День рождения: " + contact.Birthday);
                    Console.WriteLine("h. Организация: " + contact.Organization);
                    Console.WriteLine("i. Должность: " + contact.Position);
                    Console.WriteLine("j. Примечание: " + contact.Note);
                    Console.WriteLine();
                }
            }
        }
        private static void ShowContacts(List<Contact> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Контактов нет");
            }
            else
            {
                Console.WriteLine();
                foreach (Contact contact in notebook)
                {
                    Console.WriteLine("a. Фамилия: " + contact.Surename);
                    Console.WriteLine("b. Имя: " + contact.Name);
                    Console.WriteLine("c. Номер телефона: " + contact.PhoneNum);
                    Console.WriteLine();
                }
            }
        }
    }
}


