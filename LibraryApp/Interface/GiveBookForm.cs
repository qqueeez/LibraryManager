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
        BookLibrary library;

        public GiveBookForm(BookLibrary library)
        {
            this.library = library;
            InitializeComponent();
        }

    }
}
