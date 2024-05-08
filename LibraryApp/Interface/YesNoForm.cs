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
    public partial class YesNoForm : Form
    {
        string value;

        public YesNoForm(string infoToDisplay)
        {
            this.value = infoToDisplay;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void YesNoForm_Load(object sender, EventArgs e)
        {
            label1.Text = value;
            // відобразити label по центру форми
            int formWidth = this.ClientSize.Width;
            label1.Left = (formWidth - label1.Width) / 2;
            // заборонити зміну масштабу вікна
            this.ControlBox = false;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
