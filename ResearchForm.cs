using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ImageDataBaseInterface
{
    public partial class ResearchForm : Form
    {
        private bool smthChanged = false;
        private string adress;

        private string researchName = "";
        private object researcherId = null;
        private string researcherName = "";
        private string description = "";
        private string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public string ResearchName { get => ResearchBox.Text; set => ResearchBox.Text = value; }
        public object ResearcherID { get => ResearcherBox.Tag; set => ResearcherBox.Tag = value; }
        public string ResearcherName { get => ResearcherBox.Text; set => ResearcherBox.Text = value; }
        public string Description { get => DescriptionBox.Text; set => DescriptionBox.Text = value; }
        public string Date
        {
            get => DateBox.Value.ToString("yyyy-MM-dd HH:mm:ss");
            set => DateBox.Value = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public ResearchForm()
        {
            InitializeComponent();
        }
        public ResearchForm(object Tag)
        {
            InitializeComponent();
            ResearcherID = researcherId = Tag;
        }
        public ResearchForm(object Tag, bool f)
        {
            this.Tag = Tag;
            InitializeComponent();
        }
        private void ResearchForm_Load(object sender, EventArgs e)
        {
            LoadResearchInfo();
            LoadGrid();
        }

        private void LoadResearchInfo()
        {
            adress = ((FormMain)MdiParent).Adress;
            using (var connect = new SQLiteConnection())
            {
                connect.ConnectionString = adress;
                connect.Open();
                {
                    if (Tag != null)
                    {
                        var cmnd = new SQLiteCommand(
                        $@"SELECT Res.Research_Name, Res.Research_Description, strftime('%d.%m.%Y', Research_Date) AS Date, R.Researcher_ID, R.Researcher_Name
                        FROM Researchers R RIGHT JOIN Researches Res ON R.Researcher_ID = Res.Researcher_ID
                        WHERE Research_ID = {Tag}"
                        , connect);

                        using (var dr = cmnd.ExecuteReader())
                            while (dr.Read())
                            {
                                ResearchName = researchName = dr["Research_Name"].ToString();
                                Description = description = dr["Research_Description"].ToString();
                                ResearcherName = researcherName = dr["Researcher_Name"].ToString();
                                ResearcherID = researcherId = dr["Researcher_ID"].ToString();
                                Date = date = DateTime.ParseExact(dr["Date"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        connect.Close();
                    }
                    else if (ResearcherID != null)
                    {
                        var cmnd = new SQLiteCommand(
                        $@"SELECT Researcher_Name FROM Researchers
                        WHERE Researcher_ID = {ResearcherID}"
                        , connect);

                        using (var dr = cmnd.ExecuteReader())
                            if (dr.Read())
                            {
                                ResearcherName = researcherName = dr["Researcher_Name"].ToString();
                                ResearcherID = researcherId;
                            }
                        date = Date;
                    }
                    else
                    {
                        date = Date;
                    }
                }
            }
            smthChanged = false;
            Text = ResearchName != "" ? ResearchName : "Новое исследование";
        }
        private void LoadGrid()
        {
            Grid.Rows.Clear();
            using (SQLiteConnection connect = new SQLiteConnection(adress))
            {
                connect.Open();

                using (SQLiteCommand cmnd = new SQLiteCommand(
                    "SELECT Spectrum_Color_ID, Color_Name, Red, Green, Blue, Monochrome_Color FROM Spectrum_Colors"
                , connect))
                {
                    using (SQLiteDataReader dr = cmnd.ExecuteReader())
                    {
                        List<ColorData> colorList = new List<ColorData>();

                        while (dr.Read())
                        {
                            int id = Convert.ToInt32(dr["Spectrum_Color_ID"]);
                            string colorName = dr["Color_Name"] != DBNull.Value ? dr["Color_Name"].ToString() : "---";
                            int red = Convert.ToInt32(dr["Red"]);
                            int green = Convert.ToInt32(dr["Green"]);
                            int blue = Convert.ToInt32(dr["Blue"]);
                            byte[] imageBytes = dr["Monochrome_Color"] as byte[];

                            Bitmap image = null;
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    image = new Bitmap(ms);
                                }
                            }

                            int rowIndex = Grid.Rows.Add();

                            Grid.Rows[rowIndex].Cells["ID"].Value = id;
                            Grid.Rows[rowIndex].Cells["ColorName"].Value = colorName;
                            Grid.Rows[rowIndex].Cells["Inf_Coef"].Value = "---";
                            Grid.Rows[rowIndex].Cells["Red"].Value = red;
                            Grid.Rows[rowIndex].Cells["Green"].Value = green;
                            Grid.Rows[rowIndex].Cells["Blue"].Value = blue;
                            Grid.Rows[rowIndex].Cells["Color"].Value = image;
                        }
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ResearchName == "")
            {
                string message = "Для сохранения исследования необходимо заполнить все обязательные поля!\n Они отмечены значком \"♦\"";
                MessageBox.Show(message, "Заполните обязательные поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (smthChanged)
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = adress;
                    connect.Open();

                    int researcher_Id = 0;
                    SQLiteCommand cmnd;

                    if (ResearcherID == null)
                    {
                        #region Новый исследователь
                        cmnd = new SQLiteCommand(
                        $@"INSERT INTO Researchers (Researcher_Name) VALUES ('{ResearcherName}')"
                        , connect);
                        cmnd.ExecuteNonQuery();

                        cmnd = new SQLiteCommand(
                        $@"SELECT MAX(Researcher_ID) AS ID FROM Researchers"
                        , connect);
                        using (var dr = cmnd.ExecuteReader())
                            if (dr.Read())
                                researcher_Id = int.Parse(dr["ID"].ToString());

                        ResearcherID = researcherId = researcher_Id;
                        smthChanged = false;

                        if (((FormMain)MdiParent).Root == FormMain.TreeRoot.Researcher)
                        {
                            var rNode = new TreeNode(ResearcherName, 0, 0);
                            rNode.Tag = ResearcherID;
                            ((FormMain)MdiParent).treeNodes.Add(rNode);
                        }
                        #endregion
                    }

                    if (Tag == null)
                    {
                        #region Новое исследование
                        cmnd = new SQLiteCommand(
                        $@"INSERT INTO Researches (Research_Name, Research_Description, Research_Date, Researcher_ID)
                                VALUES ('{ResearchName}', '{Description}', '{Date}', '{ResearcherID}');"
                        , connect);
                        cmnd.ExecuteNonQuery();

                        int research_Id = 0;
                        cmnd = new SQLiteCommand(
                        $@"SELECT MAX(Research_ID) AS ID FROM Researches"
                        , connect);
                        using (var dr = cmnd.ExecuteReader())
                            if (dr.Read())
                                research_Id = int.Parse(dr["ID"].ToString());
                        Tag = research_Id;

                        TreeNode newResearch = new TreeNode(ResearchName, 1, 1);
                        newResearch.Tag = Tag;

                        if (((FormMain)MdiParent).Root == FormMain.TreeRoot.Researcher)
                        {
                            foreach (TreeNode node in ((FormMain)MdiParent).treeNodes)
                                if (node.Tag == ResearcherID)
                                    node.Nodes.Add(newResearch);
                        }
                        else
                            ((FormMain)MdiParent).treeNodes.Add(newResearch);
                        #endregion
                    }
                    else
                    {
                        #region Старое исследование
                        cmnd = new SQLiteCommand(
                        $@"UPDATE Researches SET Research_Name = '{ResearchName}', Research_Description = '{Description}',
                                Research_Date = '{Date}', Researcher_ID = '{ResearcherID}'
                                WHERE Research_ID = {Tag};"
                        , connect);
                        cmnd.ExecuteNonQuery();

                        ((FormMain)MdiParent).RequestData();
                        #endregion
                    }

                    researcherId = ResearcherID;
                    researcherName = ResearcherName;
                    researchName = ResearchName;
                    description = Description;
                    date = Date;

                    connect.Close();
                    ((FormMain)MdiParent).InvalidateTree();
                    smthChanged = false;
                    Text = ResearchName;
                    ResearchForm_Load(sender, e);
                }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (smthChanged)
            {
                var warning = MessageBox.Show(this, "В исследовании есть несохраненные изменения! Сохранить их?", "Несохраненные изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (warning == DialogResult.Yes)
                {
                    SaveButton_Click(sender, e);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (warning == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void SomethingChanged(object sender, EventArgs e)
        {
            smthChanged = ResearcherID != researcherId ||
                ResearcherName != researcherName ||
                ResearchName != researchName ||
                Description != description ||
                Date != date;
            if (smthChanged && Tag != null)
                Text = researchName + " *";
            else if (smthChanged && Tag == null)
                Text = "Новое исследование *";
            else if (!smthChanged && Tag != null)
                Text = researchName;
            else if (!smthChanged && Tag == null)
                Text = "Новое исследование";
        }

        #region Исследователь
        private void ResearcherName_Changed(object sender, EventArgs e)
        {
            ResearcherID = null;
            if (ResearcherName == "")
                ResearcherID = "";
            SomethingChanged(sender, e);
            researcherName = ResearcherName;
        }
        private void ResearcherBox_DropDown(object sender, EventArgs e)
        {
            ResearcherBox.Items.Clear();
            ResearcherBox.Items.Add(new ComboBoxItem("Не указан", ""));
            using (var connect = new SQLiteConnection())
            {
                connect.ConnectionString = adress;
                connect.Open();
                var cmnd = new SQLiteCommand(
                    $@"SELECT Researcher_ID, Researcher_Name FROM Researchers"
                    , connect);

                using (var dr = cmnd.ExecuteReader())
                    while (dr.Read())
                    {
                        ResearcherBox.Items.Add(new ComboBoxItem(dr["Researcher_Name"].ToString(), dr["Researcher_ID"]));
                    }
                connect.Close();
            }
        }
        private void ResearcherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ResearcherBox.SelectedItem is ComboBoxItem selectedItem)
                ResearcherBox.Tag = selectedItem.Tag;
        }
        #endregion

        #region Модель

        #endregion

        public void Save()
        {
            EventArgs e = null;
            SaveButton_Click(this, e);
        }
    }
}
