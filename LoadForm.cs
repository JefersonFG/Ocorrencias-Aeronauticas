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
    public partial class LoadForm : Form
    {
        private Label label1;
        private TextBox textCaminhoPasta;
        private Button btnBrowse;
        private Button btnOK;

        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            Dictionary<int, DadosOcorrencia> = 
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textCaminhoPasta = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta que contém os arquivos CSV:";
            // 
            // textCaminhoPasta
            // 
            this.textCaminhoPasta.Location = new System.Drawing.Point(15, 32);
            this.textCaminhoPasta.Name = "textCaminhoPasta";
            this.textCaminhoPasta.ReadOnly = true;
            this.textCaminhoPasta.Size = new System.Drawing.Size(320, 20);
            this.textCaminhoPasta.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(339, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 20);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(301, 63);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // LoadForm
            // 
            this.ClientSize = new System.Drawing.Size(383, 91);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textCaminhoPasta);
            this.Controls.Add(this.label1);
            this.Name = "LoadForm";
            this.Text = "Selecione a pasta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}
