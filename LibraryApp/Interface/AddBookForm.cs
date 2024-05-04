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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class AddBookForm : Form
    {
        BookLibrary library;

        private List<int> id_SelectedSections { get; set; } = new List<int>();

        private List<int> id_RemovedBooks;

        public event EventHandler BookAdded;


        protected virtual void OnBookAdded()
        {
            // Перевірка чи є підписники на подію
            if (BookAdded != null)
            {
                // Виклик події
                BookAdded(this, EventArgs.Empty);
            }
        }

        public AddBookForm(BookLibrary library, List<int> id_RemovedBooks)
        {
            this.library = library;
            this.id_RemovedBooks = id_RemovedBooks;
            InitializeComponent();
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            // Очистити елемент 
            checkedListBox1.Items.Clear();

            foreach (var section in library.catalog_section_list)
            {
                // Додати секції у список
                checkedListBox1.Items.Add(section.CatalogTitle);
            }
        }

        private void ButtonSaveBook_Click(object sender, EventArgs e)
        {
            string infoToDisplay = "Додати книгу до бібліотеки?";
            YesNoForm choice = new YesNoForm(infoToDisplay);
            DialogResult result = choice.ShowDialog();

            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                string BookTitle = "Невизначена";
                string BookAuthor = "Невизначений";
                string BookGenre = "Невизначений";
                int BookYear = 0;


                // Якщо вміст елемента textbox - пустий рядок або пробіл
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Це поле обов'язкове для заповнення");
                    return;
                }
                else
                {
                    BookTitle = textBox1.Text;
                    errorProvider1.SetError(textBox1, "");
                }

                // Якщо вміст елемента textbox - пустий рядок або будь який інший символ окрім цифри
                if (textBox4.Text == string.Empty)
                {
                    BookYear = 0;
                }
                else if (!int.TryParse(textBox4.Text, out BookYear))
                {
                    errorProvider1.SetError(textBox4, "Невірний формат");
                    return;
                }
                else
                {
                    BookYear = int.Parse(textBox4.Text);
                    errorProvider1.SetError(textBox4, "");
                }

                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    BookAuthor = textBox2.Text;
                }

                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    BookGenre = textBox3.Text;
                }

                // Якщо у бібліотеці вже існує книга з таким ім'ям
                if (library.book_list.Any(book => string.Equals(book.Title, BookTitle, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("У бібліотеці вже існує книга з таким ім'ям");
                    return;
                }

                // Отримати з елемента checkedListBox список обраних секцій
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    // Пошук секції каталогу за назвою
                    CatalogSection section = library.FindCatalogSection(item.ToString());

                    // Помістити id обраної секції до відповідного списку id_SelectedSections
                    id_SelectedSections.Add(section.Catalog_ID);
                }

                // Якщо користувач не обрав жодної секції помістити книгу у секцію невизначені
                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    id_SelectedSections.Add(0);
                }


                Book newBook = new Book(BookTitle, BookAuthor, BookGenre, BookYear, id_SelectedSections);


                // Додати книгу до бібліотеки
                library.AddBook_In_Library(newBook, ref id_RemovedBooks);

                OnBookAdded();
                // Закрити форму
                this.Close();
            }
        }


    }
}
