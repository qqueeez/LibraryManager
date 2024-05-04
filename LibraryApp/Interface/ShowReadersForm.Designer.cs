namespace Interface
{
    partial class ShowReadersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAddReader = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1148, 171);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonAddReader
            // 
            this.buttonAddReader.Location = new System.Drawing.Point(926, 200);
            this.buttonAddReader.Name = "buttonAddReader";
            this.buttonAddReader.Size = new System.Drawing.Size(122, 23);
            this.buttonAddReader.TabIndex = 1;
            this.buttonAddReader.Text = "Додати читача";
            this.buttonAddReader.UseVisualStyleBackColor = true;
            this.buttonAddReader.Click += new System.EventHandler(this.buttonAddReader_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(1054, 200);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(107, 23);
            this.buttonSaveChanges.TabIndex = 2;
            this.buttonSaveChanges.Text = "Зберегти зміни";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // ShowReadersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 236);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.buttonAddReader);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowReadersForm";
            this.Text = "ShowReadersForm";
            this.Load += new System.EventHandler(this.ShowReadersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAddReader;
        private System.Windows.Forms.Button buttonSaveChanges;
    }
}