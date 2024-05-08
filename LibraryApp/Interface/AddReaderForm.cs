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
    public partial class AddReaderForm : Form
    {
        BookLibrary library;

        private List<int> id_RemovedReaders;

        public event EventHandler ReaderAdded;

        protected virtual void OnReaderAdded()
        {
            // Перевірка чи є підписники на подію
            if (ReaderAdded != null)
            {
                // Виклик події
                ReaderAdded(this, EventArgs.Empty);
            }
        }

        public AddReaderForm(BookLibrary library, List<int> id_RemovedReaders)
        {
            this.library = library;
            this.id_RemovedReaders = id_RemovedReaders;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSaveReader_Click(object sender, EventArgs e)
        {
            // Перевірка чи бажає користувач додати читача
            string infoToDisplay = "Додати читача у базу бібліотеки?";
            YesNoForm choice = new YesNoForm(infoToDisplay);
            DialogResult result = choice.ShowDialog();

            if (result == DialogResult.No)
            {
                return;
            }

            // Введені дані коректні - продовжуємо операцію
            string readerFullName = "Невизначене";
            string readerAddress = "Невизначений";
            string readerEmail = "Невизначений";
            string readerPhoneNumber = "Невизначений";

            // Перевірка чи заповнене поле імені
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Це поле обов'язкове для заповнення");
                return;
            }
            else
            {
                readerFullName = textBox1.Text;
                errorProvider1.SetError(textBox1, "");
            }

            // Перевірка наявності адреси
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                readerAddress = textBox2.Text;
            }

            // Перевірка коректності введеного Email
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                if (!IsValidEmail(textBox3.Text))
                {
                    errorProvider1.SetError(textBox3, "Введіть коректний Email");
                    return;
                }
                readerEmail = textBox3.Text;
            }

            // Перевірка коректності введеного номеру телефону 
            if (!string.IsNullOrWhiteSpace(textBox4.Text))
            {
                //if (!IsValidPhoneNumber(textBox4.Text))
                //{
                //    errorProvider1.SetError(textBox4, "Введіть коректний номер телефону");
                //    return;
                //}
                readerPhoneNumber = textBox4.Text;
            }

            // Перевірка на унікальність імені читача в бібліотеці
            if (library.reader_list.Any(reader => string.Equals(reader.Full_name, readerFullName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("У бібліотеці вже існує читач з таким ім'ям");
                return;
            }

            // Створення нового об'єкта читача та додавання його в бібліотеку
            Reader newReader = new Reader(readerFullName, readerAddress, readerEmail, readerPhoneNumber);
            library.Add_New_Reader(newReader, ref id_RemovedReaders);

            OnReaderAdded();
            // Закрити форму
            this.Close();
        }

        // Метод для перевірки коректності Email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void AddReaderForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;
        }

        // Метод для перевірки коректності номеру телефону
        //private bool IsValidPhoneNumber(string phoneNumber)
        //{
        //    
        //    
        //}
    }
}
