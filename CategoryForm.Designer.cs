namespace ImageDataBaseInterface
{
    partial class CategoryForm
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
            OkButton = new Button();
            CancelButton = new Button();
            NameLabel = new Label();
            NameBox = new TextBox();
            TypeLabel = new Label();
            TypeBox = new ComboBox();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.Location = new Point(266, 126);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 0;
            OkButton.Text = "ОК";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(347, 126);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(4, 36);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(73, 15);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "♦Название :";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(83, 33);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(339, 23);
            NameBox.TabIndex = 3;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(36, 67);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(41, 15);
            TypeLabel.TabIndex = 4;
            TypeLabel.Text = "♦Тип :";
            // 
            // TypeBox
            // 
            TypeBox.FormattingEnabled = true;
            TypeBox.Location = new Point(83, 64);
            TypeBox.Name = "TypeBox";
            TypeBox.Size = new Size(339, 23);
            TypeBox.TabIndex = 5;
            TypeBox.DropDown += Type_DropDown;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 161);
            Controls.Add(TypeBox);
            Controls.Add(TypeLabel);
            Controls.Add(NameBox);
            Controls.Add(NameLabel);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            Name = "CategoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkButton;
        private Button CancelButton;
        private Label NameLabel;
        private TextBox NameBox;
        private Label TypeLabel;
        private ComboBox TypeBox;
    }
}