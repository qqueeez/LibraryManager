using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClasessForWorkWithData
{
    // Клас BookLibrary – це Система управління бібліотекою, він буде зберігати бібліотеку та керувати нею,
    // міститиме методи для додавання нових книг до колекції бібліотеки,
    // реєстрації нових читачів, видачі та повернення книг, а також пошуку книг за різними критеріями.
    public class BookLibrary : IEnumerable
    {
        // список книг в бібліотеці
        public List<Book> book_list = new List<Book>();
        // список секцій каталогу
        public List<CatalogSection> catalog_section_list = new List<CatalogSection>();
        // список читачів бібліотеки
        public List<Reader> reader_list = new List<Reader>();

        // Метод потрібен для того щоб можна було перебирати об'єкти типу Book, CatalogSection, Reader за допомогою foreach всеередині об'єкта BookLibrary
        public IEnumerator GetEnumerator()
        {
            foreach (var book in book_list)
            {
                yield return book;
            }

            foreach (var section in catalog_section_list)
            {
                yield return section;
            }

            foreach (var reader in reader_list)
            {
                yield return reader;
            }
        }

        // ============================= КНИГИ ===============================

        // Присвоїти книзі id та додати її до бібліотеки
        public void AddBook_In_Library(Book book, ref List<int> RemovedBooks)
        {
            int id = 10000;

            // Якщо ще не існує жодної книги
            if (book_list.Count == 0)
            {
                book.Book_ID = id;
            }

            // Якщо попередньо було видалено якісь книги, присвоїти id видаленої книги
            else if (RemovedBooks.Count != 0)
            {
                book.Book_ID = RemovedBooks[0];
                RemovedBooks.Remove(0);
            }

            // Інакше - новий id = Максимальний id у списку книг + 1
            else
            {
                
                book.Book_ID = book_list.Max(b => b.Book_ID) + 1;
            }

            book_list.Add(book);
        }

        public void AddBook_In_Library(Book book)
        {
            book_list.Add(book);
        }

        // Видалити книгу з бібліотеки
        public void DeleteBook_In_Catalog(int bookID)
        {
            Book bookToRemove = FindBookByID(bookID);
            if (bookToRemove != null)
            {
                book_list.Remove(bookToRemove);
            }
        }


        // Редагувати книгу. На вхід подається вже змінений об'єкт book
        public void EditBook_In_Catalog(Book book)
        {
            for (int i = 0; i < book_list.Count; i++)
            {
                if (book_list[i].Book_ID == book.Book_ID)
                {
                    book_list[i] = book;
                    break;
                }
            }
        }

        // Знайти книгу по id
        public Book FindBookByID(int bookID)
        {
            Book book = book_list.Find(b => b.Book_ID == bookID);
            return book;
        }

        // Знайти книгу за назвою
        public Book FindBookByTitle(string book_title)
        {
            Book book = book_list.Find(b => b.Title == book_title);
            return book;
        }

        public BookLibrary FunctionSearchBookInLibrary(string search_data)
        {
            // Нова бібліотека, яка буде містити лише книги,які було знайдено та секції каталогу до яких вони прив'язані
            BookLibrary filteredLibrary = new BookLibrary();

            foreach (var book in this.book_list)
            {
                // Привести назву книги та рядок для пошуку до одного регістру 
                if (book.Title.ToLower().Contains(search_data.ToLower()))
                {
                    // Пройти по усім id прив'язаних до книги секцій
                    for (int i = 0; i < book.IdRelatedSections.Count; i++)
                    {
                        // Знайти об'єкт типу секція каталогу за id
                        CatalogSection section = this.FindCatalogSection(book.IdRelatedSections[i]);

                        // Визначити чи є вже така секція у відфільтрованій бібліотеці
                        CatalogSection resultSearchSection = filteredLibrary.FindCatalogSection(section.Catalog_ID);

                        // Додати секцію каталогу до бібліотеки з результатами пошуку, якщо такої секції ще там немає
                        if (resultSearchSection == null)
                        {
                            filteredLibrary.AddCatalogSection_In_Library(section);
                        }
                    }
                    // Додати книгу до бібліотеки з результатами пошуку
                    filteredLibrary.AddBook_In_Library(book);
                }
            }

            return filteredLibrary;

        }


        // ============================= КАТАЛОГИ ===============================

        // Присвоїти id каталогу та додати секцію каталогу до бібліотеки
        public void AddCatalogSection_In_Library(CatalogSection sect, ref List<int> RemovedSections)
        {
            int id = 0;

            // Якщо ще не існує жодної секції каталогу
            if (catalog_section_list.Count == 0)
            {
                sect.Catalog_ID = id;
            }

            // Якщо попередньо було видалено якісь секції каталогу, присвоїти id видаленої секції
            else if (RemovedSections.Count != 0)
            {
                sect.Catalog_ID = RemovedSections[0];

                // Видалити id зі списку який зберігає id видалених секцій каталогу
                RemovedSections.Remove(0);
            }

            // Якщо попередні умови не виконуються, присвоїти id новій секції за принципом id останньої секції у списку + 1
            else
            {
                sect.Catalog_ID = catalog_section_list[catalog_section_list.Count - 1].Catalog_ID + 1;

            }


            catalog_section_list.Add(sect);
        }

        public void AddCatalogSection_In_Library(CatalogSection sect)
        {
            catalog_section_list.Add(sect);
        }

        // Видалити секцію каталогу з бібліотеки
        public void DeleteCatalog_In_Library(int Catalog_ID)
        {
            CatalogSection CatalogToRemove = FindCatalogSection(Catalog_ID);
            if (CatalogToRemove != null)
            {
                catalog_section_list.Remove(CatalogToRemove);
            }
        }

        // Редагувати назву каталогу
        public void EditNameCatalog_In_Library(int cat_id, string newName)
        {
            // Знайти id розташування секції каталогу з потрібним Catalog_ID у списку catalog_section_list
            int id = catalog_section_list.FindIndex(sect => sect.Catalog_ID == cat_id);
            catalog_section_list[id].CatalogTitle = newName;
        }

        // Знайти секцію каталогу за назвою
        public CatalogSection FindCatalogSection(string title)
        {
            CatalogSection section = catalog_section_list.Find(s => s.CatalogTitle == title);
            return section;
        }

        // Знайти секцію каталогу за id
        public CatalogSection FindCatalogSection(int id)
        {
            CatalogSection section = catalog_section_list.Find(s => s.Catalog_ID == id);
            return section;
        }

        // ============================= ЧИТАЧІ ===============================

        // Додати читача до списку читачів бібліотеки
        public void Add_New_Reader(Reader reader, ref List<int> RemovedReaders)
        {
            int id = 100000;

            // Якщо ще не існує жодного читача
            if (reader_list.Count == 0)
            {
                reader.Reader_ID = id;
            }

            // Якщо попередньо було видалено читачів, присвоїти id видаленого читача
            else if (RemovedReaders.Count != 0)
            {
                reader.Reader_ID = RemovedReaders[0];

                // Видалити id зі списку який зберігає id видалених читачів
                RemovedReaders.Remove(0);
            }

            // Якщо попередні умови не виконуються, присвоїти id новому читачу за принципом id останнього читача у списку + 1
            else
            {
                reader.Reader_ID = reader_list[reader_list.Count - 1].Reader_ID + 1;

            }


            reader_list.Add(reader);
        }

        // Редагувати читача. На вхід подається вже змінений об'єкт reader
        public void Edit_Reader(Reader reader)
        {
            for (int i = 0; i < reader_list.Count; i++)
            {
                if (reader_list[i].Reader_ID == reader.Reader_ID)
                {
                    reader_list[i] = reader;
                    break;
                }
            }
        }

        // Видалити читача з бібліотеки
        public void DeleteReader(int userID)
        {
            Reader reader = FindReader(userID);

            reader_list.Remove(reader);
        }

        // Знайти читача по ID
        public Reader FindReader(int id)
        {
            Reader reader = reader_list.Find(r => r.Reader_ID == id);
            return reader;
        }

        // видача книги читачу та змінення статусу книги на "в оренді",
        // а також занесення в історію книги та читача запису про оренду книги
        public void Give_Book(List<RentHistory> operations_list)
        {
            foreach (RentHistory operation in operations_list)
            {
                Book book = FindBookByID(operation.Book_id);
                Reader reader = FindReader(operation.User_id);

                book.isFree = false;
                book.Rent_history.Add(operation);
                reader.Rent_history.Add(operation);
            }
        }


        // Відв'язати книги від видаленої секції каталогу
        public void Unlink_Books_from_Deleted_Section(float id_RemovedSubsection)
        {
            
        }

        // Повернення книги читачем та змінення статусу книги, а також додавання в історію книги та читача дати повернення 
        public void Return_Book(Book book)
        {

        }

    }
}
