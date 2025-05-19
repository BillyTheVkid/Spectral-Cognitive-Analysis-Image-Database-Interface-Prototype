namespace ImageDataBaseInterface
{
    partial class MarkersExplorerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkersExplorerForm));
            MarkersTreeView = new TreeView();
            MarkersImageList = new ImageList(components);
            SearchLabel = new Label();
            SearchBox = new TextBox();
            AddCategoryButton = new Button();
            AddMarkerButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            CloseButton = new Button();
            ChoseButton = new Button();
            EmptySpaceContextMenu = new ContextMenuStrip(components);
            NewCategoryButton = new ToolStripMenuItem();
            NewMarkerButton = new ToolStripMenuItem();
            InvalidateButton = new ToolStripMenuItem();
            CategoryContextMenu = new ContextMenuStrip(components);
            новыйМаркерToolStripMenuItem = new ToolStripMenuItem();
            изменитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            MarkerContextMenu = new ContextMenuStrip(components);
            изменитьToolStripMenuItem1 = new ToolStripMenuItem();
            удалитьToolStripMenuItem1 = new ToolStripMenuItem();
            EmptySpaceContextMenu.SuspendLayout();
            CategoryContextMenu.SuspendLayout();
            MarkerContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MarkersTreeView
            // 
            MarkersTreeView.ImageIndex = 0;
            MarkersTreeView.ImageList = MarkersImageList;
            MarkersTreeView.Location = new Point(12, 41);
            MarkersTreeView.Name = "MarkersTreeView";
            MarkersTreeView.SelectedImageIndex = 0;
            MarkersTreeView.Size = new Size(380, 346);
            MarkersTreeView.TabIndex = 0;
            MarkersTreeView.Click += SelectedNode_Changed;
            // 
            // MarkersImageList
            // 
            MarkersImageList.ColorDepth = ColorDepth.Depth32Bit;
            MarkersImageList.ImageStream = (ImageListStreamer)resources.GetObject("MarkersImageList.ImageStream");
            MarkersImageList.TransparentColor = Color.Transparent;
            MarkersImageList.Images.SetKeyName(0, "Folder.png");
            MarkersImageList.Images.SetKeyName(1, "Marker.png");
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new Point(12, 15);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(48, 15);
            SearchLabel.TabIndex = 3;
            SearchLabel.Text = "Поиск :";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(66, 12);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(326, 23);
            SearchBox.TabIndex = 4;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // AddCategoryButton
            // 
            AddCategoryButton.Location = new Point(398, 41);
            AddCategoryButton.Name = "AddCategoryButton";
            AddCategoryButton.Size = new Size(87, 40);
            AddCategoryButton.TabIndex = 5;
            AddCategoryButton.Text = "Добавить категорию";
            AddCategoryButton.UseVisualStyleBackColor = true;
            AddCategoryButton.Click += AddCategoryButton_Click;
            // 
            // AddMarkerButton
            // 
            AddMarkerButton.Location = new Point(398, 87);
            AddMarkerButton.Name = "AddMarkerButton";
            AddMarkerButton.Size = new Size(87, 40);
            AddMarkerButton.TabIndex = 6;
            AddMarkerButton.Text = "Добавить маркер";
            AddMarkerButton.UseVisualStyleBackColor = true;
            AddMarkerButton.Click += AddMarkerButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(398, 133);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(87, 40);
            EditButton.TabIndex = 7;
            EditButton.Text = "Изменить";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(398, 179);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(87, 40);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(398, 357);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(87, 30);
            CloseButton.TabIndex = 9;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // ChoseButton
            // 
            ChoseButton.Location = new Point(398, 321);
            ChoseButton.Name = "ChoseButton";
            ChoseButton.Size = new Size(87, 30);
            ChoseButton.TabIndex = 10;
            ChoseButton.Text = "Выбрать";
            ChoseButton.UseVisualStyleBackColor = true;
            ChoseButton.Visible = false;
            // 
            // EmptySpaceContextMenu
            // 
            EmptySpaceContextMenu.Items.AddRange(new ToolStripItem[] { NewCategoryButton, NewMarkerButton, InvalidateButton });
            EmptySpaceContextMenu.Name = "EmptySpaceContextMenu";
            EmptySpaceContextMenu.Size = new Size(167, 70);
            // 
            // NewCategoryButton
            // 
            NewCategoryButton.Name = "NewCategoryButton";
            NewCategoryButton.Size = new Size(166, 22);
            NewCategoryButton.Text = "Новая категория";
            NewCategoryButton.Click += AddCategoryButton_Click;
            // 
            // NewMarkerButton
            // 
            NewMarkerButton.Name = "NewMarkerButton";
            NewMarkerButton.Size = new Size(166, 22);
            NewMarkerButton.Text = "Новый маркер";
            NewMarkerButton.Click += AddMarkerButton_Click;
            // 
            // InvalidateButton
            // 
            InvalidateButton.Name = "InvalidateButton";
            InvalidateButton.Size = new Size(166, 22);
            InvalidateButton.Text = "Обновить";
            InvalidateButton.Click += InvalidateButton_Click;
            // 
            // CategoryContextMenu
            // 
            CategoryContextMenu.Items.AddRange(new ToolStripItem[] { новыйМаркерToolStripMenuItem, изменитьToolStripMenuItem, удалитьToolStripMenuItem });
            CategoryContextMenu.Name = "CategoryContextMenu";
            CategoryContextMenu.Size = new Size(157, 70);
            // 
            // новыйМаркерToolStripMenuItem
            // 
            новыйМаркерToolStripMenuItem.Name = "новыйМаркерToolStripMenuItem";
            новыйМаркерToolStripMenuItem.Size = new Size(156, 22);
            новыйМаркерToolStripMenuItem.Text = "Новый маркер";
            // 
            // изменитьToolStripMenuItem
            // 
            изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            изменитьToolStripMenuItem.Size = new Size(156, 22);
            изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(156, 22);
            удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // MarkerContextMenu
            // 
            MarkerContextMenu.Items.AddRange(new ToolStripItem[] { изменитьToolStripMenuItem1, удалитьToolStripMenuItem1 });
            MarkerContextMenu.Name = "MarkerContextMenu";
            MarkerContextMenu.Size = new Size(129, 48);
            // 
            // изменитьToolStripMenuItem1
            // 
            изменитьToolStripMenuItem1.Name = "изменитьToolStripMenuItem1";
            изменитьToolStripMenuItem1.Size = new Size(128, 22);
            изменитьToolStripMenuItem1.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem1
            // 
            удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            удалитьToolStripMenuItem1.Size = new Size(128, 22);
            удалитьToolStripMenuItem1.Text = "Удалить";
            // 
            // MarkersExplorerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CloseButton;
            ClientSize = new Size(497, 399);
            ContextMenuStrip = EmptySpaceContextMenu;
            Controls.Add(ChoseButton);
            Controls.Add(CloseButton);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddMarkerButton);
            Controls.Add(AddCategoryButton);
            Controls.Add(SearchBox);
            Controls.Add(SearchLabel);
            Controls.Add(MarkersTreeView);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "MarkersExplorerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MarkersExplorerForm";
            Load += MarkersExplorerForm_Load;
            EmptySpaceContextMenu.ResumeLayout(false);
            CategoryContextMenu.ResumeLayout(false);
            MarkerContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView MarkersTreeView;
        private Label SearchLabel;
        private TextBox SearchBox;
        private ImageList MarkersImageList;
        private Button AddCategoryButton;
        private Button AddMarkerButton;
        private Button EditButton;
        private Button DeleteButton;
        private Button CloseButton;
        private Button ChoseButton;
        private ContextMenuStrip EmptySpaceContextMenu;
        private ToolStripMenuItem NewCategoryButton;
        private ToolStripMenuItem NewMarkerButton;
        private ToolStripMenuItem InvalidateButton;
        private ContextMenuStrip CategoryContextMenu;
        private ToolStripMenuItem новыйМаркерToolStripMenuItem;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ContextMenuStrip MarkerContextMenu;
        private ToolStripMenuItem изменитьToolStripMenuItem1;
        private ToolStripMenuItem удалитьToolStripMenuItem1;
    }
}