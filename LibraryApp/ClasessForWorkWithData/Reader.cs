using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    // Клас - читач, який буде зберігати інформацію про читача, таку як ім'я, адреса, контактна інформація та список взятих книг
    public class Reader
    {
        // Ім'я читача
        public string Name { get; set; }
        // Прізвище читача
        public string Lastname { get; set; }
        // Адреса читача
        public string Address { get; set; }
        // Номер телефону читача
        public string PhoneNumber { get; set; }
        // Електронна адреса читача
        public string Email { get; set; }
        // Інформація про активність читача в бібліотеці (дата початку та закінчення оренди та назва книги)
        public List<string> ReadersBooks { get; set; }

        // конструктор для заповнення інформації про читача, а саме: ім'я, прізвище, адреса, номер телефону, електронна адреса, та історія оренд книг читача
        public Reader(string name, string lastname, string address, string phoneNumber, string email, List<string> readerBooks)
        {
            Name = name;
            Lastname = lastname;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            ReadersBooks = readerBooks;
        }
        
    }
}
