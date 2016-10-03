using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

//Namespaces do GMap.NET

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Form principal do programa
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de load do componente GMaps.NET, ferramenta usada para exibição de mapas no programa, que é usado para fazer a configuração inicial do mapa.
        /// </summary>
        /// <param name="sender">Origem do evento</param>
        /// <param name="e">Instância <see cref="EventArgs"/> que contém as informações do evento</param>
        private void Gmap_Load(object sender, EventArgs e)
        {
            //Setup inicial feito no evento OnLoad do componente de mapas

            Gmap.MapProvider = GoogleMapProvider.Instance;              //Utilizando Google Maps como provider
            GMaps.Instance.Mode = AccessMode.ServerOnly;                //Configurado para não criar cache, usar sempre informações do servidor
            //Gmap.SetPositionByKeywords("Porto Alegre, Brazil");       //Posição por palavras chave
            Gmap.Position = new PointLatLng(-30.0364242, -51.2191413);  //Posição por coordenadas
            Gmap.ShowCenter = false;                                    //Remove a cruz que indica o centro do mapa

            //Inserção de um marcador de local

            GMapOverlay markers = new GMapOverlay("markers");           //Overlay é uma camada onde colocamos marcadores e rotas
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(-30.0364242, -51.2191413),
                GMarkerGoogleType.red_small);                           //Configurado marcador por coordenada
            markers.Markers.Add(marker);                                //Adicionado o marcador ao overlay
            Gmap.Overlays.Add(markers);                                 //Adicionado overlay ao mapa
        }

        private void btnBrowseAeronaves_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textAeronaves.Text = openFileDialog1.FileName;
            }
        }//browseBtn Click

        /// <summary>
        /// OnClick do botão de leitura do arquivo selecionado
        /// </summary>
        /// <param name="sender">Origem do evento</param>
        /// <param name="e">Instância <see cref="EventArgs"/> que contém as informações do evento</param>
        private void goBtn_Click(object sender, EventArgs e)
        {
            CsvLeitura leitor;
            CsvLinha linha = new CsvLinha();
            //bool leu_linha = false;
            //bool continuar = true;
            int linha_atual = 1;
            List<Aeronave> aeronaves = new List<Aeronave>();
            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();
            List<FatorContribuinte> fatores = new List<FatorContribuinte>();

            Dictionary<int, DadosOcorrencia> dados_ocorrencias = new Dictionary<int, DadosOcorrencia>();

            if(textAeronaves.Text.Trim() == "")
            {
                outputBox.Text = "Selecione um arquivo CSV.";
                return;
            }

            

            outputBox.Text = "Populando classes...\r\n";

            Stopwatch sw = new Stopwatch();

            sw.Start();

            if (textAeronaves.Text.EndsWith(".csv") && textOcorrencias.Text.EndsWith(".csv") 
                && textFatorContribuinte.Text.EndsWith(".csv"))
            {
                //aeronaves
                leitor = new CsvLeitura(textAeronaves.Text);
                leitor.LeLinha(linha); //pula a linha de colunas

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 22)
                    {
                        MessageBox.Show("Aeronaves: Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Aeronave aeronave = new Aeronave();
                        aeronave.fromCSV(linha);
                        aeronaves.Add(aeronave);
                        ++linha_atual;
                    }
                }

                outputBox.Text += "Aeronaves lidas. Qtde: "+linha_atual+"\r\n";
                leitor.Close();

                //ocorrencias
                leitor = new CsvLeitura(textOcorrencias.Text);
                leitor.LeLinha(linha); //pula a linha de colunas

                linha_atual = 1;

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 19)
                    {
                        MessageBox.Show("Ocorrencias: Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Ocorrencia ocorrencia = new Ocorrencia();
                        ocorrencia.fromCSV(linha);
                        ocorrencias.Add(ocorrencia);
                        ++linha_atual;
                    }
                }

                outputBox.Text += "Ocorrencias lidas. Qtde: " + linha_atual + "\r\n";
                leitor.Close();

                //fatores
                leitor = new CsvLeitura(textFatorContribuinte.Text);
                leitor.LeLinha(linha); //pula a linha de colunas

                linha_atual = 1;

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 8)
                    {
                        MessageBox.Show("Fatores Contrib: Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FatorContribuinte fator = new FatorContribuinte();
                        fator.fromCSV(linha);
                        fatores.Add(fator);
                        ++linha_atual;
                    }
                }

                outputBox.Text += "Fatores contribuintes lidos. Qtde: " + linha_atual + "\r\n";
                leitor.Close();

                DadosOcorrencia dado_existente;

                //unificação em um Dicionário

                foreach (Aeronave aeronave in aeronaves)
                {
                    if (dados_ocorrencias.TryGetValue(aeronave.codigo_ocorrencia, out dado_existente))
                    {
                        dado_existente.aeronave = aeronave;
                    }
                    else
                    {
                        dados_ocorrencias.Add(aeronave.codigo_ocorrencia, new DadosOcorrencia(aeronave.codigo_ocorrencia, aeronave, null, null));
                    }
                } //foreach aeronave

                foreach (Ocorrencia ocorrencia in ocorrencias)
                {
                    if (dados_ocorrencias.TryGetValue(ocorrencia.codigo_ocorrencia, out dado_existente))
                    {
                        dado_existente.ocorrencia = ocorrencia;
                    }
                    else
                    {
                        dados_ocorrencias.Add(ocorrencia.codigo_ocorrencia, new DadosOcorrencia(ocorrencia.codigo_ocorrencia, null, ocorrencia, null));
                    }
                } //foreach ocorrencias

                foreach (FatorContribuinte fator in fatores)
                {
                    if (dados_ocorrencias.TryGetValue(fator.codigo_ocorrencia, out dado_existente))
                    {
                        dado_existente.fator = fator;
                    }
                    else
                    {
                        dados_ocorrencias.Add(fator.codigo_ocorrencia, new DadosOcorrencia(fator.codigo_ocorrencia, null, null, fator));
                    }
                } //foreach fatores

                sw.Stop();

                outputBox.Text += "Tempo decorrido para leitura dos arquivos: "+ sw.Elapsed + "\r\n";

                Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(dados_ocorrencias);
                form_listacompleta.ShowDialog();
            }
            else
            {
                //Se o não for um dos três arquivos de dados exibe um erro
                outputBox.Text += "ERRO: O arquivo selecionado não é do tipo esperado.\r\n";
            }
        }//goBtn Click

        private void btnBrowseOcorrencias_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textOcorrencias.Text = openFileDialog1.FileName;
            }
        }

        private void btnFatoresContribuintes_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textFatorContribuinte.Text = openFileDialog1.FileName;
            }
        }
    }
}
