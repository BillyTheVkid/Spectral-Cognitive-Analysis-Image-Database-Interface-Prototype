namespace ImageDataBaseInterface
{
    partial class DataBaseForm
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
            NameBox = new TextBox();
            CreateButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 70);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(65, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Название :";
            // 
            // NameBox
            // 
            NameBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            NameBox.Location = new Point(83, 67);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(339, 23);
            NameBox.TabIndex = 1;
            // 
            // CreateButton
            // 
            CreateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CreateButton.Location = new Point(266, 126);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 2;
            CreateButton.Text = "Создать";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.Location = new Point(347, 126);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 3;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DataBaseForm
            // 
            AcceptButton = CreateButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 161);
            Controls.Add(CancelButton);
            Controls.Add(CreateButton);
            Controls.Add(NameBox);
            Controls.Add(NameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DataBaseForm";
            Text = "Создание новой базы данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private TextBox NameBox;
        private Button CreateButton;
        private Button CancelButton;
    }
}