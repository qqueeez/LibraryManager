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
    public partial class GiveBookForm : Form
    {
        List<RentHistory> operation_list = new List<RentHistory>();
        RentHistory operation = new RentHistory();

        BookLibrary library;
        int user_id;
        int operation_number;

        public GiveBookForm(BookLibrary library, int user_id)
        {
            this.library = library;
            this.user_id = user_id;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void GiveBookForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заховати панель з кнопками керування
            this.ControlBox = false;

            foreach (var book in library.book_list)
            {
                // Додати секції у список
                listBox1.Items.Add(book.Title);
            }

            this.operation_number = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            // Отримання початкової та кінцевої дат оренди
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            // Перевірка, чи обраний хоча б один елемент у checkedListBox1
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть книгу");
                return;
            }

            if (endDate < startDate)
            {
                MessageBox.Show("Будь ласка, виберіть коректний період оренди");
                return;
            }

            // Отримання першого вибраного елемента зі списку
            string nameBook = listBox1.SelectedItem.ToString();

            Book book = library.FindBookByTitle(nameBook);
            Reader reader = library.FindReader(user_id);

            // Формування рядка з інформацією для відображення
            string infoToDisplay = $"Видати книгу {nameBook} читачу {reader.Full_name}?\n На строк від {startDate.ToString("dd/MM/yyyy")} до {endDate.ToString("dd/MM/yyyy")}.\n Що становить {endDate.Subtract(startDate).Days} днів.";

            // Відображення форми з питанням
            YesNoForm choice = new YesNoForm(infoToDisplay);
            DialogResult result = choice.ShowDialog();

            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                operation.Record_id = operation_number;
                operation.User_id = reader.Reader_ID;
                operation.Book_id = book.Book_ID;
                operation.startDate = startDate;
                operation.endDate = endDate;

                operation_list.Add(operation);

                textBox1.Text += $"{nameBook} від {startDate.ToString("dd/MM/yyyy")} до {endDate.ToString("dd/MM/yyyy")}" + Environment.NewLine;

                operation_number++;
                operation = new RentHistory();
            }

        }

        private void buttonSaveAndExit_Click(object sender, EventArgs e)
        {
            library.Give_Book(operation_list);
            this.Close();
        }
    }
}
