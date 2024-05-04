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
        }

        private void FillBookInfo(int bookID)
        {
            // Находим книгу по её ID
            Book book = library.FindBookByID(bookID);

            // Если книга найдена, заполняем текстовые поля информацией о книге
            if (book != null)
            {
                textBox1.Text = book.Title;
                textBox2.Text = book.Author;
                textBox3.Text = book.Genre;
                textBox4.Text = book.Year.ToString();
            }
            else
            {
                // Если книга не найдена, выводим сообщение
                MessageBox.Show("Книга не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Закрываем форму, так как информацию о книге не удалось заполнить
            }
        }


        private void InfoAboutBookForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id", "Номер запису");
            dataGridView1.Columns.Add("full_client_name", "Клієнт");
            dataGridView1.Columns.Add("client_number", "Номер телефону");
            dataGridView1.Columns.Add("rent_period", "Період оренди");
            Functions.AddInfoInDataGridView(library, ref dataGridView1);
        }

        private void ButtonDeleteBook_Click(object sender, EventArgs e)
        {
            library.DeleteBook_In_Catalog(Book_ID);
            OnBookDeleted();
            this.Close();
        }
    }
}
