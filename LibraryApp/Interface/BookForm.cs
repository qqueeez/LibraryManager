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
    public partial class BookForm : Form
    {

        BookLibrary library;

        private List<int> RemovedSections = new List<int>();
        private List<int> RemovedBooks = new List<int>();

        public BookForm(BookLibrary library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            CatalogSection newSection = new CatalogSection("Невизначені");
            library.AddCatalogSection_In_Library(newSection, ref RemovedSections);
            Functions.UpdateTreeView(library, ref treeView1);
        }
    }
}
