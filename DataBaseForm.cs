using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDataBaseInterface
{
    public partial class DataBaseForm : Form
    {
        public string DataBaseName { get => NameBox.Text; set => NameBox.Text = value; }
        public DataBaseForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
                MessageBox.Show(this, "Пожалуйста, заполните обязательное поле 'Название'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"{DataBaseName}.db")))
                MessageBox.Show(this, "Файл с таким именем уже существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                DialogResult = DialogResult.OK;
                
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
