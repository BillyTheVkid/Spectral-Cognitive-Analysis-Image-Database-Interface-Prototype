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

namespace ImageDataBaseInterface
{
    public partial class MarkerForm : Form
    {
        private string adress;
        private string name;
        private object categoryId;
        public string NewName { get => NameBox.Text; set => NameBox.Text = value; }
        public object CategoryID { get => CategoryBox.Tag; set => CategoryBox.Tag = value; }
        public MarkerForm()
        {
            InitializeComponent();
        }

        public MarkerForm(string adrs, string text)
        {
            InitializeComponent();
            Text = text;
            adress = adrs;
        }

        private void CategoryBox_DropDown(object sender, EventArgs e)
        {
            CategoryBox.Items.Clear();
            CategoryBox.Items.Add("Добавить категорию");
            using (var connect = new SQLiteConnection(adress))
            {
                connect.Open();
                var cmnd = new SQLiteCommand($@"PRAGMA foreign_keys = ON;", connect);
                cmnd.ExecuteNonQuery();

                cmnd = new SQLiteCommand(
                $@"SELECT * FROM Categories;"
                , connect);
                using (var dr = cmnd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CategoryBox.Items.Add(new Category(dr["Category_Name"].ToString(), dr["Category_Type"].ToString(), dr["Category_ID"]));
                    }
                }
                connect.Close();
            }
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryBox.SelectedItem is Category selectedItem)
                CategoryBox.Tag = selectedItem.Tag;
        }

        private void CategoryBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CategoryBox.SelectedItem.ToString() == "Добавить категорию")
            {
                var dlg = new CategoryForm(adress, "Новая категория");
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    using (var connect = new SQLiteConnection(adress))
                    {
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

                        Category newCategory = new Category(dlg.NewName, dlg.Type, "");

                        using (var dr = cmnd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                newCategory.Tag = dr["ID"];
                            }
                        }

                        CategoryBox.Items.Add(newCategory);
                        CategoryBox.SelectedItem = newCategory;

                        connect.Close();
                    }
                }
            }

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string message;
            if (NewName != "" && CategoryID != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                message = $"Пожалуйста, заполните обязательные поля. Они отмечены значком \"♦\"";
                MessageBox.Show(message, "Заполните обязательные поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
