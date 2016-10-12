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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

        }

        private void checkHamburger_CheckedChanged(object sender, EventArgs e)
        {
            if (hamburger_habilitado)
            {
                gmapControl.Size = tamanho_mapa_normal;
                gmapControl.Location = posicao_mapa_normal;

                hamburger_habilitado = false;
            }//if
            else
            {
                gmapControl.Size = tamanho_mapa_diminuido;
                gmapControl.Location = posicao_mapa_direita;

                hamburger_habilitado = true;
            } //else
        }
    }
}
