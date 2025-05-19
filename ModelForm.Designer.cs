namespace ImageDataBaseInterface
{
    partial class ModelForm
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
            CreateButton = new Button();
            CancelButton = new Button();
            ModelNameLabel = new Label();
            DescriptionLabel = new Label();
            ModelNameBox = new TextBox();
            DescriptionBox = new TextBox();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CreateButton.Location = new Point(249, 297);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(75, 23);
            CreateButton.TabIndex = 0;
            CreateButton.Text = "Создать";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelButton.Location = new Point(330, 297);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // ModelNameLabel
            // 
            ModelNameLabel.AutoSize = true;
            ModelNameLabel.Location = new Point(12, 15);
            ModelNameLabel.Name = "ModelNameLabel";
            ModelNameLabel.Size = new Size(118, 15);
            ModelNameLabel.TabIndex = 2;
            ModelNameLabel.Text = "♦Название модели :";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(12, 42);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(113, 15);
            DescriptionLabel.TabIndex = 3;
            DescriptionLabel.Text = "Описание модели :";
            // 
            // ModelNameBox
            // 
            ModelNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ModelNameBox.Location = new Point(136, 12);
            ModelNameBox.Name = "ModelNameBox";
            ModelNameBox.Size = new Size(269, 23);
            ModelNameBox.TabIndex = 4;
            ModelNameBox.Text = "Новая модель";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionBox.Location = new Point(12, 60);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(393, 231);
            DescriptionBox.TabIndex = 5;
            // 
            // ModelForm
            // 
            AcceptButton = CreateButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 332);
            Controls.Add(DescriptionBox);
            Controls.Add(ModelNameBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(ModelNameLabel);
            Controls.Add(CancelButton);
            Controls.Add(CreateButton);
            MinimumSize = new Size(280, 260);
            Name = "ModelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новая модель";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateButton;
        private Button CancelButton;
        private Label ModelNameLabel;
        private Label DescriptionLabel;
        private TextBox ModelNameBox;
        private TextBox DescriptionBox;
    }
}