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
    public partial class ModelsExplorerForm : Form
    {
        private string adress;

        private string modelName;
        private string description;
        private List<object> items = new List<object>();
        private ListBoxItem previousSelected = null;
        private ListBoxItem SelectedModel { get => Models.SelectedItem as ListBoxItem; set => Models.SelectedItem = null; }
        public string ModelName { get => ModelNameBox.Text; set => ModelNameBox.Text = value; }
        public string Description { get => DescriptionBox.Text; set => DescriptionBox.Text = value; }

        public ModelsExplorerForm()
        {
            InitializeComponent();
        }
        public ModelsExplorerForm(string adrs)
        {
            InitializeComponent();
            adress = adrs;
        }

        private void ModelsExplorerForm_Load(object sender, EventArgs e)
        {
            LoadListBoxItems();
        }
        private void LoadListBoxItems()
        {
            items.Clear();
            using (var connect = new SQLiteConnection(adress))
            {
                connect.Open();
                var cmnd = new SQLiteCommand(@"PRAGMA foreign_keys = ON;", connect);
                cmnd.ExecuteNonQuery();

                cmnd = new SQLiteCommand(
                    "SELECT Inf_Model_ID, Inf_Model_Name, Inf_Model_Description FROM Inf_Models"
                , connect);
                using (var dr = cmnd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var item = new ListBoxItem(dr["Inf_Model_Name"].ToString(), dr["Inf_Model_Description"].ToString(), dr["Inf_Model_ID"].ToString());
                        items.Add(item);
                    }
                }
                connect.Close();
            }
            InvalidateModels();
        }
        private void InvalidateModels()
        {
            Models.Items.Clear();
            foreach (object item in items)
                if (item.ToString().Contains(SearchBox.Text))
                    Models.Items.Add(item);
            if (Models.Items.Count == 0)
            {
                Models.Items.Add("Ничего не найдено");
                Models.Enabled = false;
                return;
            }
            Models.Enabled = true;
        }
        private void Models_SelectedChanged(object sender, EventArgs e)
        {
            if (SelectedModel == null)
            {
                ModelNameBox.Enabled = DescriptionBox.Enabled = DeleteButton.Enabled = false;
                ModelName = modelName = "";
                Description = description = "Выберите модель из списка или создайте новую";
                return;
            }
            ModelNameBox.Enabled = DescriptionBox.Enabled = DeleteButton.Enabled = true;
            ModelName = modelName = SelectedModel.Text;
            Description = description = SelectedModel.Description;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var dlg = new ModelForm(adress);
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
            {
                items.Add(new ListBoxItem(dlg.ModelName, dlg.Description, dlg.Tag));
                InvalidateModels();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = $"Вы действительно хотите удалить модель {modelName} и все связанные с ней записи из БД?";
            var dlg = MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
                using (var connect = new SQLiteConnection(adress))
                {
                    connect.Open();
                    var cmnd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connect);
                    cmnd.ExecuteNonQuery();

                    cmnd = new SQLiteCommand(
                    $@"DELETE FROM Inf_Models WHERE Inf_Model_ID = {SelectedModel.Tag};"
                    , connect);
                    cmnd.ExecuteNonQuery();

                    items.Remove(SelectedModel);
                    SelectedModel = null;
                    InvalidateModels();
                }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var connect = new SQLiteConnection(adress))
            {
                connect.Open();
                var cmnd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connect);
                cmnd.ExecuteNonQuery();

                cmnd = new SQLiteCommand(
                $@"UPDATE Inf_Models SET Inf_Model_Name = '{ModelName}', Inf_Model_Description = '{Description}'
                    WHERE Inf_Model_ID = {previousSelected.Tag};"
                , connect);
                cmnd.ExecuteNonQuery();

                previousSelected.Text = modelName = ModelName;
                previousSelected.Description = description = Description;
                InvalidateModels();
            }
            SaveButton.Enabled = false;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (SaveButton.Enabled)
            {
                string message = $"В модели \"{SelectedModel}\" остались несохнаненные изменения. Вы желаете их сохранить?";
                var dlg = MessageBox.Show(message, "Несохранённые изменения", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                    SaveButton_Click(sender, e);
                else if (dlg == DialogResult.Cancel)
                    return;
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = ModelName != modelName || Description != description;
            previousSelected = SelectedModel;
        }

        private void Models_Enter(object sender, EventArgs e)
        {
            if (SaveButton.Enabled)
            {
                string message = $"В модели \"{previousSelected}\" остались несохнаненные изменения. Вы желаете их сохранить?";
                var dlg = MessageBox.Show(message, "Несохранённые изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                    SaveButton_Click(sender, e);
                Models.BeginInvoke((Action)(() =>
                {
                    Models_SelectedChanged(sender, e); // Или вызовите нужный метод
                }));
                SaveButton.Enabled = false;
            }
        }

        private void InvalidateButton_Click(object sender, EventArgs e)
        {
            LoadListBoxItems();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateModels();
        }
    }
}
