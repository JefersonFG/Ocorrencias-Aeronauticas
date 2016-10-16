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
        private FolderBrowserDialog folderBrowserDialog1;
        private Label labelCarregando;
        private CheckBox checkUsarPadrao;
        private Button btnOK;

        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textCaminhoPasta = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelCarregando = new System.Windows.Forms.Label();
            this.checkUsarPadrao = new System.Windows.Forms.CheckBox();
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
            this.btnOK.Location = new System.Drawing.Point(302, 85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelCarregando
            // 
            this.labelCarregando.AutoSize = true;
            this.labelCarregando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarregando.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCarregando.Location = new System.Drawing.Point(13, 90);
            this.labelCarregando.Name = "labelCarregando";
            this.labelCarregando.Size = new System.Drawing.Size(176, 13);
            this.labelCarregando.TabIndex = 4;
            this.labelCarregando.Text = "Carregando dados, aguarde...";
            this.labelCarregando.Visible = false;
            // 
            // checkUsarPadrao
            // 
            this.checkUsarPadrao.AutoSize = true;
            this.checkUsarPadrao.Location = new System.Drawing.Point(16, 58);
            this.checkUsarPadrao.Name = "checkUsarPadrao";
            this.checkUsarPadrao.Size = new System.Drawing.Size(113, 17);
            this.checkUsarPadrao.TabIndex = 5;
            this.checkUsarPadrao.Text = "Usar pasta padrão";
            this.checkUsarPadrao.UseVisualStyleBackColor = true;
            this.checkUsarPadrao.CheckedChanged += new System.EventHandler(this.checkUsarPadrao_CheckedChanged);
            // 
            // LoadForm
            // 
            this.ClientSize = new System.Drawing.Size(383, 114);
            this.Controls.Add(this.checkUsarPadrao);
            this.Controls.Add(this.labelCarregando);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textCaminhoPasta);
            this.Controls.Add(this.label1);
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione a pasta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                textCaminhoPasta.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string caminho_pasta;
            string caminho_ocorrencias;
            string caminho_aeronaves;
            string caminho_fatores;

            caminho_pasta = textCaminhoPasta.Text;

            if(caminho_pasta.Trim().Equals(""))
            {
                MessageBox.Show("Selecione a pasta que contém os arquivos CSV", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textCaminhoPasta.Focus();
                return;
            }

            if (!caminho_pasta.EndsWith("\\"))
                caminho_pasta += "\\";

            caminho_ocorrencias = caminho_pasta + "ocorrencia.csv";
            caminho_aeronaves = caminho_pasta + "aeronave.csv";
            caminho_fatores = caminho_pasta + "fator_contribuinte.csv";

            Dictionary<int, DadosOcorrencia> dicionario;

            labelCarregando.Visible = true;

            Application.DoEvents(); //atualiza UI

            try
            {
                dicionario = Persistencia.lerCSV(caminho_ocorrencias, caminho_aeronaves, caminho_fatores);

                if(dicionario.Count < 1)
                {
                    MessageBox.Show("Nenhum registro foi lido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } //catch

            Controlador.dicionarioInicial(dicionario);

            labelCarregando.Text = dicionario.Count + " registros lidos. Abrindo mapa...";
            Application.DoEvents(); //atualiza UI
            System.Threading.Thread.Sleep(800); //para dar tempo de ler a qtde de registros lidos
            
            labelCarregando.Visible = false;

            MainForm main_form = new MainForm();
            this.Hide();
            main_form.ShowDialog();
            this.Close(); //fecha quando o MainForm fechar

        } //btnOK_Click()

        private void checkUsarPadrao_CheckedChanged(object sender, EventArgs e)
        {
            if(checkUsarPadrao.Checked == true)
            {
                textCaminhoPasta.ReadOnly = true;

                textCaminhoPasta.Text = AppDomain.CurrentDomain.BaseDirectory;
                if (!textCaminhoPasta.Text.EndsWith("\\"))
                    textCaminhoPasta.Text += "\\";
                textCaminhoPasta.Text += "..\\..\\data\\";
                btnBrowse.Enabled = false;
            }
            else
            {
                textCaminhoPasta.ReadOnly = false;
                btnBrowse.Enabled = true;
                textCaminhoPasta.Focus();
            }
        } //checkUsarPadrao_CheckedChanged()
    }//class
}//namespace
