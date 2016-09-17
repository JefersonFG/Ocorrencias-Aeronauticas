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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Gmap_Load(object sender, EventArgs e)
        {
            //Setup inicial feito no evento OnLoad do componente de mapas

            Gmap.MapProvider = GoogleMapProvider.Instance;              //Utilizando Google Maps como provider
            GMaps.Instance.Mode = AccessMode.ServerOnly;                //Configurado para não criar cache, usar sempre informações do servidor
            //Gmap.SetPositionByKeywords("Porto Alegre, Brazil");       //Posição por palavras chave
            Gmap.Position = new PointLatLng(-30.0364242, -51.2191413);  //Posição por coordenadas
            Gmap.ShowCenter = false;                                    //Remove a cruz que indica o centro do mapa

            //Inserção de um marcado de local

            GMapOverlay markers = new GMapOverlay("markers");           //Overlay é uma camada onde colocamos marcadores e rotas
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(-30.0364242, -51.2191413),
                GMarkerGoogleType.red_small);                           //Configurado marcador por coordenada
            markers.Markers.Add(marker);                                //Adicionado o marcador ao overlay
            Gmap.Overlays.Add(markers);                                 //Adicionado overlay ao mapa
        }
    }
}
