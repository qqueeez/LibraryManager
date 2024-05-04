namespace Interface
{
    partial class YesNoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.ButtonNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Зберегти зміни?";
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(12, 59);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 23);
            this.buttonYes.TabIndex = 1;
            this.buttonYes.Text = "Так";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // ButtonNo
            // 
            this.ButtonNo.Location = new System.Drawing.Point(141, 59);
            this.ButtonNo.Name = "ButtonNo";
            this.ButtonNo.Size = new System.Drawing.Size(75, 23);
            this.ButtonNo.TabIndex = 2;
            this.ButtonNo.Text = "Ні";
            this.ButtonNo.UseVisualStyleBackColor = true;
            this.ButtonNo.Click += new System.EventHandler(this.ButtonNo_Click);
            // 
            // YesNoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 96);
            this.Controls.Add(this.ButtonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.label1);
            this.Name = "YesNoForm";
            this.Text = "YesNoForm";
            this.Load += new System.EventHandler(this.YesNoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button ButtonNo;
    }
}