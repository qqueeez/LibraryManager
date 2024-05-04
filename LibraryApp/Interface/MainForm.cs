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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        BookLibrary library = new BookLibrary();

        private void ButtonShowBook_Click(object sender, EventArgs e)
        {
            BookForm form = new BookForm(library);
            form.ShowDialog();
        }

        private void ButtonShowReaders_Click(object sender, EventArgs e)
        {
            ShowReadersForm form = new ShowReadersForm(library);
            form.ShowDialog();
        }
    }
}
