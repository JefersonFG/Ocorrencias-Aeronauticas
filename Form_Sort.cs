﻿using System;
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
        private List<DadosOcorrencia> lista_dados_ocorrencias = null;

        public Form_Sort(List<DadosOcorrencia> lista_desordenada)
        {
            InitializeComponent();
            lista_dados_ocorrencias = lista_desordenada;
        }

        private void btnSortGo_Click(object sender, EventArgs e)
        {
            Form_Aguarde pleaseWait = new Form_Aguarde();

            // Display form modelessly
            pleaseWait.Show();
            this.Enabled = false;

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();

            if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Bubble Sort (BBST)"))
            {
                
                //MessageBox.Show("Bubble Sort selecionado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.bubbleSort_codigo_ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach(DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.bubbleSort_localidade(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
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
