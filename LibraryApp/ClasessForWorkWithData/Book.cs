using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    // Цей клас повинен бути фактично структурою об'кта - книга. Він не буде містити жодних методів,
    // а тільки властивості та конструктори для заповнення цих властивостей даними. 
    // Кожна книга повинна містити інформацію про її назву, автора, жанр, рік написання, статус аренди.
    public class Book
    {
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
        public List<string> Rent_history { get; set; }
        // id книги
        public int Book_ID { get; set; }

        // конструктор для заповнення назви книги, автору, жанру, року написання, статусу оренди та історії оренди
        public Book(string title, string author, string genre, int year, string rent_status, List<string> rent_history)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Rent_status = rent_status;
            Rent_history = rent_history;
        }
    }
}
