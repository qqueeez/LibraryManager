using ClasessForWorkWithData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class InfoAboutBookForm : Form
    {
        BookLibrary library;
        private int Book_ID { get; set; }

        public event EventHandler BookDeleted;

        protected virtual void OnBookDeleted()
        {
            // Перевірка чи є підписники на подію
            if (BookDeleted != null)
            {
                // Виклик події
                BookDeleted(this, EventArgs.Empty);
            }
        }

        public InfoAboutBookForm(BookLibrary library, int book_ID)
        {
            this.library = library;
            Book_ID = book_ID;
            InitializeComponent();
            FillBookInfo(book_ID);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FillBookInfo(int bookID)
        {
            // Знайти книгу по id
            Book book = library.FindBookByID(bookID);

            // Якщо книгу знайдено вивести інформацію
            if (book != null)
            {
                textBox1.Text = book.Title;
                textBox2.Text = book.Author;
                textBox3.Text = book.Genre;
                textBox4.Text = book.Year.ToString();
            }
            else
            {
                // Якщо книга не знайдена
                MessageBox.Show("Книгу не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Закрити форму
                this.Close();
            }
        }


        private void InfoAboutBookForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;

            Functions.AddInfoInDataGridView(library, ref dataGridView1, Book_ID);
        }

        private void ButtonDeleteBook_Click(object sender, EventArgs e)
        {
            library.DeleteBook_In_Catalog(Book_ID);
            OnBookDeleted();
            this.Close();
        }
    }
}
