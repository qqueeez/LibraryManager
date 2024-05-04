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

        public InfoAboutBookForm(BookLibrary library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void InfoAboutBookForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("id", "Номер запису");
            dataGridView1.Columns.Add("full_client_name", "Клієнт");
            dataGridView1.Columns.Add("client_number", "Номер телефону");
            dataGridView1.Columns.Add("rent_period", "Період оренди");
            Functions.AddInfoInDataGridView(library, ref dataGridView1);
        }
    }
}
