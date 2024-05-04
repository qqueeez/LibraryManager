using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClasessForWorkWithData
{
    // Цей клас повинен бути фактично структурою об'кта - книга. Він не буде містити жодних методів,
    // а тільки властивості та конструктори для заповнення цих властивостей даними. 
    // Кожна книга повинна містити інформацію про її назву, автора, жанр, рік написання, статус аренди.
    public class Book
    {
        // id книги
        public int Book_ID { get; set; }
        // список id секцій, до яких прив'язана книга
        public List<int> IdRelatedSections { get; set; }
        // Назва книги
        public string Title { get; set; }
        // Автор
        public string Author { get; set; }
        // Жанр
        public string Genre { get; set; }
        // Рік написання
        public int Year { get; set; }
        // статус оренди книги 
        public string Rent_status { get; set; }
        // історія оренди книги читачами
        public List<RentHistory> Rent_history { get; set; } = new List<RentHistory>();


        // конструктор для заповнення назви книги, автору, жанру, року написання, статусу оренди та історії оренди
        public Book(string title, string author, string genre, int year, string rent_status, List<RentHistory> rent_history)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Rent_status = rent_status;
            Rent_history = rent_history;
        }

        // конструктор для заповнення назви книги, автору, жанру, року написання та списку секцій 
        public Book(string title, string author, string genre, int year, List<int> id_relatedSections)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            IdRelatedSections = id_relatedSections;
        }
    }
}
