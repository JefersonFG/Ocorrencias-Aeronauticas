using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// OnClick do botão de busca do arquivo de dados para leitura
        /// </summary>
        /// <param name="sender">Origem do evento</param>
        /// <param name="e">Instância <see cref="EventArgs"/> que contém as informações do evento</param>
        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
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

            //Verifica se a caixa de texto está vazia, se sim informa o usuário para que selecione um arquivo para leitura
            if(textBox1.Text.Trim() == "")
            {
                outputBox.Text = "Selecione um arquivo CSV.";
                return;
            }

            leitor = new CsvLeitura(textBox1.Text);

            outputBox.Text = "Populando classes...\r\n";

            if (textBox1.Text.EndsWith("ocorrencia.csv"))
            {
                //Arquivo de ocorrências
                Form_ListaCompleta listaCompleta = new Form_ListaCompleta(ocorrencias);
                leitor.LeLinha(linha);
                listaCompleta.populaColunas(linha);

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 19)
                    {
                        MessageBox.Show("Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Ocorrencia ocorrencia = new Ocorrencia();
                        ocorrencia.fromCSV(linha);
                        ocorrencias.Add(ocorrencia);
                        ++linha_atual;
                    }
                }
                leitor.Close();
                listaCompleta.populaDados(ocorrencias);
                outputBox.Text += "Foram criadas " + linha_atual + " entradas.\r\n";
                listaCompleta.ShowDialog(); 
            }
            else if (textBox1.Text.EndsWith("aeronave.csv"))
            {
                //Arquivo de aeronaves
                Form_ListaCompleta listaCompleta = new Form_ListaCompleta(aeronaves);
                leitor.LeLinha(linha);
                listaCompleta.populaColunas(linha);

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 22)
                    {
                        MessageBox.Show("Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Aeronave aeronave = new Aeronave();
                        aeronave.fromCSV(linha);
                        aeronaves.Add(aeronave);
                        ++linha_atual;
                    }
                }
                leitor.Close();
                listaCompleta.populaDados(aeronaves);
                outputBox.Text += "Foram criadas " + linha_atual + " entradas.\r\n";
                listaCompleta.ShowDialog();
            }
            else if (textBox1.Text.EndsWith("fator_contribuinte.csv"))
            {
                //Arquivo de fatores contribuintes
                Form_ListaCompleta listaCompleta = new Form_ListaCompleta(fatores);
                leitor.LeLinha(linha);
                listaCompleta.populaColunas(linha);

                while (leitor.LeLinha(linha))
                {
                    if (linha.Count != 8)
                    {
                        MessageBox.Show("Quantidade de campos na linha " + linha_atual + " é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FatorContribuinte fator = new FatorContribuinte();
                        fator.fromCSV(linha);
                        fatores.Add(fator);
                        ++linha_atual;
                    }
                }
                leitor.Close();
                listaCompleta.populaDados(fatores);
                outputBox.Text += "Foram criadas " + linha_atual + " entradas.\r\n";
                listaCompleta.ShowDialog();
            }
            else
            {
                //Se o não for um dos três arquivos de dados exibe um erro
                outputBox.Text += "ERRO: O arquivo selecionado não é do tipo esperado.\r\n";
            }
        }//goBtn Click
    }
}
