using System;
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
            while(true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Создать контакт");
                Console.WriteLine("2. Редактирование контакта");
                Console.WriteLine("3. Удаление контакта");
                Console.WriteLine("4. Просмотр контакта");
                Console.WriteLine("5. Просмотр всех контактов");
                int pharagraphMenu;
                string strInput = Console.ReadLine();
                if (int.TryParse(strInput, out pharagraphMenu) == false )
                {
                    while (int.TryParse(strInput, out pharagraphMenu) == false)
                    {
                        Console.WriteLine("Ничего не выбрано. Выберете пункт:");
                        strInput = Console.ReadLine();
                    }
                }
                pharagraphMenu = int.Parse(strInput);
                int i = 0;
                switch (pharagraphMenu)
                {
                    case 1:
                        Contact man = CreateContact();
                        if (ValidateModel(man))
                        {
                            man.Id = i++;
                            notebook.Add(man);
                        }
                        break;

                    case 2:
                        if (notebook.Count != 0)
                        {
                            EditContacts(notebook);
                        }
                        else
                        {
                            Console.WriteLine("Нет контактов");
                        }
                        break;
                        
                    case 3:
                        RemoveContact(GetContactId(), notebook);
                        break;

                    case 4:
                        ShowContact(GetContactId(), notebook);
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

        private static int GetContactId()
        {
            Console.WriteLine("Введите ID контакта");
            while(true)
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

        private static bool CheckContactId(int id, int count)
        {
            bool flag = true;
            if (id < 0)
            {
                Console.WriteLine("ID должно быть положительным или 0");
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
                int pharagraphEdit;
                string strInputEdit = Console.ReadLine();
                if (int.TryParse(strInputEdit, out pharagraphEdit) == false)
                {
                    while (int.TryParse(strInputEdit, out pharagraphEdit) == false)
                    {
                        Console.WriteLine("Ничего не выбрано. Выберете пункт:");
                        strInputEdit = Console.ReadLine();
                    }
                }
                pharagraphEdit = int.Parse(strInputEdit);
                switch (pharagraphEdit)
                {
                    case 1:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новую фамилию (обязательно):");
                                string oldSurename = editContact.Surename;
                                editContact.Surename = Console.ReadLine();
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Surename = oldSurename;
                                }
                            }
                        }
                        break;

                    case 2:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новое имя (обязательно):");
                                string oldName = editContact.Name;
                                string nameEdit = Console.ReadLine();
                                editContact.Name = nameEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Name = oldName;
                                }
                            }
                        }
                        break;

                    case 3:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новое отчество (необязательно):");
                                string oldSecondname = editContact.Secondname;
                                string secondnameEdit = Console.ReadLine();
                                editContact.Secondname = secondnameEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Secondname = oldSecondname;
                                }
                            }
                        }
                        break;

                    case 4:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новый номер телефона (обязательно, только цифры):");
                                string oldPhoneNum = editContact.PhoneNum;
                                string phoneNumEdit = Console.ReadLine();
                                editContact.PhoneNum = phoneNumEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.PhoneNum = oldPhoneNum;
                                }
                            }
                        }
                        break;

                    case 5:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новую страну (обязательно):");
                                string oldCountry = editContact.Country;
                                string countryEdit = Console.ReadLine();
                                editContact.Country = countryEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Country = oldCountry;
                                }
                            }
                        }
                        break;

                    case 6:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новую дату рождения (необязательно, разделять знаком точки):");
                                string oldBirthday = editContact.Birthday;
                                string birthdayEdit = Console.ReadLine();
                                editContact.Birthday = birthdayEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Birthday = oldBirthday;
                                }
                            }
                        }
                        break;

                    case 7:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новую организацию (необязательно):");
                                string oldOrganiazation = editContact.Organization;
                                string organizationEdit = Console.ReadLine();
                                editContact.Organization = organizationEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Organization = oldOrganiazation;
                                }
                            }
                        }
                        break;

                    case 8:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новую должность (необязательно):");
                                string oldPosition = editContact.Position;
                                string positionEdit = Console.ReadLine();
                                editContact.Position = positionEdit;
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Position = oldPosition;
                                }
                            }
                        }
                        break;

                    case 9:
                        foreach (Contact editContact in notebook)
                        {
                            if (editContact.Id == editId)
                            {
                                Console.WriteLine("Введите новое примечание (необязательно):");
                                string oldNote = editContact.Note;
                                string noteEdit = Console.ReadLine();
                                editContact.Note = noteEdit;
                                var resultsEd = new List<ValidationResult>();
                                var contextEd = new ValidationContext(editContact);
                                if (ValidateModel(editContact) == false)
                                {
                                    editContact.Note = oldNote;
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


            }
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
    }
}


