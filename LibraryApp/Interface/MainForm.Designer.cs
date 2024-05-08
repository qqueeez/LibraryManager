namespace Interface
{
    partial class MainForm
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
            this.ButtonShowBook = new System.Windows.Forms.Button();
            this.ButtonShowReaders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonShowBook
            // 
            this.ButtonShowBook.Location = new System.Drawing.Point(29, 77);
            this.ButtonShowBook.Name = "ButtonShowBook";
            this.ButtonShowBook.Size = new System.Drawing.Size(209, 35);
            this.ButtonShowBook.TabIndex = 2;
            this.ButtonShowBook.Text = "Книги";
            this.ButtonShowBook.UseVisualStyleBackColor = true;
            this.ButtonShowBook.Click += new System.EventHandler(this.ButtonShowBook_Click);
            // 
            // ButtonShowReaders
            // 
            this.ButtonShowReaders.Location = new System.Drawing.Point(29, 128);
            this.ButtonShowReaders.Name = "ButtonShowReaders";
            this.ButtonShowReaders.Size = new System.Drawing.Size(209, 34);
            this.ButtonShowReaders.TabIndex = 4;
            this.ButtonShowReaders.Text = "Читачі";
            this.ButtonShowReaders.UseVisualStyleBackColor = true;
            this.ButtonShowReaders.Click += new System.EventHandler(this.ButtonShowReaders_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Вітаю у менеджері бібліотеки!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Оберіть, будь ласка дію";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 183);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonShowReaders);
            this.Controls.Add(this.ButtonShowBook);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonShowBook;
        private System.Windows.Forms.Button ButtonShowReaders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

