namespace YLADotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            lblTitle = new Label();
            lblAuthor = new Label();
            lblContent = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(211, 47, 47);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(201, 265);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 37);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(201, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(53, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Title :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(201, 112);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(76, 25);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "Author :";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(201, 187);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(84, 25);
            lblContent.TabIndex = 1;
            lblContent.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(201, 64);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(316, 31);
            txtTitle.TabIndex = 2;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(201, 140);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(316, 31);
            txtAuthor.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(201, 215);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(316, 31);
            txtContent.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(63, 81, 181);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(319, 265);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 37);
            btnSave.TabIndex = 3;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblContent);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Controls.Add(btnCancel);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblContent;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnSave;
    }
}
