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

        private List<int> id_RemovedSections = new List<int>();
        private List<int> id_RemovedBooks = new List<int>();

        // Подія для того щоб оновлювати дерево коли користувач додасть книгу у формі AddBookForm
        private void AddBookForm_BookAdded(object sender, EventArgs e)
        {
            Functions.UpdateTreeView(library, ref treeView1);
        }

        // Подія для того щоб оновлювати дерево коли користувач додасть каталог у формі AddCatalogForm
        private void AddCatalogForm_BookAdded(object sender, EventArgs e)
        {
            Functions.UpdateTreeView(library, ref treeView1);
        }

        public BookForm(BookLibrary library)
        {
            this.library = library;
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            CatalogSection newSection = new CatalogSection("Невизначені");
            library.AddCatalogSection_In_Library(newSection, ref id_RemovedSections);
            Functions.UpdateTreeView(library, ref treeView1);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm form = new AddBookForm(library, id_RemovedBooks);
            form.BookAdded += AddBookForm_BookAdded;
            form.ShowDialog();
        }

        private void buttonAddCatalog_Click(object sender, EventArgs e)
        {
            AddCatalogForm form = new AddCatalogForm(library, id_RemovedSections);
            form.CatalogAdded += AddCatalogForm_BookAdded;
            form.ShowDialog();
        }
    }
}
