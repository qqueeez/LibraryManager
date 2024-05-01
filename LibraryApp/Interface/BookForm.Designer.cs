namespace Interface
{
    partial class BookForm
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.ButtonAddCatalog = new System.Windows.Forms.Button();
            this.ButtonSearchBook = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 99);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(305, 382);
            this.treeView1.TabIndex = 0;
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(13, 12);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(305, 23);
            this.buttonAddBook.TabIndex = 1;
            this.buttonAddBook.Text = "Додати книгу";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            // 
            // ButtonAddCatalog
            // 
            this.ButtonAddCatalog.Location = new System.Drawing.Point(13, 41);
            this.ButtonAddCatalog.Name = "ButtonAddCatalog";
            this.ButtonAddCatalog.Size = new System.Drawing.Size(305, 23);
            this.ButtonAddCatalog.TabIndex = 2;
            this.ButtonAddCatalog.Text = "Додати секцію каталогу";
            this.ButtonAddCatalog.UseVisualStyleBackColor = true;
            // 
            // ButtonSearchBook
            // 
            this.ButtonSearchBook.Location = new System.Drawing.Point(214, 70);
            this.ButtonSearchBook.Name = "ButtonSearchBook";
            this.ButtonSearchBook.Size = new System.Drawing.Size(104, 23);
            this.ButtonSearchBook.TabIndex = 3;
            this.ButtonSearchBook.Text = "Пошук книги";
            this.ButtonSearchBook.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(13, 72);
            this.SearchTextBox.Multiline = true;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(195, 20);
            this.SearchTextBox.TabIndex = 4;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 493);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ButtonSearchBook);
            this.Controls.Add(this.ButtonAddCatalog);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.treeView1);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Button ButtonAddCatalog;
        private System.Windows.Forms.Button ButtonSearchBook;
        private System.Windows.Forms.TextBox SearchTextBox;
    }
}