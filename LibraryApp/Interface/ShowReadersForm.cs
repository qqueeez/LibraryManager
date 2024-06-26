﻿using ClasessForWorkWithData;
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
    public partial class ShowReadersForm : Form
    {
        BookLibrary library;

        private List<int> id_RemovedReaders = new List<int>();

        private void AddReaderForm_ReaderAdded(object sender, EventArgs e)
        {
            dataGridView1 = Functions.DisplayInfoAboutReadersInDataGrid(library.reader_list, library, dataGridView1);
        }

        public ShowReadersForm(BookLibrary library)
        {
            this.library = library;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ShowReadersForm_Load(object sender, EventArgs e)
        {
            // Заборонити зміну розміру вікна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // Заборонити розгортання на весь екран
            this.MaximizeBox = false; 

            if (library.reader_list.Count > 0)
                dataGridView1 = Functions.DisplayInfoAboutReadersInDataGrid(library.reader_list, library, dataGridView1);
        }

        private void buttonAddReader_Click(object sender, EventArgs e)
        {
            AddReaderForm form = new AddReaderForm(library, id_RemovedReaders);
            form.ReaderAdded += AddReaderForm_ReaderAdded;
            form.ShowDialog();
        }

    }
}
