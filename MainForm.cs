using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
    public partial class MainForm : Form
    {
        System.Drawing.Size tamanho_mapa_diminuido = new Size(487, 332);
        System.Drawing.Size tamanho_mapa_normal = new Size(759, 332);
        System.Drawing.Point posicao_mapa_direita = new Point(285, 56);
        System.Drawing.Point posicao_mapa_normal = new Point(13, 56);

        private List<DadosOcorrencia> resultado_pesquisa; //armazena os resultados de uma pesquisa

        public MainForm()
        {
            InitializeComponent();
        }

        /*
         * 
         * CONTROLE
         * 
         */

        private void pesquisar()  //pesquisa o que está escrito na caixa de pesquisa
        {
            string localidade = textPesquisar.Text;
            string nome_cidade = localidade;
            if (localidade.Contains(" -"))
            {
                nome_cidade = localidade.Substring(0, localidade.IndexOf(" -"));
            }
                

            resultado_pesquisa = Controlador.pesquisaCidade(nome_cidade);

            limparDadosOcorrencia();

            if (resultado_pesquisa.Count > 0)
            {

                labelCidadesEncontradas.Text = resultado_pesquisa.Count + " cidade(s) encontrada(s).";
                labelSelecioneCidade.Text = "Resultados da busca (\'"+nome_cidade+"\'):";

                string cidade_selecionada = resultado_pesquisa[0].ocorrencia.localidade + " - " +
                                        resultado_pesquisa[0].ocorrencia.uf;
                textPesquisar.Text = cidade_selecionada;
                gmapControl.SetPositionByKeywords(cidade_selecionada);

                preencherDadosOcorrencia(resultado_pesquisa[0]);
            }
            else  // == 0
            {
                localidade = "";

                resultado_pesquisa = Controlador.pesquisaCidade(localidade);

                labelCidadesEncontradas.Text = "\'"+nome_cidade+"\' não foi encontrada.";
                labelSelecioneCidade.Text = "Lista de todas as cidades ("+resultado_pesquisa.Count+"):";
            }

            List<string> lista_cidades = new List<string>();
            foreach (DadosOcorrencia dados_ocorrencia in resultado_pesquisa)
            {
                lista_cidades.Add(dados_ocorrencia.ocorrencia.localidade + " - " +
                                    dados_ocorrencia.ocorrencia.uf + "  (cód. " +
                                    dados_ocorrencia.codigo_ocorrencia + ")");
            } //foreach

            comboSelecioneCidade.DataSource = lista_cidades;

            checkHamburger.Checked = true;
        } //pesquisar()

        private void pesquisar(DadosOcorrencia dado_selecionado) //pesquisa o item selecionado no comboBox
        {
            string cidade_selecionada = dado_selecionado.ocorrencia.localidade + " - " +
                                           dado_selecionado.ocorrencia.uf;
            textPesquisar.Text = cidade_selecionada;
            labelCidadesEncontradas.Text = "\'"+cidade_selecionada+"\' selecionada.";
            preencherDadosOcorrencia(dado_selecionado);
            gmapControl.SetPositionByKeywords(cidade_selecionada);
        }

        private void limparDadosOcorrencia()
        {
            textDadosOcorrencia.Text = "";
        }

        private void preencherDadosOcorrencia(DadosOcorrencia dado_selecionado) //preenche os dados da ocorrência
        {
            textDadosOcorrencia.Text = "";
            if(dado_selecionado.ocorrencia != null)
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
                    "  Horário UTC: " + dado_selecionado.ocorrencia.horario_utc + "\r\n" +
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
            }
            if(dado_selecionado.aeronave != null)
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
            }
            if(dado_selecionado.fator != null)
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
            }
            
        }

        private void setModoHamburger(bool modo) //controle do menu hamburger
        {
            labelSelecioneCidade.Visible = modo;
            labelCidadesEncontradas.Visible = modo;
            comboSelecioneCidade.Visible = modo;
            labelDadosOcorrencia.Visible = modo;
            textDadosOcorrencia.Visible = modo;

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
         * EVENTOS
         * 
         */

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            
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
            
        } //MainForm_Load()

        private void checkHamburger_CheckedChanged(object sender, EventArgs e)
        {
            setModoHamburger(checkHamburger.Checked);
        } // checkHamburger_CheckedChanged()

        private void textPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                checkHamburger.Checked = false;

                e.Handled = e.SuppressKeyPress = true;
            }
            if(e.KeyCode == Keys.Enter)
            {
                pesquisar();

                e.Handled = e.SuppressKeyPress = true;
            }
        } //textPesquisar_KeyDown()

        private void MainForm_Shown(object sender, EventArgs e)
        {
            textPesquisar.Focus();
        }

        private void comboSelecioneCidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pesquisar(resultado_pesquisa[comboSelecioneCidade.SelectedIndex]);
        }
    }//class
} //namespace
