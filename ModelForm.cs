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
    public partial class ModelForm : Form
    {
        private string adress;
        public string ModelName { get => ModelNameBox.Text; }
        public string Description { get => DescriptionBox.Text; }
        public ModelForm()
        {
            InitializeComponent();
        }
        public ModelForm(string adrs)
        {
            InitializeComponent();
            adress = adrs;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (ModelNameBox.Text == "")
            {
                string message = "Для сохранения модели необходимо заполнить обязательное поле \"Название модели\"!\n Оно отмечено значком \"♦\"";
                MessageBox.Show(message, "Заполните обязательные поля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connect = new SQLiteConnection())
            {
                connect.ConnectionString = adress;
                connect.Open();

                SQLiteCommand cmnd = new SQLiteCommand(
                $@"INSERT INTO Inf_Models (Inf_Model_Name, Inf_Model_Description)
                    VALUES ('{ModelNameBox.Text}', '{DescriptionBox.Text}');"
                , connect);
                cmnd.ExecuteNonQuery();

                cmnd = new SQLiteCommand(
                $@"SELECT MAX(Inf_Model_ID) AS ID FROM Inf_Models;"
                , connect);
                using (var dr = cmnd.ExecuteReader())
                {
                    dr.Read();
                    Tag = dr["ID"];
                }

                connect.Close();
            }
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (DescriptionBox.Text != "" || ModelNameBox.Text != "Новая модель")
            {
                string message = "У вас остались несохранённые изменения. Сохранить?";
                var dlg = MessageBox.Show(message, "Несохраненные изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    CreateButton_Click(sender, e);
                    return;
                }
                else if (dlg == DialogResult.Cancel)
                    return;
            }
            DialogResult = DialogResult.Cancel;
        }
    }
}
