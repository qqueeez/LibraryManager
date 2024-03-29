using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    // Клас BookLibrary – це Система управління бібліотекою, він буде зберігати бібліотеку та керувати нею,
    // міститиме методи для додавання нових книг до колекції бібліотеки,
    // реєстрації нових читачів, видачі та повернення книг, а також пошуку книг за різними критеріями.
    public class BookLibrary
    {
        // список книг в бібліотеці
        public List<Book> book_list = new List<Book>();
        // список секцій каталогу
        public List<CatalogSection> catalog_section = new List<CatalogSection>();
        // список читачів бібліотеки
        public List<Reader> reader_list = new List<Reader>();
        
        // Додати читача до списку читачів бібліотеки
        public void Add_New_Reader(Reader reader)
        {

        }

        // видача книги читачу та змінення статусу книги на "в оренді", а також занесення в історію книги та читача запису про оренду книги
        public void Give_Book(Book book)
        {

        }

        // Повернення книги читачем та змінення статусу книги, а також додавання в історію книги та читача дати повернення 
        public void Return_Book(Book book)
        {

        }


        // Присвоїти книзі id та додати її до бібліотеки
        public void AddBook_In_Library(Book book, ref List<int> RemovedBooks)
        {

        }

        // Присвоїти id каталогу та додати секцію каталогу до бібліотеки
        public void AddCatalogSection_In_Library(CatalogSection sect, ref List<int> RemovedSections)
        {
            
        }

        // Знайти каталог за його id
        public CatalogSection FindCatalogSection(int id)
        {
            
        }

        // Знайти книгу у бібліотеці
        public Book FindBook_In_Library(int id)
        {
            
        }

        // Видалити книгу з бібліотеки
        public void DeleteBook_In_Catalog(Book book)
        {
            
        }

        // Редагувати книгу. На вхід подається вже змінений об'єкт book
        public void EditBook_In_Catalog(Book book)
        {
            
        }

        // Видалити секцію каталогу з бібліотеки
        public void DeleteCatalog_In_Library(CatalogSection catalog)
        {
            
        }

        // Редагувати назву каталогу
        public void EditNameCatalog_In_Library(int cat_id, string newName)
        {
            
        }

        // Відв'язати книги від видаленої секції каталогу
        public void Unlink_Books_from_Deleted_Section(float id_RemovedSubsection)
        {
            
        }

        // Пошук книг за назвою
        public BookLibrary FunctionSearchBookInLibrary(string search_data)
        {

        }

    }
}
