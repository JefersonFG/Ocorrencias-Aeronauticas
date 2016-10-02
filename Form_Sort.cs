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
        private List<Aeronave> lista_aeronaves = null;

        public Form_Sort(List<Aeronave> aeronaves)
        {
            InitializeComponent();
            lista_aeronaves = aeronaves;
        }

        private void btnSortGo_Click(object sender, EventArgs e)
        {
            if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Bubble Sort (BBST)"))
            {
                //MessageBox.Show("Bubble Sort selecionado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    List<Aeronave> lista_aeronaves_ordenada = Sorting.bubbleSort_codigo_ocorrencia(lista_aeronaves);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_aeronaves_ordenada);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("fabricante"))
                {
                    List<Aeronave> lista_aeronaves_ordenada = Sorting.bubbleSort_fabricante(lista_aeronaves);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_aeronaves_ordenada);
                    form_listacompleta.ShowDialog();
                }
                

            }
            else
            {
                MessageBox.Show("Apenas o Bubble Sort (BBST) funciona por enquanto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        } //btnSortGo_Click()
    }
}
