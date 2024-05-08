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
    public partial class AddCatalogForm : Form
    {
        BookLibrary library;

        private List<int> id_RemovedSections;

        public event EventHandler CatalogAdded;

        protected virtual void OnCatalogAdded()
        {
            // Перевірка чи є підписники на подію
            if (CatalogAdded != null)
            {
                // Виклик події
                CatalogAdded(this, EventArgs.Empty);
            }
        }


        public AddCatalogForm(BookLibrary library, List<int> id_RemovedSections)
        {
            this.library = library;
            InitializeComponent();
            this.id_RemovedSections = id_RemovedSections;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ButtonSaveCatalog_Click(object sender, EventArgs e)
        {
            string infoToDisplay = "Додати секцію до бібліотеки?";
            YesNoForm choice = new YesNoForm(infoToDisplay);
            DialogResult result = choice.ShowDialog();

            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                string cat_name = "";

                // Якщо вміст елемента textbox - пустий рядок або пробіл
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Це поле обов'язкове для заповнення");
                    return;
                }
                else
                {
                    cat_name = textBox1.Text;
                    errorProvider1.SetError(textBox1, "");
                }


                // Перевірка чи існує у бібліотеці секція з введеною назвою 
                if (library.catalog_section_list.Any(section => string.Equals(section.CatalogTitle, cat_name, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("У бібліотеці вже існує секція з такою назвою каталогу");
                    return;
                }

                // Якщо не існує, додати її до бібліотеки
                CatalogSection newSection = new CatalogSection(cat_name);
                library.AddCatalogSection_In_Library(newSection, ref id_RemovedSections);

                OnCatalogAdded();
                // Закрити форму
                this.Close();
            }
        }

        private void AddCatalogForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;
        }
    }
}
