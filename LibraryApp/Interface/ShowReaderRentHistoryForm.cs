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
    public partial class ShowReaderRentHistoryForm : Form
    {
        BookLibrary library;

        private int Reader_ID { get; set; }

        public ShowReaderRentHistoryForm(BookLibrary library, int reader_ID)
        {
            InitializeComponent();
            Reader_ID = reader_ID;
            this.library = library;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ShowReaderRentHistoryForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false;
            Functions.AddRentHistoryForUserInDataGridView(library, ref dataGridView1, Reader_ID);
        }
    }
}
