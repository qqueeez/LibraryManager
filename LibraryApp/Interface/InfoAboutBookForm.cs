using ClasessForWorkWithData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class InfoAboutBookForm : Form
    {
        BookLibrary library;
        private int Book_ID { get; set; }

        public event EventHandler BookDeleted;

        public event EventHandler BookTitleEdit;

        protected virtual void OnBookDeleted()
        {
            // Перевірка чи є підписники на подію
            if (BookDeleted != null)
            {
                // Виклик події
                BookDeleted(this, EventArgs.Empty);
            }
        }

        protected virtual void OnBookTitleEdit()
        {
            // Перевірка чи є підписники на подію
            if (BookTitleEdit != null)
            {
                // Виклик події
                BookTitleEdit(this, EventArgs.Empty);
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
                if (book.isFree)
                    radioButton1.Checked = true;
                else
                {
                    radioButton2.Checked = true;
                }

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

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            Book book = library.FindBookByID(Book_ID);
            if (!book.isFree && radioButton1.Checked)
            {
                book.isFree = true;
            }

            // Якщо були якість зміни значень полів книги
            if (textBox1.Text != book.Title || textBox2.Text != book.Author || textBox3.Text != book.Genre || textBox4.Text != book.Year.ToString())
            {
                string infoToDisplay = "Зберегти зміни?";
                YesNoForm choice = new YesNoForm(infoToDisplay);
                DialogResult result = choice.ShowDialog();


                if (result == DialogResult.Yes)
                {
                    int mark;

                    // Перевірка зміни значення textBox1.Text - Назва книги
                    if (textBox1.Text != book.Title)
                    {
                        // Якщо вміст елемента textbox - пустий рядок або пробіл
                        if (string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            errorProvider1.SetError(textBox1, "Невірний формат");
                            return;
                        }
                        else
                        {
                            book.Title = textBox1.Text;
                            errorProvider1.SetError(textBox1, "");
                            OnBookTitleEdit();
                        }
                    }

                    // Перевірка зміни значення textBox4.Text - Рік написання книги
                    if (Convert.ToInt32(textBox4.Text) != book.Year)
                    {
                        // Якщо вміст елемента textbox - пустий рядок або будь який інший символ окрім цифри
                        if (!int.TryParse(textBox4.Text, out mark) || textBox4.Text == string.Empty)
                        {
                            errorProvider1.SetError(textBox4, "Невірний формат");
                            return;
                        }
                        else if (textBox4.Text != string.Empty)
                        {
                            book.Year = int.Parse(textBox4.Text);
                            errorProvider1.SetError(textBox4, "");
                        }
                    }

                    // Перевірка зміни значення textBox2.Text - Автор
                    if (textBox2.Text != book.Author)
                    {
                        // Якщо вміст елемента textbox - не пустий рядок або пробіл
                        if (!string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            book.Author = textBox2.Text;
                        }
                    }

                    // Перевірка зміни значення textBox1.Text - Назва книги
                    if (textBox3.Text != book.Genre)
                    {
                        // Якщо вміст елемента textbox - не пустий рядок або пробіл
                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                        {
                            book.Genre = textBox3.Text;
                        }
                    }

                    // Перевірка зміни значення радіокнопок
                    
                    // Редагувати книгу
                    library.EditBook_In_Catalog(book);
                }
            }
            this.Close();
        }
    }
}
