namespace HRApp
{
    partial class CreateNewPostForm
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
            this.AgreeButton = new System.Windows.Forms.Button();
            this.DisagreeButton = new System.Windows.Forms.Button();
            this.PostNameLable = new System.Windows.Forms.Label();
            this.PostNameInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AgreeButton
            // 
            this.AgreeButton.Location = new System.Drawing.Point(250, 326);
            this.AgreeButton.Name = "AgreeButton";
            this.AgreeButton.Size = new System.Drawing.Size(75, 23);
            this.AgreeButton.TabIndex = 0;
            this.AgreeButton.Text = "Сохранить";
            this.AgreeButton.UseVisualStyleBackColor = true;
            this.AgreeButton.Click += new System.EventHandler(this.AgreeButton_Click);
            // 
            // DisagreeButton
            // 
            this.DisagreeButton.Location = new System.Drawing.Point(435, 326);
            this.DisagreeButton.Name = "DisagreeButton";
            this.DisagreeButton.Size = new System.Drawing.Size(75, 23);
            this.DisagreeButton.TabIndex = 1;
            this.DisagreeButton.Text = "Отмена";
            this.DisagreeButton.UseVisualStyleBackColor = true;
            this.DisagreeButton.Click += new System.EventHandler(this.DisagreeButton_Click);
            // 
            // PostNameLable
            // 
            this.PostNameLable.AutoSize = true;
            this.PostNameLable.Location = new System.Drawing.Point(158, 168);
            this.PostNameLable.Name = "PostNameLable";
            this.PostNameLable.Size = new System.Drawing.Size(167, 15);
            this.PostNameLable.TabIndex = 2;
            this.PostNameLable.Text = "Введите название должности";
            this.PostNameLable.Click += new System.EventHandler(this.PostNameLable_Click);
            // 
            // PostNameInput
            // 
            this.PostNameInput.Location = new System.Drawing.Point(391, 165);
            this.PostNameInput.Name = "PostNameInput";
            this.PostNameInput.Size = new System.Drawing.Size(242, 23);
            this.PostNameInput.TabIndex = 3;
            this.PostNameInput.TextChanged += new System.EventHandler(this.PostNameInput_TextChanged);
            // 
            // CreateNewPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PostNameInput);
            this.Controls.Add(this.PostNameLable);
            this.Controls.Add(this.DisagreeButton);
            this.Controls.Add(this.AgreeButton);
            this.Name = "CreateNewPostForm";
            this.Text = "CreateNewPostForm";
            this.Load += new System.EventHandler(this.CreateNewPostForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button AgreeButton;
        private Button DisagreeButton;
        private Label PostNameLable;
        private TextBox PostNameInput;
    }
}