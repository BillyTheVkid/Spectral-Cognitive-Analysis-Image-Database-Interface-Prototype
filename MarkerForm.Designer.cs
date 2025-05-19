namespace ImageDataBaseInterface
{
    partial class MarkerForm
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
            NameLabel = new Label();
            CategoryLabel = new Label();
            NameBox = new TextBox();
            CategoryBox = new ComboBox();
            OkButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(4, 36);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(73, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "♦Название :";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(0, 67);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(77, 15);
            CategoryLabel.TabIndex = 1;
            CategoryLabel.Text = "♦Категория :";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(83, 33);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(339, 23);
            NameBox.TabIndex = 2;
            // 
            // CategoryBox
            // 
            CategoryBox.FormattingEnabled = true;
            CategoryBox.Location = new Point(83, 64);
            CategoryBox.Name = "CategoryBox";
            CategoryBox.Size = new Size(339, 23);
            CategoryBox.TabIndex = 3;
            CategoryBox.DropDown += CategoryBox_DropDown;
            CategoryBox.SelectedIndexChanged += CategoryBox_SelectedIndexChanged;
            CategoryBox.SelectionChangeCommitted += CategoryBox_SelectionChangeCommitted;
            // 
            // OkButton
            // 
            OkButton.Location = new Point(266, 126);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(75, 23);
            OkButton.TabIndex = 4;
            OkButton.Text = "ОК";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(347, 126);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 5;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // MarkerForm
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 161);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            Controls.Add(CategoryBox);
            Controls.Add(NameBox);
            Controls.Add(CategoryLabel);
            Controls.Add(NameLabel);
            Name = "MarkerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label CategoryLabel;
        private TextBox NameBox;
        private ComboBox CategoryBox;
        private Button OkButton;
        private Button CancelButton;
    }
}