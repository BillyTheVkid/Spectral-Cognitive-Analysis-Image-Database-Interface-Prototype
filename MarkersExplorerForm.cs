using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImageDataBaseInterface.FormMain;

namespace ImageDataBaseInterface
{
    public partial class MarkersExplorerForm : Form
    {
        private string adress;
        public List<TreeNode> treeNodes = new List<TreeNode>();
        public MarkersExplorerForm()
        {
            InitializeComponent();
        }
        public MarkersExplorerForm(string adrs)
        {
            InitializeComponent();
            adress = adrs;
        }

        private void MarkersExplorerForm_Load(object sender, EventArgs e)
        {
            RequestData();
        }
        private void RequestData()
        {
            treeNodes.Clear();
            using (var connect = new SQLiteConnection())
            {
                connect.ConnectionString = adress;
                connect.Open();
                using (var command = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect))
                    command.ExecuteNonQuery();

                var cmnd = new SQLiteCommand(
                $@"SELECT Category_ID, Category_Name
                        FROM Categories
                        ORDER BY Category_Name ASC"
                , connect);

                using (var dr = cmnd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var node = new TreeNode(dr["Category_Name"].ToString(), 0, 0);
                        treeNodes.Add(node);
                        node.Tag = dr["Category_ID"];
                    }
                }

                foreach (TreeNode category in treeNodes)
                {
                    cmnd = new SQLiteCommand(
                    $@"SELECT Marker_ID, Marker_Name FROM Markers
                            WHERE Marker_Category_ID = {category.Tag}
                            ORDER BY Marker_Name ASC;"
                    , connect);

                    using (var dr = cmnd.ExecuteReader())
                    {
                        category.Nodes.Clear();
                        while (dr.Read())
                        {
                            var marker = new TreeNode(dr["Marker_Name"].ToString(), 1, 1);
                            category.Nodes.Add(marker);
                            marker.Tag = dr["Marker_ID"];
                        }
                    }
                }
                connect.Close();
            }
            InvalidateTree();
        }
        private void InvalidateTree()
        {
            MarkersTreeView.Nodes.Clear();
            foreach (TreeNode category in treeNodes)
            {
                if (category.Text.Contains(SearchBox.Text))
                {
                    category.ContextMenuStrip = CategoryContextMenu;
                    foreach (TreeNode marker in category.Nodes)
                    {
                        marker.ContextMenuStrip = MarkerContextMenu;
                    }
                    MarkersTreeView.Nodes.Add(category);
                }
                else
                {
                    TreeNode NewNode = new TreeNode(category.Text, category.ImageIndex, category.SelectedImageIndex);
                    NewNode.Tag = category.Tag;
                    NewNode.ContextMenuStrip = CategoryContextMenu;
                    for (int i = 0; i < category.Nodes.Count; i++)
                    {
                        category.Nodes[i].ContextMenuStrip = MarkerContextMenu;
                        if (category.Nodes[i].Text.Contains(SearchBox.Text))
                        {
                            NewNode.Nodes.Add(category.Nodes[i].Clone() as TreeNode);
                        }
                    }
                    if (NewNode.Nodes.Count > 0)
                    {
                        MarkersTreeView.Nodes.Add(NewNode);
                    }
                }
            }
            SelectedNode_Changed(this, new EventArgs());
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            var dlg = new CategoryForm(adress, "Новая категория");
            dlg.ShowDialog(this);
            if (dlg.DialogResult == DialogResult.OK)
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = adress;
                    connect.Open();
                    var cmnd = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect);
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                    $@"INSERT INTO Categories (Category_Name, Category_Type) VALUES ('{dlg.NewName}', '{dlg.Type}')"
                    , connect);
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                    $@"SELECT MAX(Category_ID) AS ID FROM Categories"
                    , connect);

                    TreeNode newCategory = new TreeNode(dlg.NewName, 0, 0);

                    using (var dr = cmnd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            newCategory.Tag = dr["ID"];
                        }
                    }

                    treeNodes.Add(newCategory);

                    InvalidateTree();

                    connect.Close();
                }
        }
        private void AddMarkerButton_Click(object sender, EventArgs e)
        {
            var dlg = new MarkerForm(adress, "Новый маркер");
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                using (var connect = new SQLiteConnection())
                {
                    connect.ConnectionString = adress;
                    connect.Open();
                    var cmnd = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect);
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                    $@"INSERT INTO Markers (Marker_Name, Marker_Category_ID) VALUES ('{dlg.NewName}', '{dlg.CategoryID}')"
                    , connect);
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                    $@"SELECT MAX(Marker_ID) AS ID FROM Markers"
                    , connect);

                    TreeNode newMarker = new TreeNode(dlg.NewName, 1, 1);

                    using (var dr = cmnd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            newMarker.Tag = dr["ID"];
                        }
                    }
                    RequestData();
                    foreach (TreeNode node in treeNodes)
                        if (node.Tag == dlg.CategoryID)
                            node.Nodes.Add(newMarker);

                    InvalidateTree();

                    connect.Close();
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateTree();
        }

        private void SelectedNode_Changed(object sender, EventArgs e)
        {
            EditButton.Enabled = DeleteButton.Enabled = ChoseButton.Enabled = MarkersTreeView.SelectedNode != null;
        }

        private void InvalidateButton_Click(object sender, EventArgs e)
        {
            RequestData();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (EditButton.Enabled)
            {
                if (MarkersTreeView.SelectedNode.ImageIndex == 0)
                {
                    var dlg = new CategoryForm(adress, $"{MarkersTreeView.SelectedNode.Text }(id = {MarkersTreeView.SelectedNode.Tag})");
                    dlg.Tag = MarkersTreeView.SelectedNode.Tag;
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        using (var connect = new SQLiteConnection(adress))
                        {
                            connect.Open();
                            var cmnd = new SQLiteCommand($@"PRAGMA foreign_keys = ON;", connect);
                            cmnd.ExecuteNonQuery();
                            cmnd = new SQLiteCommand(
                            $@"UPDATE Categories SET Category_Name = '{dlg.NewName}', Category_Type = '{dlg.Type}'
                                WHERE Category_ID = {MarkersTreeView.SelectedNode.Tag}"
                            , connect);
                            cmnd.ExecuteNonQuery();

                            foreach (TreeNode node in treeNodes)
                                if (node.Tag == MarkersTreeView.SelectedNode.Tag)
                                    node.Text = dlg.NewName;
                            connect.Close();
                        }
                    }
                }
                else
                {
                    var dlg = new MarkerForm(adress, $"{MarkersTreeView.SelectedNode.Text}(id = {MarkersTreeView.SelectedNode.Tag})");
                    dlg.Tag = MarkersTreeView.SelectedNode.Tag;
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        using (var connect = new SQLiteConnection(adress))
                        {
                            connect.Open();
                            var cmnd = new SQLiteCommand($@"PRAGMA foreign_keys = ON;", connect);
                            cmnd.ExecuteNonQuery();

                            cmnd = new SQLiteCommand(
                            $@"UPDATE Markers SET Marker_Name = '{dlg.NewName}', Marker_Category_ID = '{dlg.CategoryID}'
                                WHERE Marker_ID = {MarkersTreeView.SelectedNode.Tag}"
                            , connect);
                            cmnd.ExecuteNonQuery();

                            RequestData();

                            connect.Close();
                        }
                    }
                }
                MarkersTreeView.SelectedNode = null;
            }
        }
    }
}
