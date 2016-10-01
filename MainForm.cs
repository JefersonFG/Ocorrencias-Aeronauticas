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

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }//browseBtn Click

        private void goBtn_Click(object sender, EventArgs e)
        {
            CsvLeitura leitor;
            CsvLinha linha = new CsvLinha();
            bool leu_linha = false;
            bool continuar = true;
            int linha_atual = 0;
            List<Aeronave> aeronaves = new List<Aeronave>();

            if(textBox1.Text.Trim() == "" | ! (textBox1.Text.EndsWith(".csv")))
            {
                MessageBox.Show("Selecione um arquivo CSV", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            leitor = new CsvLeitura(textBox1.Text);


            /*
            while(continuar && (leu_linha = leitor.LeLinha(linha))) //bota a chamada de leitura dentro do while
            {
                linha_mensagem = "";
                for(int i = 0; i < linha.Count; i++)
                {
                    linha_mensagem += linha[i];
                    linha_mensagem += " | ";
                }
                var resposta = MessageBox.Show(linha_mensagem, "Mensagem", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (resposta == DialogResult.Cancel)
                {
                    continuar = false;
                    break;
                }
            } */

            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

            while (continuar && (leu_linha = leitor.LeLinha(linha)))
            {
                if(linha.Count != 19)
                {
                    MessageBox.Show("Quantidade de campos na linha "+linha_atual+" é inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (linha_atual > 0)
                    {
                        Ocorrencia ocorrencia = new Ocorrencia();
                        ocorrencia.codigo_ocorrencia = Int32.Parse(linha[0]);
                        ocorrencia.classificacao = linha[1];
                        ocorrencia.tipo = linha[2];
                        ocorrencia.localidade = linha[3];
                        ocorrencias.Add(ocorrencia);
                    }
                }
                
                linha_atual++;
            }

            leitor.Close();

            ListaCompleta listaCompleta = new ListaCompleta(ocorrencias);
            listaCompleta.ShowDialog();
            */

            while (leitor.LeLinha(linha))
            {
                Aeronave aeronave = new Aeronave();
                aeronave.fromCSV(linha);
                aeronaves.Add(aeronave);
            }
        }//goBtn Click
    }
}
