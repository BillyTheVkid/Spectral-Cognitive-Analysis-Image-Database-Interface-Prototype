namespace ImageDataBaseInterface
{
    partial class ModelsExplorerForm
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
            components = new System.ComponentModel.Container();
            Models = new ListBox();
            AddButton = new Button();
            DeleteButton = new Button();
            DescriptionBox = new TextBox();
            SaveButton = new Button();
            CloseButton = new Button();
            ModelNameLabel = new Label();
            ModelNameBox = new TextBox();
            DescriptionLabel = new Label();
            ContextMenu = new ContextMenuStrip(components);
            InvalidateButton = new ToolStripMenuItem();
            SearchLabel = new Label();
            SearchBox = new TextBox();
            AddModelButton = new ToolStripMenuItem();
            ContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // Models
            // 
            Models.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Models.FormattingEnabled = true;
            Models.ItemHeight = 15;
            Models.Location = new Point(12, 42);
            Models.Name = "Models";
            Models.Size = new Size(254, 349);
            Models.TabIndex = 0;
            Models.SelectedValueChanged += Models_SelectedChanged;
            Models.Enter += Models_Enter;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddButton.Location = new Point(12, 399);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(120, 40);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteButton.Enabled = false;
            DeleteButton.Location = new Point(146, 399);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(120, 40);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionBox.Enabled = false;
            DescriptionBox.Location = new Point(281, 57);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(501, 334);
            DescriptionBox.TabIndex = 3;
            DescriptionBox.Text = "Выберите модель из списка или создайте новую";
            DescriptionBox.TextChanged += SomethingChanged;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Enabled = false;
            SaveButton.Location = new Point(536, 399);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(120, 40);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(662, 399);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(120, 40);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ModelNameLabel
            // 
            ModelNameLabel.AutoSize = true;
            ModelNameLabel.Location = new Point(281, 15);
            ModelNameLabel.Name = "ModelNameLabel";
            ModelNameLabel.Size = new Size(121, 15);
            ModelNameLabel.TabIndex = 6;
            ModelNameLabel.Text = "♦Название модели : ";
            // 
            // ModelNameBox
            // 
            ModelNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ModelNameBox.Enabled = false;
            ModelNameBox.Location = new Point(408, 12);
            ModelNameBox.Name = "ModelNameBox";
            ModelNameBox.Size = new Size(374, 23);
            ModelNameBox.TabIndex = 7;
            ModelNameBox.TextChanged += SomethingChanged;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(281, 39);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(113, 15);
            DescriptionLabel.TabIndex = 8;
            DescriptionLabel.Text = "Описание модели :";
            // 
            // ContextMenu
            // 
            ContextMenu.Items.AddRange(new ToolStripItem[] { AddModelButton, InvalidateButton });
            ContextMenu.Name = "ContextMenu";
            ContextMenu.Size = new Size(181, 70);
            // 
            // InvalidateButton
            // 
            InvalidateButton.Name = "InvalidateButton";
            InvalidateButton.Size = new Size(180, 22);
            InvalidateButton.Text = "Обновить";
            InvalidateButton.Click += InvalidateButton_Click;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new Point(12, 15);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(48, 15);
            SearchLabel.TabIndex = 9;
            SearchLabel.Text = "Поиск :";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(66, 12);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(200, 23);
            SearchBox.TabIndex = 10;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // AddModelButton
            // 
            AddModelButton.Name = "AddModelButton";
            AddModelButton.Size = new Size(180, 22);
            AddModelButton.Text = "Новая модель";
            AddModelButton.Click += AddButton_Click;
            // 
            // ModelsExplorerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 451);
            ContextMenuStrip = ContextMenu;
            Controls.Add(SearchBox);
            Controls.Add(SearchLabel);
            Controls.Add(DescriptionLabel);
            Controls.Add(ModelNameBox);
            Controls.Add(ModelNameLabel);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(Models);
            Controls.Add(DescriptionBox);
            MinimumSize = new Size(553, 235);
            Name = "ModelsExplorerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Модели";
            Load += ModelsExplorerForm_Load;
            ContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox Models;
        private Button AddButton;
        private Button DeleteButton;
        private TextBox DescriptionBox;
        private Button SaveButton;
        private Button CloseButton;
        private Label ModelNameLabel;
        private TextBox ModelNameBox;
        private Label DescriptionLabel;
        private ContextMenuStrip ContextMenu;
        private ToolStripMenuItem InvalidateButton;
        private Label SearchLabel;
        private TextBox SearchBox;
        private ToolStripMenuItem AddModelButton;
    }
}