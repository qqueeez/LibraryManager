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
    public partial class EditCatalogForm : Form
    {
        public event EventHandler CatalogDeleted;

        public event EventHandler CatalogEdit;
        private int Catalog_ID { get; set; }

        BookLibrary library;

        private List<int> RemovedSections;

        protected virtual void OnCatalogDeleted()
        {
            // Перевірка чи є підписники на подію
            if (CatalogDeleted != null)
            {
                // Виклик події
                CatalogDeleted(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCatalogEdit()
        {
            // Перевірка чи є підписники на подію
            if (CatalogEdit != null)
            {
                // Виклик події
                CatalogEdit(this, EventArgs.Empty);
            }
        }

        public EditCatalogForm(BookLibrary library, int ID, ref List<int> RemovedSections)
        {
            this.RemovedSections = RemovedSections;
            this.library = library;
            this.Catalog_ID = ID;
            InitializeComponent();

            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonDeleteCatalog_Click(object sender, EventArgs e)
        {
            library.DeleteCatalog_In_Library(Catalog_ID, ref RemovedSections);
            OnCatalogDeleted();
            this.Close();
        }

        private void EditCatalogForm_Load(object sender, EventArgs e)
        {
            FillBookInfo(Catalog_ID);
        }

        private void FillBookInfo(int catalog_ID)
        {
            // Знайти каталог по id
            CatalogSection cat = library.FindCatalogSection(catalog_ID);

            // Якщо каталог знайдено вивести інформацію
            if (cat != null)
            {
                textBox1.Text = cat.CatalogTitle;
            }
            else
            {
                // Якщо каталог не знайдено
                MessageBox.Show("Каталог не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Закрити форму
                this.Close();
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            CatalogSection catalog = library.FindCatalogSection(Catalog_ID);

            // Якщо були якість зміни значень полів книги
            if (textBox1.Text != catalog.CatalogTitle)
            {
                string infoToDisplay = "Зберегти зміни?";
                YesNoForm choice = new YesNoForm(infoToDisplay);
                DialogResult result = choice.ShowDialog();


                if (result == DialogResult.Yes)
                {

                    // Перевірка зміни значення textBox1.Text - Назва каталогу
                    if (textBox1.Text != catalog.CatalogTitle)
                    {
                        // Якщо вміст елемента textbox - пустий рядок або пробіл
                        if (string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            errorProvider1.SetError(textBox1, "Невірний формат");
                            return;
                        }
                        else
                        {
                            catalog.CatalogTitle = textBox1.Text;
                            errorProvider1.SetError(textBox1, "");
                            OnCatalogEdit();
                        }
                    }

                    // Редагувати каталог
                    library.EditNameCatalog_In_Library(Catalog_ID, catalog.CatalogTitle);
                }
            }
            this.Close();
        }
    }
}
