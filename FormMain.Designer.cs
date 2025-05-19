namespace ImageDataBaseInterface
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            MainMenuStrip = new MenuStrip();
            FileButton = new ToolStripMenuItem();
            NewButton = new ToolStripMenuItem();
            базуДанныхToolStripMenuItem = new ToolStripMenuItem();
            исследованиеToolStripMenuItem = new ToolStripMenuItem();
            OpenButton = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            SaveButton = new ToolStripMenuItem();
            SaveAllButton = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            QuitButton = new ToolStripMenuItem();
            ViewButton = new ToolStripMenuItem();
            ExplorerRootButton = new ToolStripMenuItem();
            ResearcherRootButton = new ToolStripMenuItem();
            ResearchRootButton = new ToolStripMenuItem();
            WindowsButton = new ToolStripMenuItem();
            CascadeButton = new ToolStripMenuItem();
            VerticalButton = new ToolStripMenuItem();
            HorizontalButton = new ToolStripMenuItem();
            OrderSwitched = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            DataBasesButton = new ToolStripMenuItem();
            Models = new ToolStripMenuItem();
            Markers = new ToolStripMenuItem();
            DataTreeView = new TreeView();
            TreeViewImageList = new ImageList(components);
            EmptySpaceContextMenu = new ContextMenuStrip(components);
            CreateDataBaseButton = new ToolStripMenuItem();
            OpenDataBaseButton = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            AddButton = new ToolStripMenuItem();
            AddNewResearcherButton = new ToolStripMenuItem();
            AddNewResearchButton = new ToolStripMenuItem();
            InvalidateButton = new ToolStripMenuItem();
            splitter1 = new Splitter();
            Tools = new ToolStrip();
            FilterButton = new ToolStripButton();
            SortButton = new ToolStripSplitButton();
            AlphabethOrder = new ToolStripMenuItem();
            DateOrder = new ToolStripMenuItem();
            SearchLabel = new ToolStripLabel();
            SearchBox = new ToolStripTextBox();
            ResearcherContextMenu = new ContextMenuStrip(components);
            NewResearchButton = new ToolStripMenuItem();
            RenameResearcherButton = new ToolStripMenuItem();
            DeleteResearcherButton = new ToolStripMenuItem();
            ResearchContextMenu = new ContextMenuStrip(components);
            OpenResearchButton = new ToolStripMenuItem();
            DeleteResearchButton = new ToolStripMenuItem();
            MainMenuStrip.SuspendLayout();
            EmptySpaceContextMenu.SuspendLayout();
            Tools.SuspendLayout();
            ResearcherContextMenu.SuspendLayout();
            ResearchContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { FileButton, ViewButton, WindowsButton, DataBasesButton, Models, Markers });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.MdiWindowListItem = WindowsButton;
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(1134, 24);
            MainMenuStrip.TabIndex = 1;
            MainMenuStrip.Text = "MainMenu";
            // 
            // FileButton
            // 
            FileButton.DropDownItems.AddRange(new ToolStripItem[] { NewButton, OpenButton, toolStripMenuItem3, SaveButton, SaveAllButton, toolStripMenuItem1, QuitButton });
            FileButton.Name = "FileButton";
            FileButton.Size = new Size(48, 20);
            FileButton.Text = "&Файл";
            // 
            // NewButton
            // 
            NewButton.DropDownItems.AddRange(new ToolStripItem[] { базуДанныхToolStripMenuItem, исследованиеToolStripMenuItem });
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(226, 22);
            NewButton.Text = "&Создать";
            // 
            // базуДанныхToolStripMenuItem
            // 
            базуДанныхToolStripMenuItem.Name = "базуДанныхToolStripMenuItem";
            базуДанныхToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            базуДанныхToolStripMenuItem.Size = new Size(226, 22);
            базуДанныхToolStripMenuItem.Text = "&Базу данных...";
            базуДанныхToolStripMenuItem.Click += CreateNewDataBase;
            // 
            // исследованиеToolStripMenuItem
            // 
            исследованиеToolStripMenuItem.Name = "исследованиеToolStripMenuItem";
            исследованиеToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            исследованиеToolStripMenuItem.Size = new Size(226, 22);
            исследованиеToolStripMenuItem.Text = "&Исследование...";
            исследованиеToolStripMenuItem.Click += AddNewResearchButton_Click;
            // 
            // OpenButton
            // 
            OpenButton.Name = "OpenButton";
            OpenButton.ShortcutKeys = Keys.Control | Keys.O;
            OpenButton.Size = new Size(226, 22);
            OpenButton.Text = "&Открыть...";
            OpenButton.Click += OpenNewDataBase;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(223, 6);
            // 
            // SaveButton
            // 
            SaveButton.Name = "SaveButton";
            SaveButton.ShortcutKeys = Keys.Control | Keys.S;
            SaveButton.Size = new Size(226, 22);
            SaveButton.Text = "Со&хранить";
            SaveButton.Click += SaveButton_Click;
            // 
            // SaveAllButton
            // 
            SaveAllButton.Name = "SaveAllButton";
            SaveAllButton.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveAllButton.Size = new Size(226, 22);
            SaveAllButton.Text = "Сох&ранить все";
            SaveAllButton.Click += SaveAllButton_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(223, 6);
            // 
            // QuitButton
            // 
            QuitButton.Name = "QuitButton";
            QuitButton.ShortcutKeys = Keys.Alt | Keys.F4;
            QuitButton.Size = new Size(226, 22);
            QuitButton.Text = "&Выход";
            QuitButton.Click += QuitButton_Click;
            // 
            // ViewButton
            // 
            ViewButton.DropDownItems.AddRange(new ToolStripItem[] { ExplorerRootButton });
            ViewButton.Name = "ViewButton";
            ViewButton.Size = new Size(39, 20);
            ViewButton.Text = "&Вид";
            // 
            // ExplorerRootButton
            // 
            ExplorerRootButton.DropDownItems.AddRange(new ToolStripItem[] { ResearcherRootButton, ResearchRootButton });
            ExplorerRootButton.Name = "ExplorerRootButton";
            ExplorerRootButton.Size = new Size(192, 22);
            ExplorerRootButton.Text = "&Корень обозревателя";
            // 
            // ResearcherRootButton
            // 
            ResearcherRootButton.Name = "ResearcherRootButton";
            ResearcherRootButton.Size = new Size(157, 22);
            ResearcherRootButton.Text = "Исследователь";
            ResearcherRootButton.Click += ResearcherRootButton_Click;
            // 
            // ResearchRootButton
            // 
            ResearchRootButton.Name = "ResearchRootButton";
            ResearchRootButton.Size = new Size(157, 22);
            ResearchRootButton.Text = "Исследование";
            ResearchRootButton.Click += ResearchRootButton_Click;
            // 
            // WindowsButton
            // 
            WindowsButton.DropDownItems.AddRange(new ToolStripItem[] { CascadeButton, VerticalButton, HorizontalButton, OrderSwitched, toolStripMenuItem2 });
            WindowsButton.Name = "WindowsButton";
            WindowsButton.Size = new Size(47, 20);
            WindowsButton.Text = "&Окна";
            // 
            // CascadeButton
            // 
            CascadeButton.Name = "CascadeButton";
            CascadeButton.Size = new Size(234, 22);
            CascadeButton.Text = "Расположить &каскадом";
            CascadeButton.Click += CascadeButton_Click;
            // 
            // VerticalButton
            // 
            VerticalButton.Name = "VerticalButton";
            VerticalButton.Size = new Size(234, 22);
            VerticalButton.Text = "Расположить &вертикально";
            VerticalButton.Click += VerticalButton_Click;
            // 
            // HorizontalButton
            // 
            HorizontalButton.Name = "HorizontalButton";
            HorizontalButton.Size = new Size(234, 22);
            HorizontalButton.Text = "Расположить &горизонтально";
            HorizontalButton.Click += HorizontalButton_Click;
            // 
            // OrderSwitched
            // 
            OrderSwitched.Name = "OrderSwitched";
            OrderSwitched.Size = new Size(234, 22);
            OrderSwitched.Text = "&Упорядочить свернутые";
            OrderSwitched.Click += OrderSwitched_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(231, 6);
            // 
            // DataBasesButton
            // 
            DataBasesButton.Name = "DataBasesButton";
            DataBasesButton.Size = new Size(92, 20);
            DataBasesButton.Text = "&Базы Данных";
            DataBasesButton.DropDownOpening += DataBasesButton_DropDownOpening;
            // 
            // Models
            // 
            Models.Enabled = false;
            Models.Name = "Models";
            Models.Size = new Size(63, 20);
            Models.Text = "Модели";
            Models.Click += Models_Click;
            // 
            // Markers
            // 
            Markers.Enabled = false;
            Markers.Name = "Markers";
            Markers.Size = new Size(71, 20);
            Markers.Text = "Маркеры";
            Markers.Click += Markers_Click;
            // 
            // DataTreeView
            // 
            DataTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DataTreeView.ImageIndex = 0;
            DataTreeView.ImageList = TreeViewImageList;
            DataTreeView.Location = new Point(12, 61);
            DataTreeView.Name = "DataTreeView";
            DataTreeView.SelectedImageIndex = 0;
            DataTreeView.Size = new Size(276, 888);
            DataTreeView.TabIndex = 2;
            // 
            // TreeViewImageList
            // 
            TreeViewImageList.ColorDepth = ColorDepth.Depth32Bit;
            TreeViewImageList.ImageStream = (ImageListStreamer)resources.GetObject("TreeViewImageList.ImageStream");
            TreeViewImageList.TransparentColor = Color.Transparent;
            TreeViewImageList.Images.SetKeyName(0, "ResearcherIcon.png");
            TreeViewImageList.Images.SetKeyName(1, "ResearchIcon.png");
            // 
            // EmptySpaceContextMenu
            // 
            EmptySpaceContextMenu.Items.AddRange(new ToolStripItem[] { CreateDataBaseButton, OpenDataBaseButton, toolStripMenuItem4, AddButton, InvalidateButton });
            EmptySpaceContextMenu.Name = "EmptySpaceContextMenu";
            EmptySpaceContextMenu.Size = new Size(149, 98);
            EmptySpaceContextMenu.Opening += NodeContextMenu_Opening;
            // 
            // CreateDataBaseButton
            // 
            CreateDataBaseButton.Name = "CreateDataBaseButton";
            CreateDataBaseButton.Size = new Size(148, 22);
            CreateDataBaseButton.Text = "Создать БД...";
            CreateDataBaseButton.Click += CreateNewDataBase;
            // 
            // OpenDataBaseButton
            // 
            OpenDataBaseButton.Name = "OpenDataBaseButton";
            OpenDataBaseButton.Size = new Size(148, 22);
            OpenDataBaseButton.Text = "Открыть БД...";
            OpenDataBaseButton.Click += OpenNewDataBase;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(145, 6);
            // 
            // AddButton
            // 
            AddButton.DropDownItems.AddRange(new ToolStripItem[] { AddNewResearcherButton, AddNewResearchButton });
            AddButton.Enabled = false;
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(148, 22);
            AddButton.Text = "Добавить";
            // 
            // AddNewResearcherButton
            // 
            AddNewResearcherButton.Name = "AddNewResearcherButton";
            AddNewResearcherButton.Size = new Size(157, 22);
            AddNewResearcherButton.Text = "Исследователя";
            AddNewResearcherButton.Click += AddNewResearcherButton_Click;
            // 
            // AddNewResearchButton
            // 
            AddNewResearchButton.Name = "AddNewResearchButton";
            AddNewResearchButton.Size = new Size(157, 22);
            AddNewResearchButton.Text = "Исследование";
            AddNewResearchButton.Click += AddNewResearchButton_Click;
            // 
            // InvalidateButton
            // 
            InvalidateButton.Enabled = false;
            InvalidateButton.Name = "InvalidateButton";
            InvalidateButton.Size = new Size(148, 22);
            InvalidateButton.Text = "Обновить";
            InvalidateButton.Click += InvalidateButton_Click;
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ControlLight;
            splitter1.Location = new Point(0, 24);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(300, 937);
            splitter1.TabIndex = 3;
            splitter1.TabStop = false;
            // 
            // Tools
            // 
            Tools.AllowMerge = false;
            Tools.AutoSize = false;
            Tools.BackColor = SystemColors.ControlLight;
            Tools.BackgroundImageLayout = ImageLayout.None;
            Tools.Dock = DockStyle.None;
            Tools.GripMargin = new Padding(0);
            Tools.GripStyle = ToolStripGripStyle.Hidden;
            Tools.ImageScalingSize = new Size(20, 20);
            Tools.Items.AddRange(new ToolStripItem[] { FilterButton, SortButton, SearchLabel, SearchBox });
            Tools.Location = new Point(5, 31);
            Tools.Name = "Tools";
            Tools.Padding = new Padding(0);
            Tools.RenderMode = ToolStripRenderMode.System;
            Tools.Size = new Size(290, 27);
            Tools.Stretch = true;
            Tools.TabIndex = 5;
            Tools.Text = "Инструменты";
            // 
            // FilterButton
            // 
            FilterButton.Alignment = ToolStripItemAlignment.Right;
            FilterButton.BackColor = SystemColors.ControlLight;
            FilterButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            FilterButton.Image = Properties.Resources.FilterIco;
            FilterButton.ImageTransparentColor = Color.Magenta;
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(24, 24);
            FilterButton.Text = "Ф&ильтры";
            // 
            // SortButton
            // 
            SortButton.Alignment = ToolStripItemAlignment.Right;
            SortButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            SortButton.DropDownItems.AddRange(new ToolStripItem[] { AlphabethOrder, DateOrder });
            SortButton.Image = Properties.Resources.SortIco;
            SortButton.ImageTransparentColor = Color.Magenta;
            SortButton.Name = "SortButton";
            SortButton.Size = new Size(36, 24);
            SortButton.Text = "Сортировка";
            SortButton.ButtonClick += SortButton_ButtonClick;
            // 
            // AlphabethOrder
            // 
            AlphabethOrder.Checked = true;
            AlphabethOrder.CheckState = CheckState.Checked;
            AlphabethOrder.Enabled = false;
            AlphabethOrder.Name = "AlphabethOrder";
            AlphabethOrder.Size = new Size(147, 22);
            AlphabethOrder.Text = "По Алфавиту";
            AlphabethOrder.Click += AlphabethOrder_Click;
            // 
            // DateOrder
            // 
            DateOrder.Name = "DateOrder";
            DateOrder.Size = new Size(147, 22);
            DateOrder.Text = "По Дате";
            DateOrder.Click += DateOrder_Click;
            // 
            // SearchLabel
            // 
            SearchLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SearchLabel.Image = (Image)resources.GetObject("SearchLabel.Image");
            SearchLabel.ImageTransparentColor = Color.Magenta;
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(48, 24);
            SearchLabel.Text = "Поиск :";
            // 
            // SearchBox
            // 
            SearchBox.AutoSize = false;
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(165, 23);
            SearchBox.ToolTipText = "Поиск среди исследователей и исследований";
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // ResearcherContextMenu
            // 
            ResearcherContextMenu.Items.AddRange(new ToolStripItem[] { NewResearchButton, RenameResearcherButton, DeleteResearcherButton });
            ResearcherContextMenu.Name = "ResearcherContextMenu";
            ResearcherContextMenu.Size = new Size(199, 70);
            ResearcherContextMenu.Opening += NodeContextMenu_Opening;
            // 
            // NewResearchButton
            // 
            NewResearchButton.Name = "NewResearchButton";
            NewResearchButton.Size = new Size(198, 22);
            NewResearchButton.Text = "Новое исследование...";
            NewResearchButton.Click += AddNewResearchButton_Click;
            // 
            // RenameResearcherButton
            // 
            RenameResearcherButton.Name = "RenameResearcherButton";
            RenameResearcherButton.Size = new Size(198, 22);
            RenameResearcherButton.Text = "Переименовать...";
            RenameResearcherButton.Click += RenameResearcherButton_Click;
            // 
            // DeleteResearcherButton
            // 
            DeleteResearcherButton.Name = "DeleteResearcherButton";
            DeleteResearcherButton.Size = new Size(198, 22);
            DeleteResearcherButton.Text = "Удалить";
            DeleteResearcherButton.Click += DeleteResearcherButton_Click;
            // 
            // ResearchContextMenu
            // 
            ResearchContextMenu.Items.AddRange(new ToolStripItem[] { OpenResearchButton, DeleteResearchButton });
            ResearchContextMenu.Name = "ResearchContextMenu";
            ResearchContextMenu.Size = new Size(122, 48);
            ResearchContextMenu.Opening += NodeContextMenu_Opening;
            // 
            // OpenResearchButton
            // 
            OpenResearchButton.Name = "OpenResearchButton";
            OpenResearchButton.Size = new Size(121, 22);
            OpenResearchButton.Text = "Открыть";
            OpenResearchButton.Click += OpenResearchButton_Click;
            // 
            // DeleteResearchButton
            // 
            DeleteResearchButton.Name = "DeleteResearchButton";
            DeleteResearchButton.Size = new Size(121, 22);
            DeleteResearchButton.Text = "Удалить";
            DeleteResearchButton.Click += DeleteResearchButton_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 961);
            ContextMenuStrip = EmptySpaceContextMenu;
            Controls.Add(DataTreeView);
            Controls.Add(Tools);
            Controls.Add(splitter1);
            Controls.Add(MainMenuStrip);
            DoubleBuffered = true;
            IsMdiContainer = true;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "База данных изображений для спектрально когнитивного анализа";
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            EmptySpaceContextMenu.ResumeLayout(false);
            Tools.ResumeLayout(false);
            Tools.PerformLayout();
            ResearcherContextMenu.ResumeLayout(false);
            ResearchContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem FileButton;
        private ToolStripMenuItem NewButton;
        private ToolStripMenuItem OpenButton;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem QuitButton;
        private ToolStripMenuItem ViewButton;
        private ToolStripMenuItem базуДанныхToolStripMenuItem;
        private ToolStripMenuItem исследованиеToolStripMenuItem;
        private TreeView DataTreeView;
        private Splitter splitter1;
        private ToolStrip Tools;
        private ToolStripButton FilterButton;
        private ImageList TreeViewImageList;
        private ToolStripLabel SearchLabel;
        private ToolStripTextBox SearchBox;
        private ToolStripSplitButton SortButton;
        private ToolStripMenuItem AlphabethOrder;
        private ToolStripMenuItem DateOrder;
        private ToolStripMenuItem ExplorerRootButton;
        private ToolStripMenuItem ResearcherRootButton;
        private ToolStripMenuItem ResearchRootButton;
        private ToolStripMenuItem DataBasesButton;
        private ToolStripMenuItem SaveButton;
        private ToolStripMenuItem SaveAllButton;
        private ToolStripMenuItem WindowsButton;
        private ToolStripMenuItem CascadeButton;
        private ToolStripMenuItem OrderSwitched;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private ContextMenuStrip EmptySpaceContextMenu;
        private ToolStripMenuItem AddButton;
        private ToolStripMenuItem AddNewResearcherButton;
        private ToolStripMenuItem AddNewResearchButton;
        private ToolStripMenuItem InvalidateButton;
        private ContextMenuStrip ResearcherContextMenu;
        private ToolStripMenuItem NewResearchButton;
        private ToolStripMenuItem RenameResearcherButton;
        private ToolStripMenuItem DeleteResearcherButton;
        private ContextMenuStrip ResearchContextMenu;
        private ToolStripMenuItem CreateDataBaseButton;
        private ToolStripMenuItem OpenDataBaseButton;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem VerticalButton;
        private ToolStripMenuItem HorizontalButton;
        private ToolStripMenuItem OpenResearchButton;
        private ToolStripMenuItem DeleteResearchButton;
        private ToolStripMenuItem Models;
        private ToolStripMenuItem Markers;
    }
}
