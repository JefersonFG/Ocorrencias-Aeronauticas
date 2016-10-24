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
    public partial class TabelaForm : Form
    {
        private Dictionary<int, DadosOcorrencia> lista_dados_ocorrencias = null;

        public TabelaForm(Dictionary<int, DadosOcorrencia> ocorrencias)
        {
            InitializeComponent();
            this.lista_dados_ocorrencias = ocorrencias;

            while (this.gridListaCompleta.Columns.Count > 0)
            {
                this.gridListaCompleta.Columns.RemoveAt(0);
            }

            DataGridViewTextBoxColumn novaColuna;

            List<string> colunas = new List<string>();
            colunas.Add("codigo_ocorrencia");
            colunas.Add("dia_ocorrencia");
            colunas.Add("localidade");
            colunas.Add("modelo");
            colunas.Add("fabricante");
            colunas.Add("fator");

            for (int i = 0; i < colunas.Count; i++)
            {
                novaColuna = new DataGridViewTextBoxColumn
                {
                    HeaderText = colunas[i]
                };
                this.gridListaCompleta.Columns.Add(novaColuna); //1
            }



            foreach (KeyValuePair<int, DadosOcorrencia> dados_ocorrencia in lista_dados_ocorrencias)
            {
                int codigo_ocorrencia = dados_ocorrencia.Value.codigo_ocorrencia;
                Aeronave aeronave = dados_ocorrencia.Value.aeronave;
                Ocorrencia ocorrencia = dados_ocorrencia.Value.ocorrencia;
                FatorContribuinte fator = dados_ocorrencia.Value.fator;

                DateTime dia_ocorrencia = new DateTime();
                string localidade = "";
                string modelo = "";
                string fabricante = "";
                string fator_contrib = "";

                if(aeronave != null)
                {
                    modelo = aeronave.modelo;
                    fabricante = aeronave.fabricante;
                }
                if(ocorrencia != null)
                {
                    dia_ocorrencia = ocorrencia.dia_ocorrencia;
                    localidade = ocorrencia.localidade;
                }
                if(fator != null)
                {
                    fator_contrib = fator.fator;
                }

                this.gridListaCompleta.Rows.Add("" + codigo_ocorrencia,
                                                   dia_ocorrencia,
                                                   localidade,
                                                   modelo,
                                                   fabricante,
                                                   fator_contrib);
            }//foreach            
        }

        

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<DadosOcorrencia> lista = new List<DadosOcorrencia>();
            foreach (KeyValuePair<int, DadosOcorrencia> dados_ocorrencia in lista_dados_ocorrencias)
            {
                lista.Add(dados_ocorrencia.Value);
            }
                
            
        } //btnSort_Click()
    }
}
