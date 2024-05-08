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
        // id читача
        public int Reader_ID { get; set; }
        // Повне ім'я читача
        public string Full_name { get; set; }
        // Адреса читача
        public string Address { get; set; }
        // Номер телефону читача
        public string PhoneNumber { get; set; }
        // Електронна адреса читача
        public string Email { get; set; }
        // Інформація про активність читача в бібліотеці (дата початку та закінчення оренди та назва книги)
        public List<RentHistory> Rent_history { get; set; } = new List<RentHistory>();

        // конструктор для заповнення інформації про читача, а саме: ім'я, прізвище, адреса, номер телефону, електронна адреса, та історія оренд книг читача
        public Reader(string full_name, string address, string phoneNumber, string email, List<RentHistory> rentHistory)
        {
            Full_name = full_name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Rent_history = rentHistory;
        }

        public Reader(string full_name, string address, string phoneNumber, string email)
        {
            Full_name = full_name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

    }
}
