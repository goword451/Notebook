using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NotebookApp
{
    public class Notebook
    {
        private static List<Contact> notebook = new List<Contact>();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(ShowMainMenu());
                int pharagraphMenu = GetMenuPharagraph();
                int i = 0;
                switch (pharagraphMenu)
                {
                    case 1:
                        Contact man = CreateContact();
                        if (ValidateModel(man))
                        {
                            notebook.Add(man);
                            man.Id = i++;
                        }
                        break;

                    case 2:
                        if (IsEmptyNotebook(notebook) == false)
                        {
                            EditContacts(notebook);
                        }
                        break;

                    case 3:
                        if (IsEmptyNotebook(notebook) == false)
                        {
                            RemoveContact(GetContactId(), notebook);
                        }
                        break;

                    case 4:
                        if (IsEmptyNotebook(notebook) == false)
                        {
                            ShowContact(GetContactId(), notebook);
                        }
                        break;

                    case 5:
                        if (IsEmptyNotebook(notebook) == false)
                        {
                            ShowContacts(notebook);
                        }
                        break;

                    default:
                        Console.WriteLine("Данная команда отсутствует");
                        break;
                }
            }

        }
        #region Interfaces
        private static string ShowMainMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Выберите команду:")
                .AppendLine("1. Создать контакт")
                .AppendLine("2. Редактирование контакта")
                .AppendLine("3. Удаление контакта")
                .AppendLine("4. Просмотр контакта")
                .AppendLine("5. Просмотр всех контактов");
            return sb.ToString();
        }

        private static string ShowEditMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Выберете какое поле требуется изменить:")
                .AppendLine("1. Фамилия")
                .AppendLine("2. Имя")
                .AppendLine("3. Отчество")
                .AppendLine("4. Номер телефона")
                .AppendLine("5. Страна")
                .AppendLine("6. Дата рождения")
                .AppendLine("7. Организация")
                .AppendLine("8. Должность")
                .AppendLine("9. Примечание")
                .AppendLine("10. Назад в меню");
            return sb.ToString();
        }
        #endregion

        #region Getters
        private static int GetContactId()
        {
            Console.WriteLine("Введите ID контакта");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    return id;
                }
                else
                {
                    Console.WriteLine("Введён неверный ID. Повторите ввод:");
                }
            }
        }

        private static int GetMenuPharagraph()
        {
            Console.WriteLine("Выберете пункт меню:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int menuPharagraph))
                {
                    return menuPharagraph;
                }
                else
                {
                    Console.WriteLine("Введён неверный ID. Повторите ввод:");
                }
            }
        }
        #endregion

        #region Checking and Validation
        private static bool CheckContactId(int id, int count)
        {
            bool flag = true;
            if (id < 0)
            {
                Console.WriteLine("ID должно быть положительным");
                flag = false;
            }

            if (count == 0)
            {
                Console.WriteLine("Контактов нет");
                flag = false;
            }

            if (id > count - 1)
            {
                Console.WriteLine("Такого номера не существует");
                flag = false;
            }

            return flag;
        }
        private static bool IsEmptyNotebook(List<Contact> notebook)
        {
            if (notebook.Count == 0)
            {
                Console.WriteLine("Нет контактов");
                return true;
            }
            return false;
        }

        private static bool ValidateModel(Contact contact)
        {
            var resultsEd = new List<ValidationResult>();
            var contextEd = new ValidationContext(contact);
            if (!Validator.TryValidateObject(contact, contextEd, resultsEd, true))
            {
                foreach (var error in resultsEd)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            return true;
        }

        #endregion

        #region Actions
        private static void RemoveContact(int id, List<Contact> notebook)
        {
            if (CheckContactId(id, notebook.Count))
            {
                notebook.RemoveAt(id);
            }
        }

        private static void ShowContact(int id, List<Contact> notebook)
        {
            if (CheckContactId(id, notebook.Count))
            {
                Console.WriteLine();
                Console.WriteLine(notebook.Single(x => x.Id == id));
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
                    Console.WriteLine(contact.ShortDescription());
                }
            }
        }
        private static Contact CreateContact()
        {
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
            return man;
        }

        private static void EditContacts(List<Contact> notebook)
        {
            if (notebook.Count != 0)
            {
                int editId = GetContactId();
                Console.WriteLine(ShowEditMenu());
                int pharagraphEdit = GetMenuPharagraph();
                Contact editContact = notebook.Single(x => x.Id == editId);
                switch (pharagraphEdit)
                {
                    case 1:
                        Console.WriteLine("Введите новую фамилию (обязательно):");
                        string oldSurename = editContact.Surename;
                        editContact.Surename = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Surename = oldSurename;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите новое имя (обязательно):");
                        string oldName = editContact.Name;
                        editContact.Name = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Name = oldName;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Введите новое отчество (необязательно):");
                        string oldSecondname = editContact.Secondname;
                        editContact.Secondname = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Secondname = oldSecondname;
                        }

                        break;

                    case 4:
                        Console.WriteLine("Введите новый номер телефона (обязательно, только цифры):");
                        string oldPhoneNum = editContact.PhoneNum;
                        editContact.PhoneNum = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.PhoneNum = oldPhoneNum;
                        }

                        break;

                    case 5:
                        Console.WriteLine("Введите новую страну (обязательно):");
                        string oldCountry = editContact.Country;
                        editContact.Country = Console.ReadLine(); ;
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Country = oldCountry;
                        }

                        break;

                    case 6:
                        Console.WriteLine("Введите новую дату рождения (необязательно, разделять знаком точки):");
                        string oldBirthday = editContact.Birthday;
                        editContact.Birthday = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Birthday = oldBirthday;
                        }
                        break;

                    case 7:
                        Console.WriteLine("Введите новую организацию (необязательно):");
                        string oldOrganiazation = editContact.Organization;
                        editContact.Organization = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Organization = oldOrganiazation;
                        }
                        break;

                    case 8:
                        Console.WriteLine("Введите новую должность (необязательно):");
                        string oldPosition = editContact.Position;
                        editContact.Position = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Position = oldPosition;
                        }
                        break;

                    case 9:
                        Console.WriteLine("Введите новое примечание (необязательно):");
                        string oldNote = editContact.Note;
                        editContact.Note = Console.ReadLine();
                        if (ValidateModel(editContact) == false)
                        {
                            editContact.Note = oldNote;
                        }
                        break;

                    case 10:
                        break;

                    default:
                        Console.WriteLine("Данный пункт меню отсутствует");
                        break;
                }
            }
        }

        #endregion

        
    }
}


