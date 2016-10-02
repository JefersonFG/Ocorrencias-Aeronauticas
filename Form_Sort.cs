using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocorrências_Aeronáuticas
{
    public partial class Form_Sort : Form
    {
        public Form_Sort()
        {
            InitializeComponent();
        }

        private void btnSortGo_Click(object sender, EventArgs e)
        {
            if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Bubble Sort (BBST)"))
            {
                MessageBox.Show("Bubble Sort selecionado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
