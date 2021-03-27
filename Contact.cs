using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Не введена фамилия")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина фамилии")]
        [RegularExpression(@"[А-Яа-яёЁё]*", ErrorMessage = "В фамилии должны быть только русские буквы")]
        public string Surename { get; set; }
        [Required(ErrorMessage = "Не введено имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        [RegularExpression(@"[А-Яа-яёЁё]*", ErrorMessage = "В имени должны быть только русские буквы")]
        public string Name { get; set; }
        [StringLength(15, MinimumLength = 0, ErrorMessage = "Недопустимая длина отчества")]
        [RegularExpression(@"[А-Яа-яёЁё]*", ErrorMessage = "В отчестве должны быть только русские буквы")]
        public string Secondname { get; set; }
        [Required(ErrorMessage = "Не введен номер")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "Недопустимая длина номера телефона")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "В номере телефона должны быть только цифры")]
        public string PhoneNum { get; set; }
        [Required(ErrorMessage = "Не введена страна")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Недопустимая длина названия страны")]
        [RegularExpression(@"[А-Яа-яёЁё]*", ErrorMessage = "В названии страны должны быть только русские буквы")]
        public string Country { get; set; }
        [RegularExpression(@"\b(?<day>\d{1,2}).(?<month>\d{1,2}).(?<year>\d{2,4})\b", ErrorMessage = "Неверный формат ввода даты рождения")]
        public string Birthday { get; set; }
        [StringLength(10, MinimumLength = 0, ErrorMessage = "Недопустимая длина названия организации")]
        [RegularExpression(@"[А-Яа-яёЁё]*", ErrorMessage = "В названии организации должны быть только русские буквы")]
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


