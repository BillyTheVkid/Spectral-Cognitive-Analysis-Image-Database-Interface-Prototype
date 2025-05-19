using System.Diagnostics;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;
using System.Data;

namespace ImageDataBaseInterface
{
    public partial class FormMain : Form
    {
        public List<TreeNode> treeNodes = new List<TreeNode>();
        private TreeNode selectedNode = new TreeNode();

        public string CurrentDataBasePath { get; set; }
        public string Adress { get => $"Data Source={CurrentDataBasePath};Version=3;"; }
        public TreeRoot Root { get; set; }
        private OrderBy Order { get; set; }
        private bool NaturalOrder { get; set; }

        public enum TreeRoot
        {
            Researcher,
            Research
        }
        private enum OrderBy
        {
            Alphabeth,
            Date
        }

        public FormMain()
        {
            InitializeComponent();
            Tools.Renderer = new MyToolStripRender();
            ResearcherRootButton_Click(this, new EventArgs());
            NaturalOrder = true;
            Order = OrderBy.Alphabeth;
        }

        public void RequestData()
        {
            treeNodes.Clear();
            if (CurrentDataBasePath != null)
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = Adress;
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();

                    if (Root == TreeRoot.Researcher)
                    {
                        var cmnd = new SQLiteCommand(
                        $@"SELECT DISTINCT R.Researcher_ID, R.Researcher_Name
                            FROM Researchers R LEFT OUTER JOIN Researches Res
                            ON R.Researcher_ID = Res.Researcher_ID
                            ORDER BY {(Order == OrderBy.Alphabeth ? "R.Researcher_Name ASC" : "Res.Research_Date DESC")};"
                        , connect);

                        using (var dr = cmnd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var node = new TreeNode(dr["Researcher_Name"].ToString(), 0, 0);
                                treeNodes.Add(node);
                                node.Tag = dr["Researcher_ID"];
                            }
                        }

                        if (treeNodes.Count > 0)
                            foreach (TreeNode researcherNode in treeNodes)
                            {
                                cmnd = new SQLiteCommand(
                                $@"SELECT DISTINCT Research_ID, Research_Name, Research_Date
                                FROM Researches
                                WHERE Researcher_ID = {researcherNode.Tag.ToString()}
                                ORDER BY {(Order == OrderBy.Alphabeth ? "Research_Name ASC" : "Research_Date DESC")};"
                                , connect);

                                using (var dr = cmnd.ExecuteReader())
                                {
                                    researcherNode.Nodes.Clear();
                                    while (dr.Read())
                                    {
                                        var researchNode = new TreeNode(dr["Research_Name"].ToString(), 1, 1);
                                        researcherNode.Nodes.Add(researchNode);
                                        researchNode.Tag = dr["Research_ID"];
                                    }
                                }
                            }
                    }
                    else
                    {
                        var cmnd = new SQLiteCommand(
                        $@"SELECT DISTINCT Research_ID, Research_Name, Research_Date FROM Researches
                            ORDER BY {(Order == OrderBy.Alphabeth ? "Research_Name ASC" : "Research_Date DESC")};"
                        , connect);

                        using (var dr = cmnd.ExecuteReader())
                        {
                            DataTreeView.Nodes.Clear();
                            while (dr.Read())
                            {
                                var researchNode = new TreeNode(dr["Research_Name"].ToString(), 1, 1);
                                researchNode.Tag = dr["Research_ID"];
                                treeNodes.Add(researchNode);
                            }
                        }
                    }
                    connect.Close();
                }
            InvalidateTree();
        }
        public void InvalidateTree()
        {
            DataTreeView.Nodes.Clear();
            if (Root == TreeRoot.Research)
                foreach (TreeNode research in treeNodes)
                {
                    research.ContextMenuStrip = ResearchContextMenu;
                    DataTreeView.Nodes.Add(research);
                }
            else
                for (int i = NaturalOrder ? 0 : treeNodes.Count - 1;
                    NaturalOrder ? i < treeNodes.Count : i >= 0;
                    i += 1 - 2 * (NaturalOrder ? 0 : 1))
                {
                    TreeNode newNode = new TreeNode(treeNodes[i].Text, treeNodes[i].ImageIndex, treeNodes[i].SelectedImageIndex);
                    newNode.Tag = treeNodes[i].Tag;

                    if (treeNodes[i].Text.Contains(SearchBox.Text))
                    {
                        treeNodes[i].ContextMenuStrip = ResearcherContextMenu;
                        for (int j = NaturalOrder ? 0 : treeNodes[i].Nodes.Count - 1;
                            NaturalOrder ? j < treeNodes[i].Nodes.Count : j >= 0;
                            j += 1 - 2 * (NaturalOrder ? 0 : 1))
                        {
                            treeNodes[i].Nodes[j].ContextMenuStrip = ResearchContextMenu;
                        }
                        DataTreeView.Nodes.Add(treeNodes[i]);
                    }
                    else
                    {
                        newNode.ContextMenuStrip = ResearcherContextMenu;
                        for (int j = NaturalOrder ? 0 : treeNodes[i].Nodes.Count - 1;
                            NaturalOrder ? j < treeNodes[i].Nodes.Count : j >= 0;
                            j += 1 - 2 * (NaturalOrder ? 0 : 1))
                        {
                            if (treeNodes[i].Nodes[j].Text.Contains(SearchBox.Text))
                            {
                                treeNodes[i].Nodes[j].ContextMenuStrip = ResearchContextMenu;
                                newNode.Nodes.Add(treeNodes[i].Nodes[j].Clone() as TreeNode);
                            }
                        }
                        if (newNode.Nodes.Count > 0)
                        {
                            DataTreeView.Nodes.Add(newNode);
                        }
                    }
                }
        }

        private void СreateStandartColorsFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StandartColors.INI");

            if (File.Exists(filePath))
            {
                Console.WriteLine("Файл StandartColors.INI уже существует.  Создание пропущено.");
                return;
            }

            string[] colors = {
                "255\t63\t63",
                "252\t84\t45",
                "246\t106\t29",
                "236\t129\t16",
                "223\t152\t6",
                "206\t174\t1",
                "187\t194\t0",
                "166\t212\t2",
                "144\t228\t9",
                "121\t240\t20",
                "99\t249\t34",
                "77\t254\t51",
                "57\t254\t70",
                "39\t251\t91",
                "24\t243\t114",
                "12\t232\t137",
                "4\t218\t159",
                "0\t200\t181",
                "0\t181\t200",
                "4\t159\t218",
                "12\t137\t232",
                "24\t114\t243",
                "39\t91\t251",
                "57\t70\t254",
                "77\t51\t254",
                "99\t34\t249",
                "121\t20\t240",
                "144\t9\t228",
                "166\t2\t212",
                "187\t0\t194",
                "206\t1\t174",
                "223\t6\t152",
                "236\t16\t129",
                "246\t29\t106",
                "252\t45\t84"
            };
            File.WriteAllLines(filePath, colors);
        }
        private void InsertStandartColors()
        {
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StandartColors.INI"));
            using (var connect = new SQLiteConnection(Adress))
            {
                connect.Open();
                using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                    command.ExecuteNonQuery();
                foreach (string line in lines)
                {
                    string[] values = line.Split('\t'); // Разделяем значения по табуляции

                    if (values.Length == 3 && int.TryParse(values[0], out int red) && int.TryParse(values[1], out int green) && int.TryParse(values[2], out int blue))
                    {
                        Bitmap image = new Bitmap(1, 1);

                        image.SetPixel(0, 0, Color.FromArgb(red, green, blue));
                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, ImageFormat.Png);
                            imageBytes = ms.ToArray();
                        }

                        using (SQLiteCommand cmnd = new SQLiteCommand(
                            $@"INSERT INTO Spectrum_Colors (Red, Green, Blue, Monochrome_Color) VALUES ({red}, {green}, {blue},  @MonochromeColor);"
                        , connect))
                        {
                            cmnd.Parameters.AddWithValue("@MonochromeColor", imageBytes);
                            cmnd.ExecuteNonQuery();
                        }


                        image.Dispose();
                    }
                    else
                    {
                        Console.WriteLine($"Пропущена строка из-за неверного формата: {line}");
                    }
                }
            }
        }

        #region Файл
        private void CreateNewDataBase(object sender, EventArgs e)
        {
            var dlg = new DataBaseForm();
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                string databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"{dlg.DataBaseName}.db");

                string dataDirectory = Path.GetDirectoryName(databaseFilePath);

                if (!Directory.Exists(dataDirectory))
                    Directory.CreateDirectory(dataDirectory);

                SQLiteConnection.CreateFile(databaseFilePath);

                CurrentDataBasePath = databaseFilePath;

                СreateStandartColorsFile();

                #region Первичные SQL запросы
                using (var connect = new SQLiteConnection(Adress))
                {
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();


                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Researchers (
                            Researcher_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Researcher_Name VARCHAR(255) NOT NULL
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Researches (
                            Research_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Research_Date DATE NOT NULL,
                            Research_Name VARCHAR(255) NOT NULL,
                            Research_Description TEXT,
                            Researcher_ID INTEGER,
                            FOREIGN KEY (Researcher_ID) REFERENCES Researchers(Researcher_ID) ON DELETE CASCADE
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Categories (
                            Category_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Category_Name VARCHAR(255) NOT NULL,
                            Category_type VARCHAR(255)
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Markers (
                            Marker_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Marker_Name VARCHAR(255) NOT NULL,
                            Marker_Category_ID INTEGER,
                            FOREIGN KEY (Marker_Category_ID) REFERENCES Categories(Category_ID) ON DELETE CASCADE
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Inf_Models (
                            Inf_Model_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Inf_Model_Name VARCHAR(255) NOT NULL,
                            Inf_Model_Description TEXT
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Spectrum_Colors (
                            Spectrum_Color_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Color_Name VARCHAR(255),
                            Red INTEGER NOT NULL,
                            Green INTEGER NOT NULL,
                            Blue INTEGER NOT NULL,
                            Monochrome_Color BLOB
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Rules (
                            Rule_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Rule_Name VARCHAR(255) NOT NULL
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Spectrum_Colors_Shades (
                            Spectum_Color_Shade_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Shade_Name VARCHAR(255),
                            Red INTEGER NOT NULL,
                            Green INTEGER NOT NULL,
                            Blue INTEGER NOT NULL,
                            Monochrome_Color BLOB,
                            Spectrum_Color_ID INTEGER,
                            Rule_ID INTEGER,
                            FOREIGN KEY (Spectrum_Color_ID) REFERENCES Spectrum_Colors(Spectrum_Color_ID) ON DELETE CASCADE,
                            FOREIGN KEY (Rule_ID) REFERENCES Rules(Rule_ID) ON DELETE CASCADE
                        );", connect))
                        cmnd.ExecuteNonQuery();

                    using (var cmnd = new SQLiteCommand(
                        @"CREATE TABLE IF NOT EXISTS Inf_Coeffitients (
                            Inf_Coeffitient_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                            Inf_Coeffitient_Value REAL,
                            Inf_Model_ID INTEGER,
                            SpectrumColor_ID INTEGER,
                            Marker_ID INTEGER,
                            Research_ID INTEGER,
                            FOREIGN KEY (Inf_Model_ID) REFERENCES Inf_Models(Inf_Model_ID) ON DELETE CASCADE,
                            FOREIGN KEY (SpectrumColor_ID) REFERENCES Spectrum_Colors(Spectrum_Color_ID) ON DELETE CASCADE,
                            FOREIGN KEY (Marker_ID) REFERENCES Markers(Marker_ID) ON DELETE CASCADE,
                            FOREIGN KEY (Research_ID) REFERENCES Researches(Research_ID) ON DELETE CASCADE
                        );", connect))
                        cmnd.ExecuteNonQuery();
                    connect.Close();
                }
                #endregion

                InsertStandartColors();

                //Доработать
                AddButton.Enabled = true;
                InvalidateButton.Enabled = true;
                Models.Enabled = true;
                Markers.Enabled = true;
                RequestData();
                Text = Path.GetFileNameWithoutExtension(CurrentDataBasePath); ;
            }
            dlg.Dispose();
        }
        private void OpenNewDataBase(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "SQLite Database Files (*.db)|*.db";
            dlg.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dlg.InitialDirectory))
                Directory.CreateDirectory(dlg.InitialDirectory);
            dlg.Title = "Выберите файл базы данных";
            dlg.Multiselect = false;


            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string databaseFilePath = dlg.FileName;

                CurrentDataBasePath = databaseFilePath;

                //Доработать
                AddButton.Enabled = true;
                InvalidateButton.Enabled = true;
                Models.Enabled = true;
                Markers.Enabled = true;
                RequestData();
                Text = Path.GetFileNameWithoutExtension(CurrentDataBasePath);
            }
            dlg.Dispose();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is ResearchForm)
                (ActiveMdiChild as ResearchForm).Save(); ;
        }
        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            foreach (ResearchForm rsrch in MdiChildren)
                rsrch.Save();
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Вид
        private void ResearcherRootButton_Click(object sender, EventArgs e)
        {
            Root = TreeRoot.Researcher;
            ResearcherRootButton.Enabled = false;
            ResearcherRootButton.Checked = true;
            ResearchRootButton.Enabled = true;
            ResearchRootButton.Checked = false;
            RequestData();
        }
        private void ResearchRootButton_Click(object sender, EventArgs e)
        {
            Root = TreeRoot.Research;
            ResearchRootButton.Enabled = false;
            ResearchRootButton.Checked = true;
            ResearcherRootButton.Enabled = true;
            ResearcherRootButton.Checked = false;
            RequestData();
        }
        #endregion

        #region Окна
        private void CascadeButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void OrderSwitched_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void VerticalButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void HorizontalButton_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);

        }
        #endregion

        #region Базы Данных
        private void DataBasesButton_DropDownOpening(object sender, EventArgs e)
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string[] files = Directory.GetFiles(directory, "*.db");


            ToolStripMenuItem directoryEmpty = new ToolStripMenuItem("Не найдено");
            directoryEmpty.Enabled = false;
            DataBasesButton.DropDownItems.Add(directoryEmpty);

            if (files.Length != 0)
            {
                DataBasesButton.DropDownItems.Clear();
            }

            ToolStripMenuItem OpenDataFolder = new ToolStripMenuItem("Перейти в папку Data -->");
            OpenDataFolder.Click += (sender, e) => OpenFolder_Click(directory);
            DataBasesButton.DropDownItems.Add(OpenDataFolder);

            foreach (string filePath in files)
            {
                string name = Path.GetFileNameWithoutExtension(filePath);

                ToolStripMenuItem fileMenuItem = new ToolStripMenuItem(name);

                fileMenuItem.Click += (sender, e) => DatabaseMenuItem_Click(filePath);

                fileMenuItem.Checked = Path.GetFileNameWithoutExtension(CurrentDataBasePath) == name;
                fileMenuItem.Enabled = !(Path.GetFileNameWithoutExtension(CurrentDataBasePath) == name);

                DataBasesButton.DropDownItems.Add(fileMenuItem);
            }
        }
        private void OpenFolder_Click(string directory)
        {
            Process.Start("explorer.exe", directory);
        }
        private void DatabaseMenuItem_Click(string filePath)
        {
            //Доработать
            CurrentDataBasePath = filePath;
            AddButton.Enabled = true;
            InvalidateButton.Enabled = true;
            Models.Enabled = true;
            Markers.Enabled = true;
            Text = Path.GetFileNameWithoutExtension(CurrentDataBasePath);
            RequestData();
        }
        #endregion

        #region Поиск, Сортировка, фильтры
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateTree();
        }

        private void SortButton_ButtonClick(object sender, EventArgs e)
        {
            NaturalOrder = !NaturalOrder;
            InvalidateTree();
        }

        private void AlphabethOrder_Click(object sender, EventArgs e)
        {
            Order = OrderBy.Alphabeth;
            AlphabethOrder.Checked = true;
            AlphabethOrder.Enabled = false;
            DateOrder.Checked = false;
            DateOrder.Enabled = true;
            RequestData();
        }

        private void DateOrder_Click(object sender, EventArgs e)
        {
            Order = OrderBy.Date;
            DateOrder.Checked = true;
            DateOrder.Enabled = false;
            AlphabethOrder.Checked = false;
            AlphabethOrder.Enabled = true;
            RequestData();
        }
        #endregion

        #region Контекстное меню "Пустая область"
        private void AddNewResearcherButton_Click(object sender, EventArgs e)
        {
            var dlg = new ResearcherForm();
            dlg.Text = "Новый исследователь";
            dlg.ShowDialog(this);

            if (dlg.DialogResult == DialogResult.OK)
            {
                int newId = 0;
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = Adress;
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();

                    var cmnd = new SQLiteCommand(
                        $@"INSERT INTO Researchers (Researcher_Name) VALUES ('{dlg.Researcher}');"
                        , connect
                    );
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                        $@"SELECT MAX(Researcher_ID) AS ID FROM Researchers;"
                        , connect
                    );
                    using (var dr = cmnd.ExecuteReader())
                        if (dr.Read())
                            newId = int.Parse(dr["ID"].ToString());
                    connect.Close();
                }
                if (Root != TreeRoot.Research)
                {
                    TreeNode newResearcher = new TreeNode();
                    newResearcher.Text = dlg.Researcher;
                    newResearcher.Tag = newId;
                    newResearcher.ContextMenuStrip = ResearcherContextMenu;
                    treeNodes.Add(newResearcher);
                    DataTreeView.Nodes.Add(newResearcher.Clone() as TreeNode);
                }
            }
        }
        private void AddNewResearchButton_Click(object sender, EventArgs e)
        {
            if (Adress == "Data Source=;Version=3;")
            {
                MessageBox.Show(this, "Вы не можете создать исследование вне базы данных.", "База данных не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rsrch = new ResearchForm(selectedNode != null ? selectedNode.Tag : null);
            rsrch.MdiParent = this;
            rsrch.Show();
        }
        private void InvalidateButton_Click(object sender, EventArgs e)
        {
            RequestData();
        }
        #endregion

        #region Контекстное меню "Исследователь"
        private void RenameResearcherButton_Click(object sender, EventArgs e)
        {
            var dlg = new ResearcherForm();
            dlg.Text = $"Переименование '{selectedNode.Text}'";
            dlg.ShowDialog();

            if (dlg.DialogResult == DialogResult.OK)
            {
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = Adress;
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();

                    var cmnd = new SQLiteCommand(
                        $@"UPDATE Researchers SET Researcher_Name = '{dlg.Researcher}'
                            WHERE Researcher_ID = {selectedNode.Tag};"
                    , connect);
                    cmnd.ExecuteNonQuery();
                    connect.Close();
                }
                foreach (TreeNode node in treeNodes)
                    if (node.Tag == selectedNode.Tag)
                        node.Text = dlg.Researcher;
                InvalidateTree();
            }
        }

        private void DeleteResearcherButton_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show($"Вы действительно хотите удалить исследователя \"{selectedNode.Text}\" и все упоминания о нём из базы данных?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = Adress;
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();

                    var cmnd = new SQLiteCommand(
                        $@"DELETE FROM Researchers WHERE Researcher_ID = {selectedNode.Tag};"
                    , connect);
                    cmnd.ExecuteNonQuery();
                    connect.Close();
                }
                List<TreeNode> nodesToRemove = new List<TreeNode>();
                foreach (TreeNode node in treeNodes)
                    if (node.Tag == selectedNode.Tag)
                        nodesToRemove.Add(node);
                foreach (TreeNode node in nodesToRemove)
                    if (node.Tag == selectedNode.Tag)
                        treeNodes.Remove(node);
                InvalidateTree();
            }
        }
        private void NodeContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            selectedNode = DataTreeView.GetNodeAt(DataTreeView.PointToClient(MousePosition));
        }
        #endregion

        #region Контекстное меню "Исследование"
        private void OpenResearchButton_Click(object sender, EventArgs e)
        {
            var rsrch = new ResearchForm(selectedNode.Tag, true);
            rsrch.MdiParent = this;
            rsrch.Text = selectedNode.Text;
            rsrch.Show();
        }

        private void DeleteResearchButton_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show($"Вы действительно хотите удалить исследование\"{selectedNode.Text}\" и все упоминания о нём из базы данных?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dlg == DialogResult.Yes)
            {
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = Adress;
                    connect.Open();
                    using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                        command.ExecuteNonQuery();

                    var cmnd = new SQLiteCommand(
                        $@"DELETE FROM Researches WHERE Research_ID = {selectedNode.Tag};"
                    , connect);
                    cmnd.ExecuteNonQuery();
                    connect.Close();
                }
                RequestData();
            }
        }
        #endregion

        private void Models_Click(object sender, EventArgs e)
        {
            if (Adress == "Data Source=;Version=3;")
            {
                MessageBox.Show(this, "База данных не выбрана, не удаётся получить доступ к моделям.", "База данных не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mdls = new ModelsExplorerForm(Adress);
            mdls.Text = $"Модели БД \"{Text}\"";
            mdls.MdiParent = this;
            mdls.Show();
        }

        private void Markers_Click(object sender, EventArgs e)
        {
            if (Adress == "Data Source=;Version=3;")
            {
                MessageBox.Show(this, "База данных не выбрана, не удаётся получить доступ к маркерам.", "База данных не выбрана", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var mrkrs = new MarkersExplorerForm(Adress);
            mrkrs.Text = $"Макеры БД \"{Text}\"";
            mrkrs.MdiParent = this;
            mrkrs.Show();
        }


    }
}
