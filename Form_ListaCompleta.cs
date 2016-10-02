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
    public partial class Form_ListaCompleta : Form
    {
        private List<Ocorrencia> lista_ocorrencias = null;
        private List<Aeronave> lista_aeronaves = null;
        private List<FatorContribuinte> lista_fatores = null;

        public Form_ListaCompleta(List<Ocorrencia> ocorrencias)
        {
            InitializeComponent();
            lista_ocorrencias = ocorrencias;
        }

        public Form_ListaCompleta(List<Aeronave> aeronaves)
        {
            InitializeComponent();
            lista_aeronaves = aeronaves;

            

            while (this.gridListaCompleta.Columns.Count > 0)
            {
                this.gridListaCompleta.Columns.RemoveAt(0);
            }

            List<string> lista_colunas = new List<string>();
            lista_colunas.Add("codigo_aeronave");
            lista_colunas.Add("codigo_ocorrencia");
            lista_colunas.Add("matricula");
            lista_colunas.Add("codigo_operador");
            lista_colunas.Add("equipamento");
            lista_colunas.Add("fabricante");
            lista_colunas.Add("modelo");
            lista_colunas.Add("tipo_motor");
            lista_colunas.Add("quantidade_motores");
            lista_colunas.Add("peso_maximo_decolagem");
            lista_colunas.Add("quantidade_assentos");
            lista_colunas.Add("ano_fabricacao");
            lista_colunas.Add("pais_registro");
            lista_colunas.Add("categoria_registro");
            lista_colunas.Add("categoria_aviacao");
            lista_colunas.Add("origem_voo");
            lista_colunas.Add("destino_voo");
            lista_colunas.Add("fase_operacao");
            lista_colunas.Add("tipo_operacao");
            lista_colunas.Add("nivel_dano");
            lista_colunas.Add("quantidade_fatalidades");
            lista_colunas.Add("dia_extracao");

            DataGridViewTextBoxColumn novaColuna;

            foreach (string coluna in lista_colunas)
            {
                novaColuna = new DataGridViewTextBoxColumn
                {
                    HeaderText = coluna
                };
                this.gridListaCompleta.Columns.Add(novaColuna); //1
            } //foreach   

            this.populaDados(lista_aeronaves);

        }//Form_ListaCompleta()

        public Form_ListaCompleta(List<FatorContribuinte> fatores)
        {
            InitializeComponent();
            lista_fatores = fatores;
        }

        public void populaColunas(CsvLinha linha)
        {
            while (this.gridListaCompleta.Columns.Count > 0)
            {
                this.gridListaCompleta.Columns.RemoveAt(0);
            }

            DataGridViewTextBoxColumn novaColuna;

            for(int i = 0; i < linha.Count; i++)
            {
                novaColuna = new DataGridViewTextBoxColumn
                {
                    HeaderText = linha[i]
                };
                this.gridListaCompleta.Columns.Add(novaColuna); //1
            }

            /*
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
            */
        }

        public void populaDados(List<Aeronave> lista_aeronaves)
        {
            for (int i = 0; i < lista_aeronaves.Count; i++)
            {
                this.gridListaCompleta.Rows.Add("" + lista_aeronaves[i].codigo_aeronave,
                                                lista_aeronaves[i].codigo_ocorrencia,
                                                lista_aeronaves[i].matricula,
                                                lista_aeronaves[i].codigo_operador,
                                                lista_aeronaves[i].equipamento,
                                                lista_aeronaves[i].fabricante,
                                                lista_aeronaves[i].modelo,
                                                lista_aeronaves[i].tipo_motor,
                                                lista_aeronaves[i].quantidade_motores,
                                                lista_aeronaves[i].peso_maximo_decolagem,
                                                lista_aeronaves[i].quantidade_assentos,
                                                lista_aeronaves[i].ano_fabricacao,
                                                lista_aeronaves[i].pais_registro,
                                                lista_aeronaves[i].categoria_registro,
                                                lista_aeronaves[i].categoria_aviacao,
                                                lista_aeronaves[i].origem_voo,
                                                lista_aeronaves[i].destino_voo,
                                                lista_aeronaves[i].fase_operacao,
                                                lista_aeronaves[i].tipo_operacao,
                                                lista_aeronaves[i].nivel_dano,
                                                lista_aeronaves[i].quantidade_fatalidades,
                                                lista_aeronaves[i].dia_extracao);
            }
        }

        public void populaDados(List<Ocorrencia> lista_ocorrencias)
        {
            for (int i = 0; i < lista_ocorrencias.Count; i++)
            {
                this.gridListaCompleta.Rows.Add("" + lista_ocorrencias[i].codigo_ocorrencia,
                                                lista_ocorrencias[1].classificacao,
                                                lista_ocorrencias[i].tipo,
                                                lista_ocorrencias[i].localidade,
                                                lista_ocorrencias[i].uf,
                                                lista_ocorrencias[i].pais,
                                                lista_ocorrencias[i].aerodromo,
                                                lista_ocorrencias[i].dia_ocorrencia,
                                                lista_ocorrencias[i].horario_utc,
                                                lista_ocorrencias[i].sera_investigada,
                                                lista_ocorrencias[i].comando_investigador,
                                                lista_ocorrencias[i].status_investigacao,
                                                lista_ocorrencias[i].numero_relatorio,
                                                lista_ocorrencias[i].relatorio_publicado,
                                                lista_ocorrencias[i].dia_publicacao,
                                                lista_ocorrencias[i].quantidade_recomendacoes,
                                                lista_ocorrencias[i].aeronaves_envolvidas,
                                                lista_ocorrencias[i].saida_pista,
                                                lista_ocorrencias[i].dia_extracao);
            }
        }

        public void populaDados(List<FatorContribuinte> lista_fatores)
        {
            for (int i = 0; i < lista_fatores.Count; i++)
            {
                this.gridListaCompleta.Rows.Add("" + lista_fatores[i].codigo_fator,
                                                lista_fatores[1].codigo_ocorrencia,
                                                lista_fatores[i].fator,
                                                lista_fatores[i].aspecto,
                                                lista_fatores[i].condicionante,
                                                lista_fatores[i].area,
                                                //lista_fatores[i].nivel_contribuicao,
                                                lista_fatores[i].detalhe_fator,
                                                lista_fatores[i].dia_extracao);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(lista_aeronaves != null)
            {
                Form_Sort form_sort = new Form_Sort(lista_aeronaves);
                form_sort.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sort funciona apenas com aeronaves, por enquanto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //btnSort_Click()
    }
}
