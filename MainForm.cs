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
        private bool hamburger_habilitado = false;
        System.Drawing.Size tamanho_mapa_diminuido = new Size(487, 332);
        System.Drawing.Size tamanho_mapa_normal = new Size(759, 332);
        System.Drawing.Point posicao_mapa_direita = new Point(285, 56);
        System.Drawing.Point posicao_mapa_normal = new Point(13, 56);

        public MainForm()
        {
            InitializeComponent();
        }

        /*
         * 
         * CONTROLE
         * 
         */

        private void pesquisar()
        {
            if(textPesquisar.Text.Trim() != "")
            {
                gmapControl.SetPositionByKeywords(textPesquisar.Text);

                labelValorCidade.Text = textPesquisar.Text;
                labelValorOcorrencias.Text = "?";

                checkHamburger.Checked = true;
            }
        } //pesquisar()

        private void setModoHamburger(bool modo)
        {
            labelValorCidade.Visible = modo;
            labelOcorrencias.Visible = modo;
            labelValorOcorrencias.Visible = modo;

            if (modo == true)
            {
                gmapControl.Size = tamanho_mapa_diminuido;
                gmapControl.Location = posicao_mapa_direita;

                checkHamburger.Checked = true;
                hamburger_habilitado = true;
            }
            else
            {
                gmapControl.Size = tamanho_mapa_normal;
                gmapControl.Location = posicao_mapa_normal;

                checkHamburger.Checked = false;
                hamburger_habilitado = true;

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
            labelValorCidade.Text = "Pesquise uma localidade";
            labelValorOcorrencias.Text = "Pesquise uma localidade";
            textPesquisar.Focus();
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
    }
}
