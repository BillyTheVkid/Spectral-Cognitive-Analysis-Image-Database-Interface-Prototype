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
    public partial class ResearcherForm : Form
    {
        public string Researcher { get => ResearcherBox.Text; }
        public ResearcherForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (Researcher != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show(this, $"Пожалуйста, заполните обязательное поле 'Исследователь'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
