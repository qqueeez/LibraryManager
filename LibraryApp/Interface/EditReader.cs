using ClasessForWorkWithData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Interface
{
    public partial class EditReader : Form
    {
        BookLibrary library;
        private int readerID { get; set; }


        // Конструктор класу EditReader
        public EditReader(BookLibrary library, int readerID)
        {
            this.library = library;
            this.readerID = readerID;
            InitializeComponent();
            FillReaderInfo(readerID);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FillReaderInfo(int readerID)
        {
            // Знайти книгу по id
            Reader reader = library.FindReader(readerID);

            // Якщо книгу знайдено вивести інформацію
            if (reader != null)
            {
                textBox1.Text = reader.Full_name;
                textBox2.Text = reader.Address;
                textBox3.Text = reader.Email;
                textBox4.Text = reader.PhoneNumber;
            }

        }


        private void saveReader_Click_Click(object sender, EventArgs e)
        {
            Reader reader = library.FindReader(readerID);

            // Якщо були якість зміни значень полів читача
            if (textBox1.Text != reader.Full_name || textBox2.Text != reader.Address  || textBox3.Text != reader.Email || textBox4.Text != reader.PhoneNumber)
            {
                string infoToDisplay = "Зберегти зміни?";
                YesNoForm choice = new YesNoForm(infoToDisplay);
                DialogResult result = choice.ShowDialog();


                if (result == DialogResult.Yes)
                {

                    // Перевірка зміни значення textBox1.Text - Ім'я
                    if (textBox1.Text != reader.Full_name)
                    {
                        // Якщо вміст елемента textbox - пустий рядок або пробіл
                        if (string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            errorProvider1.SetError(textBox1, "Невірний формат");
                            return;
                        }
                        else
                        {
                            reader.Full_name = textBox1.Text;
                            errorProvider1.SetError(textBox1, "");
                        }
                    }

                    // Перевірка зміни значення textBox4.Text - Рік написання книги

                    if (textBox4.Text != reader.PhoneNumber)
                    {
                        // Проверяем, соответствует ли введенный текст формату украинского номера телефона
                        if (!Regex.IsMatch(textBox4.Text, @"^(\+380)?\d{9}$"))
                        {
                            errorProvider1.SetError(textBox4, "Невірний формат");
                            return;
                        }
                        else if (textBox4.Text != string.Empty)
                        {
                            // Удаляем пробелы и знак "+" из введенного номера
                            string cleanedNumber = textBox4.Text.Replace(" ", "").Replace("+", "");
                            reader.PhoneNumber = cleanedNumber;
                            errorProvider1.SetError(textBox4, "");
                        }
                    }


                    // Перевірка зміни значення textBox2.Text - адреса
                    if (textBox2.Text != reader.Address)
                    {
                        // Якщо вміст елемента textbox - не пустий рядок або пробіл
                        if (!string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            reader.Address = textBox2.Text;
                        }
                    }

                    // Перевірка зміни значення textBox3.Text - поштова скринька
                    if (textBox3.Text != reader.Email)
                    {
                     
                        // Якщо вміст елемента textbox - не пустий рядок або пробіл
                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                        {
                            reader.Email = textBox3.Text;
                            try
                            {
                                var emailAddress = new System.Net.Mail.MailAddress(textBox4.Text);
                                reader.Email = textBox3.Text;
                                errorProvider1.SetError(textBox4, "Невірний формат");
                            }
                            catch (FormatException)
                            {
                                errorProvider1.SetError(textBox4, "Невірний формат");
                                return;
                            }
                        }
                    }

                    // Редагувати книгу
                    library.Edit_Reader(reader);
                }
            }
            this.Close();
        }

        private void EditReader_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;

        }
    }
}
