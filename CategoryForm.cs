using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ImageDataBaseInterface
{
    public partial class CategoryForm: Form
    {
        private string adress;
        public string NewName { get => NameBox.Text; set => NameBox.Text = value; }
        public string Type { get => TypeBox.Text; set => TypeBox.Text = value; }
        public CategoryForm()
        {
            InitializeComponent();
        }
        public CategoryForm(string adrs, string text)
        {
            InitializeComponent();
            Text = text;
            adress = adrs;
        }

        private void Type_DropDown(object sender, EventArgs e)
        {
            TypeBox.Items.Clear();
            using (var connect = new SQLiteConnection(adress))
            {
                connect.Open();
                var cmnd = new SQLiteCommand("PRAGMA foreign_keys = ON", connect);
                cmnd.ExecuteNonQuery();

                cmnd = new SQLiteCommand(
                $@"SELECT DISTINCT Category_Type FROM Categories"
                , connect);

                using (var dr = cmnd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TypeBox.Items.Add(dr["Category_Type"].ToString());
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string message;
            if (NewName != "" && Type != "")
            {
                DialogResult = DialogResult.OK;
            }
            else if (NewName == "")
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
