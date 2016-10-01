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
    public partial class ListaCompleta : Form
    {
        private List<Ocorrencia> lista_ocorrencias;

        public ListaCompleta(List<Ocorrencia> ocorrencias)
        {
            InitializeComponent();

            lista_ocorrencias = ocorrencias;
        }

        private void ListaCompleta_Load(object sender, EventArgs e)
        {
            while (this.gridListaCompleta.Columns.Count > 0)
            {
                this.gridListaCompleta.Columns.RemoveAt(0);
            }
            var novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "codigo_ocorrencia"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //1

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "classificacao"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //2

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "tipo"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //3

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "localidade"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //4

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "uf"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //5

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "pais"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //6

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "aerodromo"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //7

            novaColuna = new DataGridViewTextBoxColumn
            {
                HeaderText = "dia_ocorrencia"

            };
            this.gridListaCompleta.Columns.Add(novaColuna); //8



            //falta: horario,sera_investigada,comando_investigador,status_investigacao,numero_relatorio,relatorio_publicado,dia_publicacao,quantidade_recomendacoes,aeronaves_envolvidas,saida_pista,dia_extracao

            /* LINHAS */

            for(int i = 0; i < lista_ocorrencias.Count; i++)
            {
                //8 parametros por enquanto
                this.gridListaCompleta.Rows.Add(""+lista_ocorrencias[i].codigo_ocorrencia,
                                                    lista_ocorrencias[i].classificacao,
                                                    lista_ocorrencias[i].tipo,
                                                    lista_ocorrencias[i].localidade,
                                                    lista_ocorrencias[i].uf,
                                                    lista_ocorrencias[i].pais,
                                                    lista_ocorrencias[i].aerodromo,
                                                    lista_ocorrencias[i].dia_ocorrencia);

            }

            
        }

        private void ListaCompleta_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
