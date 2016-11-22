using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Form principal do programa
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {

        /* 
         * 
         * Variáveis globais
         * 
         *  */

        System.Drawing.Size tamanho_mapa_diminuido = new Size(487, 332);
        System.Drawing.Size tamanho_mapa_normal = new Size(759, 332);
        System.Drawing.Point posicao_mapa_direita = new Point(285, 56);
        System.Drawing.Point posicao_mapa_normal = new Point(13, 56);

        /// <summary>
        /// Lista que contem as cidades obtidas na pesquisa.
        /// A classe "Cidade" está definida no fim deste arquivo.
        /// </summary>
        private List<Cidade> resultados_pesquisa; //armazena os resultados de uma pesquisa (organizado por cidade)
        /// <summary>
        /// Lista de dados ocorrencia obtida na pesquisa.
        /// </summary>
        private List<DadosOcorrencia> lista_dados_ocorrencia_resultados_pesquisa; //armazena todos os resultados da pesquisa

        /* 
         * 
         * Construtor
         * 
         *  */

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /*
         * 
         * Métodos de pesquisa e controle dos elementos visuais
         * 
         */

        /// <summary>
        /// Pesquisa (na árvore que está no disco) o que está na caixa de pesquisa.
        /// </summary>
        private void pesquisar()  //pesquisa o que está escrito na caixa de pesquisa
        {
            /* obtem o nome da cidade a ser pesquisada */
            string localidade = textPesquisar.Text;
            string nome_cidade = localidade;
            if (localidade.Contains(" -"))
            {
                nome_cidade = localidade.Substring(0, localidade.IndexOf(" -")); //pega apenas o nome da cidade
            }

            bool encontrou_cidade = false;

            List<DadosOcorrencia> resultados = Controlador.pesquisaCidade(nome_cidade);

            //limpa o textbox que tem os dados da ocorrencia
            limparDadosOcorrencia();

            if (resultados.Count > 0) //retornou mais que 1 cidade
            {
                encontrou_cidade = true;
                resultados = OrdenaDados.insertionSort_localidade(resultados, true);// INSERTION SORT ??

                //formata o nome para CIDADE - ESTADO
                string cidade_selecionada = resultados[0].ocorrencia.localidade + " - " +
                                        resultados[0].ocorrencia.uf;

                //busca no mapa
                gmapControl.SetPositionByKeywords(cidade_selecionada);

                textPesquisar.Text = cidade_selecionada;
            }
            else  // == 0
            {
                //filtro para mostrar todas
                localidade = "";

                //busca todas
                resultados = Controlador.pesquisaCidade(localidade);
                resultados = OrdenaDados.insertionSort_localidade(resultados, true); // INSERTION SORT ??


            }

            /* cria uma lista de cidades sem repetição, e adiciona as ocorrências de cada cidade na devida cidade */
            List<Cidade> lista_cidades = new List<Cidade>();
            foreach (DadosOcorrencia dados_ocorrencia in resultados)
            {
                bool existe_na_lista = false;
                for (int i = 0; i < lista_cidades.Count; i++)
                {
                    if (lista_cidades.ElementAt(i).localidade == dados_ocorrencia.ocorrencia.localidade)
                    {
                        if (lista_cidades.ElementAt(i).uf == dados_ocorrencia.ocorrencia.uf)
                        {
                            existe_na_lista = true;
                            lista_cidades.ElementAt(i).lista_ocorrencias.Add(dados_ocorrencia);
                            break;
                        }//if
                    }//if
                }//for
                if (!existe_na_lista)
                {
                    lista_cidades.Add(new Cidade(dados_ocorrencia.ocorrencia.localidade, dados_ocorrencia.ocorrencia.uf, dados_ocorrencia));
                }//if
            }//foreach

            /* preenche combobox de cidades, e ordena (ordem crescente) a lista de ocorrencias de cada cidade */
            List<string> lista_cidades_combobox = new List<string>();
            foreach (Cidade cidade in lista_cidades)
            {
                lista_cidades_combobox.Add(cidade.localidade + " - " + cidade.uf);
                cidade.lista_ocorrencias = OrdenaDados.insertionSort_codigo_ocorrencia(cidade.lista_ocorrencias, true); // INSERTION SORT ??
            } //foreach

            //preenche os dados no textbox
            preencherDadosOcorrencia(lista_cidades[0].lista_ocorrencias[0]);

            comboSelecioneCidade.DataSource = lista_cidades_combobox;

            /* preenche combobox de ocorrencias da cidade na posição 0*/
            List<int> lista_codigo_ocorrencias = new List<int>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_cidades[0].lista_ocorrencias)
            {
                lista_codigo_ocorrencias.Add(dados_ocorrencia.codigo_ocorrencia);
            }
            comboOcorrencias.DataSource = lista_codigo_ocorrencias;

            resultados_pesquisa = lista_cidades;

            if (encontrou_cidade)
            {
                labelCidadesEncontradas.Text = lista_cidades.Count + " cidade(s) encontrada(s).";
                labelSelecioneCidade.Text = "Resultados da busca (\'" + nome_cidade + "\'):";
            }
            else
            {
                //atualiza labels
                labelCidadesEncontradas.Text = "\'" + nome_cidade + "\' não foi encontrada.";
                labelSelecioneCidade.Text = "Lista de todas as cidades (" + resultados.Count + "):";
            }

            this.lista_dados_ocorrencia_resultados_pesquisa = resultados;

            //ativa o menu hamburger
            checkHamburger.Checked = true;
        } //pesquisar()

        /// <summary>
        /// Mostra os dados da ocorrência selecionada da lista de ocorrências da cidade.
        /// </summary>
        /// <param name="ocorrencia_selecionada">A ocorrencia selecionada.</param>
        private void ocorrenciaSelecionada(DadosOcorrencia ocorrencia_selecionada) //mostra a ocorrência selecionada no comboBox
        {
            //preenche o textbox com os dados da ocorrencia selecionada
            preencherDadosOcorrencia(ocorrencia_selecionada);
        } // pesquisar(DadosOcorrencia dado_selecionado)

        /// <summary>
        /// Pesquisa no mapa a cidade selecionada, e mostra a lista de ocorrências da cidade.
        /// </summary>
        /// <param name="cidade_selecionada">The cidade selecionada.</param>
        private void cidadeSelecionada(Cidade cidade_selecionada) //pesquisa a cidade selecionada no ComboBox
        {
            //formata para CIDADE - ESTADO
            string cidade = cidade_selecionada.localidade + " - " + cidade_selecionada.uf;


            //busca no mapa
            gmapControl.SetPositionByKeywords(cidade);

            //preenche o textbox com os dados da ocorrencia na primeira posição
            preencherDadosOcorrencia(cidade_selecionada.lista_ocorrencias[0]);

            //atualiza labels
            textPesquisar.Text = cidade;
            labelCidadesEncontradas.Text = "\'" + cidade + "\' selecionada.";

            /* preenche combobox de ocorrencias da cidade selecionada */
            List<int> lista_codigo_ocorrencias = new List<int>();
            foreach (DadosOcorrencia dados_ocorrencia in cidade_selecionada.lista_ocorrencias)
            {
                lista_codigo_ocorrencias.Add(dados_ocorrencia.codigo_ocorrencia);
            }
            comboOcorrencias.DataSource = lista_codigo_ocorrencias;
        }//cidadeSelecionada(Cidade cidade_selecionada)

        /// <summary>
        /// Limpa o texto que contém as informações da ocorrência selecionada.
        /// </summary>
        private void limparDadosOcorrencia() //limpa o textbox com os dados da ocorrencia selecionada
        {
            textDadosOcorrencia.Text = "";
        } //limparDadosOcorrencia()

        /// <summary>
        /// Preenche o texto com as informações da ocorrência selecionada.
        /// </summary>
        /// <param name="dado_selecionado">A ocorrencia selecionada.</param>
        private void preencherDadosOcorrencia(DadosOcorrencia dado_selecionado) //preenche os dados da ocorrência
        {
            textDadosOcorrencia.Text = "";
            if (dado_selecionado.ocorrencia != null)
            {
                textDadosOcorrencia.Text = "Ocorrência:\r\n\r\n";
                textDadosOcorrencia.Text +=
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
                textDadosOcorrencia.Text += "\r\n\r\n";
                textDadosOcorrencia.Text += "Aeronave:\r\n\r\n";
                textDadosOcorrencia.Text +=
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
                textDadosOcorrencia.Text += "\r\n\r\n";
                textDadosOcorrencia.Text += "Fator contribuinte: \r\n\r\n";
                textDadosOcorrencia.Text +=
                    "  Código do fator: " + dado_selecionado.fator.codigo_fator + "\r\n" +
                    "  Aspecto: " + dado_selecionado.fator.aspecto + "\r\n" +
                    "  Condicionante: " + dado_selecionado.fator.condicionante + "\r\n" +
                    "  Área: " + dado_selecionado.fator.area + "\r\n" +
                    //" Nível de contribuição: " + dado_selecionado.fator. + "\r\n" +
                    "  Detalhe fator: " + dado_selecionado.fator.detalhe_fator + "\r\n" +
                    "  Dia extração: " + dado_selecionado.fator.dia_extracao;
            } //if

        } // preencherDadosOcorrencia()

        /// <summary>
        /// Atualiza os elementos visuais quando o botão hamburger é ativado/desativado
        /// </summary>
        /// <param name="modo">ativado/desativado</param>
        private void setModoHamburger(bool modo) //controle do menu hamburger
        {
            /* visibilidade dos componentes */
            labelSelecioneCidade.Visible = modo;
            labelCidadesEncontradas.Visible = modo;
            comboSelecioneCidade.Visible = modo;
            labelDadosOcorrencia.Visible = modo;
            textDadosOcorrencia.Visible = modo;
            labelOcorrencias.Visible = modo;
            comboOcorrencias.Visible = modo;
            btnOrdenar.Visible = modo;

            /* ajusta tamanho do mapa */
            if (modo == true)
            {
                gmapControl.Size = tamanho_mapa_diminuido;
                gmapControl.Location = posicao_mapa_direita;

                checkHamburger.Checked = true;

                textPesquisar.SelectAll();
                textPesquisar.Focus();
            }
            else
            {
                gmapControl.Size = tamanho_mapa_normal;
                gmapControl.Location = posicao_mapa_normal;

                checkHamburger.Checked = false;

                textPesquisar.SelectAll();
                textPesquisar.Focus();
            }
        } //setModoHamburger()


        /*
         * 
         * EVENTOS ( ações da UI )
         * 
         */

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            //TODO Implementar botão de configuração
        }

        private void gmapControl_Load(object sender, EventArgs e)
        {
            //Setup inicial feito no evento OnLoad do componente de mapas

            gmapControl.DisableFocusOnMouseEnter = true;
            gmapControl.MapProvider = GoogleMapProvider.Instance;              //Utilizando Google Maps como provider
            GMaps.Instance.Mode = AccessMode.ServerOnly;                //Configurado para não criar cache, usar sempre informações do servidor
            gmapControl.SetPositionByKeywords("Porto Alegre, Brazil");       //Posição por palavras chave
            //gmapControl.Position = new PointLatLng(-30.0364242, -51.2191413);  //Posição por coordenadas
            gmapControl.ShowCenter = false;                                    //Remove a cruz que indica o centro do mapa

            //Inserção de um marcador de local
            /*
            GMapOverlay markers = new GMapOverlay("markers");           //Overlay é uma camada onde colocamos marcadores e rotas
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(-30.0364242, -51.2191413),
                GMarkerGoogleType.red_small);                           //Configurado marcador por coordenada
            markers.Markers.Add(marker);                                //Adicionado o marcador ao overlay
            gmapControl.Overlays.Add(markers);                                 //Adicionado overlay ao mapa
            */
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string caminho_pasta = AppDomain.CurrentDomain.BaseDirectory;
            if (!caminho_pasta.EndsWith("\\"))
                caminho_pasta += "\\";
            caminho_pasta += "..\\..\\data\\";

            try
            {
                Controlador.carregarDados(caminho_pasta);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } //catch
        } //MainForm_Load()

        /// <summary>
        /// Handles the CheckedChanged event of the checkHamburger control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkHamburger_CheckedChanged(object sender, EventArgs e)
        {
            setModoHamburger(checkHamburger.Checked);
        } // checkHamburger_CheckedChanged()

        /// <summary>
        /// Handles the KeyDown event of the textPesquisar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void textPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // ESC -> fecha menu hamburger
            {
                checkHamburger.Checked = false;

                e.Handled = e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter) // ENTER -> pesquisa o que está na caixa de texto
            {
                pesquisar();

                e.Handled = e.SuppressKeyPress = true;
            }
        } //textPesquisar_KeyDown()

        private void MainForm_Shown(object sender, EventArgs e)
        {
            textPesquisar.Focus();
        }

        /// <summary>
        /// Handles the SelectionChangeCommitted event of the comboSelecioneCidade control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboSelecioneCidade_SelectionChangeCommitted(object sender, EventArgs e) //selecionou cidade da lista
        {
            cidadeSelecionada(resultados_pesquisa[comboSelecioneCidade.SelectedIndex]); //pesquisa a cidade selecionada
        }

        private void comboOcorrencias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ocorrenciaSelecionada(resultados_pesquisa[comboSelecioneCidade.SelectedIndex]
                    .lista_ocorrencias[comboOcorrencias.SelectedIndex]); //mostra a ocorrência selecionada
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.lista_dados_ocorrencia_resultados_pesquisa != null)
                (new OrdenaForm(this.lista_dados_ocorrencia_resultados_pesquisa)).ShowDialog();
            else
                MessageBox.Show("A lista não pode estar vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aerosafe - Estatísticas de ocorrências aeronáuticas no Brasil\r\n\r\n"+
                "Membros: \r\n"+
                " Jefferson Guimarães\r\n"+
                " Vinícius Soares\r\n"+
                " Yuri Escalianti\r\n\r\n"+
                "Classificação e Pesquisa de Dados - Orientador: Leandro Krug Wives\r\n" +
                "Instituto de Informática - UFRGS\r\n" +
                "2016"+
                "", "Sobre", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }//class

    /// <summary>
    /// Classe para armazenar a lista de ocorrências de uma cidade
    /// </summary>
    class Cidade
    {
        public string localidade { set; get; }
        public string uf { set; get;  }
        public List<DadosOcorrencia> lista_ocorrencias { set; get; }

        public Cidade(string localidade, string uf, DadosOcorrencia dados_ocorrencia)
        {
            this.lista_ocorrencias = new List<DadosOcorrencia>();
            this.lista_ocorrencias.Add(dados_ocorrencia);
            this.localidade = localidade;
            this.uf = uf;
        }
    }
} //namespace
