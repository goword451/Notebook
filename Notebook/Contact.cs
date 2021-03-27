using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotebookApp
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не введена фамилия")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина фамилии")]
        [RegularExpression(@"[А-Яа-яЁё-]*", ErrorMessage = "В фамилии должны быть только русские буквы")]
        public string Surename { get; set; }
        [Required(ErrorMessage = "Не введено имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        [RegularExpression(@"[А-Яа-яЁё]*", ErrorMessage = "В имени должны быть только русские буквы")]
        public string Name { get; set; }
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Недопустимая длина отчества")]
        [RegularExpression(@"[А-Яа-яЁё]*", ErrorMessage = "В отчестве должны быть только русские буквы")]
        public string Secondname { get; set; }
        [Required(ErrorMessage = "Не введен номер")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "Недопустимая длина номера телефона")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "В номере телефона должны быть только цифры")]
        public string PhoneNum { get; set; }
        [Required(ErrorMessage = "Не введена страна")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия страны")]
        [RegularExpression(@"[А-Яа-яЁё -]*", ErrorMessage = "В названии страны недопустимые символы. Дропустимы только русские буквы, дефис и пробел")]
        public string Country { get; set; }
        [RegularExpression(@"\b(?<day>\d{1,2}).(?<month>\d{1,2}).(?<year>\d{2,4})\b", ErrorMessage = "Неверный формат ввода даты рождения")]
        public string Birthday { get; set; }
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Недопустимая длина названия организации")]
        [RegularExpression(@"[А-Яа-яЁё "".()-]*", ErrorMessage = "В названии организации должны быть только русские буквы")]
        public string Organization { get; set; }
        [StringLength(30, MinimumLength = 0, ErrorMessage = "Недопустимая длина должности")]
        [RegularExpression(@"[А-Яа-яЁё -]*", ErrorMessage = "В должности должны быть только русские буквы")]
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("a. ID: " + Id)
                .AppendLine("b. Фамилия: " + Surename)
                .AppendLine("c. Имя: " + Name)
                .AppendLine("d. Отчество: " + Secondname)
                .AppendLine("e. Номер телефона: " + PhoneNum)
                .AppendLine("f. Страна: " + Country)
                .AppendLine("g. День рождения: " + Birthday)
                .AppendLine("h. Организация: " + Organization)
                .AppendLine("i. Должность: " + Position)
                .AppendLine("j. Примечание: " + Note)
                .AppendLine("");
            return sb.ToString();
        }

        public string ShortDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("a. Фамилия: " + Surename)
                .AppendLine("b. Имя: " + Name)
                .AppendLine("c. Номер телефона: " + PhoneNum)
                .AppendLine("");
            return sb.ToString();
        }
    }
}


