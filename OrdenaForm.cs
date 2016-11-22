using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Form que possui opções para ordenar a lista de ocorrências e fazer benchmarks.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class OrdenaForm : Form
    {
        /* 
         * 
         * Variáveis globais
         * 
         *  */

        /// <summary>
        /// Lista de ocorrências completa (desordenada)
        /// </summary>
        private List<DadosOcorrencia> lista_dados_ocorrencias = null;
        /// <summary>
        /// Lista de ocorrências depois da ordenação
        /// </summary>
        private List<DadosOcorrencia> lista_ordenada = null;

        /* 
         * 
         * Construtor
         * 
         *  */

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdenaForm"/> class.
        /// </summary>
        /// <param name="lista_dados_ocorrencias">Lista de ocorrências a ser ordenada.</param>
        public OrdenaForm(List<DadosOcorrencia> lista_dados_ocorrencias)
        {
            InitializeComponent();

            this.lista_dados_ocorrencias = lista_dados_ocorrencias;
        }

        /* 
         * 
         * Métodos de ordenação e controle dos elementos visuais.
         * 
         *  */

        private void ordenar()
        {
            if (comboAlgoritmo.Text.Equals("Bubble Sort (BBST)")) //Bubble Sort
            {
                if (comboCampo.Text.Equals("codigo_ocorrencia"))
                {
                    Stopwatch sw = new Stopwatch();

                    List<DadosOcorrencia> lista_ordenada;

                    sw.Start();
                    lista_ordenada = OrdenaDados.bubbleSort_codigo_ocorrencia(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Bubble Sort (BBST)", lista_ordenada.Count, "codigo_ocorrencia", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }//if
                if (comboCampo.Text.Equals("localidade"))
                {
                    Stopwatch sw = new Stopwatch();

                    List<DadosOcorrencia> lista_ordenada;

                    sw.Start();
                    lista_ordenada = OrdenaDados.bubbleSort_localidade(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Bubble Sort (BBST)", lista_ordenada.Count, "localidade", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
            }//if
            if (comboAlgoritmo.Text.Equals("Insertion Sort com Busca Linear (ISBL)")) //Insertion Sort
            {
                if (comboCampo.Text.Equals("codigo_ocorrencia"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.insertionSort_codigo_ocorrencia(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Insertion Sort com Busca Linear (ISBL)", lista_ordenada.Count, "codigo_ocorrencia", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
                if (comboCampo.Text.Equals("localidade"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.insertionSort_localidade(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Insertion Sort com Busca Linear (ISBL)", lista_ordenada.Count, "localidade", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
            } //if
            if (comboAlgoritmo.Text.Equals("Quick Sort Randomizado (QSRM)")) //Quick Sort
            {
                if (comboCampo.Text.Equals("codigo_ocorrencia"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.QSRM_Ocorrencia(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Quick Sort Randomizado (QSRM)", lista_ordenada.Count, "codigo_ocorrencia", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
                if (comboCampo.Text.Equals("localidade"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.QSRM_Localizacao(this.lista_dados_ocorrencias, (!checkDecrescente.Checked));
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Quick Sort Randomizado (QSRM)", lista_ordenada.Count, "localidade", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                } //if
            }//if
            if (comboAlgoritmo.Text.Equals("Shell Sort (SHST)")) //Shell sort (apenas decrescente)
            {
                if (comboCampo.Text.Equals("codigo_ocorrencia"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.ShellSort_codigo_ocorrencia(this.lista_dados_ocorrencias);
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Shell Sort (SHST)", lista_ordenada.Count, "codigo_ocorrencia", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
                if (comboCampo.Text.Equals("localidade"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.ShellSort_localidade(this.lista_dados_ocorrencias);
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Shell Sort (SHST)", lista_ordenada.Count, "localidade", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                } //if
            }
            if (comboAlgoritmo.Text.Equals("Heap Sort (HPST)")) //Heap Sort (apenas decrescente)
            {
                if (comboCampo.Text.Equals("codigo_ocorrencia"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.HeapsortOcorrencia(this.lista_dados_ocorrencias);
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Heap Sort (HPST)", lista_ordenada.Count, "codigo_ocorrencia", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                }
                if (comboCampo.Text.Equals("localidade"))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    List<DadosOcorrencia> lista_ordenada = OrdenaDados.HeapsortLocalizacao(this.lista_dados_ocorrencias);
                    sw.Stop();

                    this.lista_ordenada = lista_ordenada;

                    Console.WriteLine("time: " + sw.Elapsed);

                    preencherTempoExecucao("Heap Sort (HPST)", lista_ordenada.Count, "localidade", checkDecrescente.Checked, sw.ElapsedMilliseconds);
                    preencherGridListaOcorrencias(lista_ordenada);
                } //if
            }//if
        } //ordenar()

        /// <summary>
        /// Retorna o horário atual em um formato legível.
        /// </summary>
        /// <returns></returns>
        private string horarioAtual()
        {
            return DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }

        /// <summary>
        /// Adiciona os resultados da ordenação nos benchmarks.
        /// </summary>
        /// <param name="algoritmo">The algoritmo.</param>
        /// <param name="qtde_registros">The qtde registros.</param>
        /// <param name="campo">The campo.</param>
        /// <param name="decrescente">if set to <c>true</c> [decrescente].</param>
        /// <param name="tempo_em_ms">The tempo em ms.</param>
        private void preencherTempoExecucao(string algoritmo, int qtde_registros, string campo, bool decrescente, long tempo_em_ms)
        {
            textTempoExecucao.Text += "Horário " + horarioAtual() + " - " + algoritmo + ":\r\n";
            textTempoExecucao.Text += " Qtde registros ordenados: " + qtde_registros + "\r\n";
            string ordem;
            if (decrescente)
                ordem = "decrescente";
            else
                ordem = "crescente";
            textTempoExecucao.Text += " Campo ordenado: " + campo + "  (" + ordem + ")\r\n";
            textTempoExecucao.Text += " Tempo de execução do algoritmo: " + tempo_em_ms + " ms\r\n";
            textTempoExecucao.Text += "------------------------------------------------------------------------------------\r\n";
        }

        /// <summary>
        /// Preenche o Grid de ocorrências com uma lista de ocorrências.
        /// </summary>
        /// <param name="lista_dados_ocorrencias">The lista dados ocorrencias.</param>
        private void preencherGridListaOcorrencias(List<DadosOcorrencia> lista_dados_ocorrencias)
        {
            while (this.gridDados.Columns.Count > 0)
            {
                this.gridDados.Columns.RemoveAt(0);
            }

            if (lista_dados_ocorrencias.Count > 0)
            {
                DataGridViewTextBoxColumn novaColuna;

                List<string> colunas = new List<string>();
                colunas.Add("codigo_ocorrencia");
                colunas.Add("localidade");
                colunas.Add("uf");
                colunas.Add("dia_ocorrencia");

                for (int i = 0; i < colunas.Count; i++)
                {
                    novaColuna = new DataGridViewTextBoxColumn
                    {
                        SortMode = DataGridViewColumnSortMode.NotSortable,
                        HeaderText = colunas[i]
                    };
                    this.gridDados.Columns.Add(novaColuna); //1
                }//for

                foreach (DadosOcorrencia dados_ocorrencia in lista_dados_ocorrencias)
                {
                    int codigo_ocorrencia = dados_ocorrencia.codigo_ocorrencia;
                    Ocorrencia ocorrencia = dados_ocorrencia.ocorrencia;

                    //colunas
                    string localidade = "";
                    string uf = "";
                    string dia_ocorrencia = "";


                    if (ocorrencia != null)
                    {
                        dia_ocorrencia = ocorrencia.dia_ocorrencia;
                        localidade = ocorrencia.localidade;
                        uf = ocorrencia.uf;
                    }

                    this.gridDados.Rows.Add("" + codigo_ocorrencia,
                                                       localidade,
                                                       uf,
                                                       dia_ocorrencia);
                }//foreach        
                this.gridDados.Rows[0].Selected = true;
            }//if
        } //preencherGridListaOcorrencias(List<DadosOcorrencia> lista_dados_ocorrencias)

        /// <summary>
        /// Preenche os dados da ocorrência selecionada no Grid.
        /// </summary>
        /// <param name="dado_selecionado">The dado selecionado.</param>
        private void preencherDadosOcorrenciaSelecionada(DadosOcorrencia dado_selecionado)
        {
            if (dado_selecionado.ocorrencia != null)
            {
                textDadoSelecionado.Text = "Ocorrência:\r\n\r\n";
                textDadoSelecionado.Text +=
                    "  Código: " + dado_selecionado.codigo_ocorrencia + "\r\n" +
                    "  Classificação: " + dado_selecionado.ocorrencia.classificacao + "\r\n" +
                    "  Tipo: " + dado_selecionado.ocorrencia.tipo + "\r\n" +
                    "  Localidade: " + dado_selecionado.ocorrencia.localidade + "\r\n" +
                    "  UF: " + dado_selecionado.ocorrencia.uf + "\r\n" +
                    "  País: " + dado_selecionado.ocorrencia.pais + "\r\n" +
                    "  Aerodromo: " + dado_selecionado.ocorrencia.aerodromo + "\r\n" +
                    "  Dia ocorrência: " + dado_selecionado.ocorrencia.dia_ocorrencia + "\r\n" +
                    "  Horário UTC: " + dado_selecionado.ocorrencia.horario + "\r\n" +
                    "  Será investigada: " + dado_selecionado.ocorrencia.sera_investigada + "\r\n" +
                    "  Comando investigador: " + dado_selecionado.ocorrencia.comando_investigador + "\r\n" +
                    "  Status investigação: " + dado_selecionado.ocorrencia.status_investigacao + "\r\n" +
                    "  Número relatório: " + dado_selecionado.ocorrencia.numero_relatorio + "\r\n" +
                    "  Relatório publicado: " + dado_selecionado.ocorrencia.relatorio_publicado + "\r\n" +
                    "  Dia publicação: " + dado_selecionado.ocorrencia.dia_publicacao + "\r\n" +
                    "  Quantidade de recomendações: " + dado_selecionado.ocorrencia.quantidade_recomendacoes + "\r\n" +
                    "  Aeronaves envolvidas: " + dado_selecionado.ocorrencia.aeronaves_envolvidas + "\r\n" +
                    "  Saída pista: " + dado_selecionado.ocorrencia.saida_pista + "\r\n" +
                    "  Dia extração: " + dado_selecionado.ocorrencia.dia_extracao + "\r\n";
            } //if
            if (dado_selecionado.aeronave != null)
            {
                textDadoSelecionado.Text += "\r\n\r\n";
                textDadoSelecionado.Text += "Aeronave:\r\n\r\n";
                textDadoSelecionado.Text +=
                    "  Código da aeronave: " + dado_selecionado.aeronave.codigo_aeronave + "\r\n" +
                    "  Matrícula: " + dado_selecionado.aeronave.matricula + "\r\n" +
                    "  Código do operador: " + dado_selecionado.aeronave.codigo_operador + "\r\n" +
                    "  Equipamento: " + dado_selecionado.aeronave.equipamento + "\r\n" +
                    "  Fabricante: " + dado_selecionado.aeronave.fabricante + "\r\n" +
                    "  Modelo: " + dado_selecionado.aeronave.modelo + "\r\n" +
                    "  Tipo motor: " + dado_selecionado.aeronave.tipo_motor + "\r\n" +
                    "  Quantidade motores: " + dado_selecionado.aeronave.quantidade_motores + "\r\n" +
                    "  Peso máximo decolagem: " + dado_selecionado.aeronave.peso_maximo_decolagem + "\r\n" +
                    "  Quantidade de assentos: " + dado_selecionado.aeronave.quantidade_assentos + "\r\n" +
                    "  Ano de fabricação: " + dado_selecionado.aeronave.ano_fabricacao + "\r\n" +
                    "  País de registro: " + dado_selecionado.aeronave.pais_registro + "\r\n" +
                    "  Categoria registro: " + dado_selecionado.aeronave.categoria_registro + "\r\n" +
                    "  Categoria aviação: " + dado_selecionado.aeronave.categoria_aviacao + "\r\n" +
                    "  Origem voo: " + dado_selecionado.aeronave.origem_voo + "\r\n" +
                    "  Destino voo: " + dado_selecionado.aeronave.destino_voo + "\r\n" +
                    "  Fase operação: " + dado_selecionado.aeronave.fase_operacao + "\r\n" +
                    "  Tipo operação: " + dado_selecionado.aeronave.tipo_operacao + "\r\n" +
                    "  Nível de dano: " + dado_selecionado.aeronave.nivel_dano + "\r\n" +
                    "  Quantidade de fatalidades: " + dado_selecionado.aeronave.quantidade_fatalidades + "\r\n" +
                    "  Dia de extração: " + dado_selecionado.aeronave.dia_extracao + "\r\n";
            } //if
            if (dado_selecionado.fator != null)
            {
                textDadoSelecionado.Text += "\r\n\r\n";
                textDadoSelecionado.Text += "Fator contribuinte: \r\n\r\n";
                textDadoSelecionado.Text +=
                    "  Código do fator: " + dado_selecionado.fator.codigo_fator + "\r\n" +
                    "  Aspecto: " + dado_selecionado.fator.aspecto + "\r\n" +
                    "  Condicionante: " + dado_selecionado.fator.condicionante + "\r\n" +
                    "  Área: " + dado_selecionado.fator.area + "\r\n" +
                    //" Nível de contribuição: " + dado_selecionado.fator. + "\r\n" +
                    "  Detalhe fator: " + dado_selecionado.fator.detalhe_fator + "\r\n" +
                    "  Dia extração: " + dado_selecionado.fator.dia_extracao;
            } //if
        }

        private void salvarBenchmarks()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Write the string to a file.
                    System.IO.StreamWriter arquivo_output = new System.IO.StreamWriter(saveFileDialog.FileName);
                    arquivo_output.Write(textTempoExecucao.Text);

                    arquivo_output.Close();

                    MessageBox.Show("Benchmarks salvos com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Erro ao salvar Benchmarks", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /* 
         * 
         * Eventos (ações da UI)
         * 
         *  */

        private void OrdenaForm_Shown(object sender, EventArgs e)
        {
            comboAlgoritmo.SelectedIndex = 0;
            comboCampo.SelectedIndex = 0;
        } //OrdenaForm_Shown(object sender, EventArgs e)

        private void OrdenaForm_Load(object sender, EventArgs e)
        {
            preencherGridListaOcorrencias(this.lista_dados_ocorrencias);
            preencherDadosOcorrenciaSelecionada(this.lista_dados_ocorrencias[0]);
        } //OrdenaForm_Load(object sender, EventArgs e)

        /// <summary>
        /// Handles the Click event of the btnOrdenar control.
        /// Realiza a ordenação e atualiza os benchmarks.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            ordenar();
        }//btnOrdenar_Click(object sender, EventArgs e)

        /// <summary>
        /// Handles the SelectionChanged event of the gridDados control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridDados_SelectionChanged(object sender, EventArgs e)
        {
            if(lista_ordenada != null)
            {
                if (gridDados.CurrentCell != null)
                    preencherDadosOcorrenciaSelecionada(lista_ordenada.ElementAt(gridDados.CurrentCell.RowIndex));
            }
            else
            {
                if(lista_dados_ocorrencias != null)
                    if (gridDados.CurrentCell != null)
                        preencherDadosOcorrenciaSelecionada(lista_dados_ocorrencias.ElementAt(gridDados.CurrentCell.RowIndex));
            }
                
        } //gridDados_SelectionChanged(object sender, EventArgs e)

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvarBenchmarks();
        } //btnSalvar_Click(object sender, EventArgs e)

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboAlgoritmo control.
        /// Alguns algoritmos só possuem ordem decrescente.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAlgoritmo.Text.Equals("Heap Sort (HPST)"))
            {
                checkDecrescente.Checked = true;
                checkDecrescente.Enabled = false;
            }
            else if (comboAlgoritmo.Text.Equals("Shell Sort (SHST)"))
            {
                checkDecrescente.Checked = true;
                checkDecrescente.Enabled = false;
            }
            else
            {
                checkDecrescente.Checked = false;
                checkDecrescente.Enabled = true;
            }
        } //comboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
    } //class
}//namespace
