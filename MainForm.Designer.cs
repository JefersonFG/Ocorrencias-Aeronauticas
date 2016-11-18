namespace Ocorrências_Aeronáuticas
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textPesquisar = new System.Windows.Forms.TextBox();
            this.gmapControl = new GMap.NET.WindowsForms.GMapControl();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.checkHamburger = new System.Windows.Forms.CheckBox();
            this.labelSelecioneCidade = new System.Windows.Forms.Label();
            this.comboSelecioneCidade = new System.Windows.Forms.ComboBox();
            this.labelCidadesEncontradas = new System.Windows.Forms.Label();
            this.labelDadosOcorrencia = new System.Windows.Forms.Label();
            this.textDadosOcorrencia = new System.Windows.Forms.TextBox();
            this.comboOcorrencias = new System.Windows.Forms.ComboBox();
            this.labelOcorrencias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textPesquisar
            // 
            this.textPesquisar.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPesquisar.Location = new System.Drawing.Point(285, 12);
            this.textPesquisar.Name = "textPesquisar";
            this.textPesquisar.Size = new System.Drawing.Size(214, 26);
            this.textPesquisar.TabIndex = 1;
            this.textPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPesquisar_KeyDown);
            // 
            // gmapControl
            // 
            this.gmapControl.Bearing = 0F;
            this.gmapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gmapControl.CanDragMap = true;
            this.gmapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapControl.GrayScaleMode = false;
            this.gmapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapControl.LevelsKeepInMemmory = 5;
            this.gmapControl.Location = new System.Drawing.Point(13, 56);
            this.gmapControl.MarkersEnabled = true;
            this.gmapControl.MaxZoom = 18;
            this.gmapControl.MinZoom = 2;
            this.gmapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapControl.Name = "gmapControl";
            this.gmapControl.NegativeMode = false;
            this.gmapControl.PolygonsEnabled = true;
            this.gmapControl.RetryLoadTile = 0;
            this.gmapControl.RoutesEnabled = true;
            this.gmapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapControl.ShowTileGridLines = false;
            this.gmapControl.Size = new System.Drawing.Size(759, 332);
            this.gmapControl.TabIndex = 100;
            this.gmapControl.Zoom = 13D;
            this.gmapControl.Load += new System.EventHandler(this.gmapControl_Load);
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::Ocorrências_Aeronáuticas.Properties.Resources.config;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConfig.Location = new System.Drawing.Point(742, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(30, 30);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackgroundImage = global::Ocorrências_Aeronáuticas.Properties.Resources.search;
            this.btnPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisar.Location = new System.Drawing.Point(505, 10);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(30, 30);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // checkHamburger
            // 
            this.checkHamburger.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkHamburger.BackgroundImage = global::Ocorrências_Aeronáuticas.Properties.Resources.hamburger;
            this.checkHamburger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkHamburger.Location = new System.Drawing.Point(12, 10);
            this.checkHamburger.Name = "checkHamburger";
            this.checkHamburger.Size = new System.Drawing.Size(30, 30);
            this.checkHamburger.TabIndex = 0;
            this.checkHamburger.UseVisualStyleBackColor = true;
            this.checkHamburger.CheckedChanged += new System.EventHandler(this.checkHamburger_CheckedChanged);
            // 
            // labelSelecioneCidade
            // 
            this.labelSelecioneCidade.AutoSize = true;
            this.labelSelecioneCidade.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelecioneCidade.Location = new System.Drawing.Point(12, 75);
            this.labelSelecioneCidade.Name = "labelSelecioneCidade";
            this.labelSelecioneCidade.Size = new System.Drawing.Size(104, 16);
            this.labelSelecioneCidade.TabIndex = 101;
            this.labelSelecioneCidade.Text = "Lista de cidades:";
            this.labelSelecioneCidade.Visible = false;
            // 
            // comboSelecioneCidade
            // 
            this.comboSelecioneCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelecioneCidade.FormattingEnabled = true;
            this.comboSelecioneCidade.Location = new System.Drawing.Point(15, 96);
            this.comboSelecioneCidade.Name = "comboSelecioneCidade";
            this.comboSelecioneCidade.Size = new System.Drawing.Size(164, 21);
            this.comboSelecioneCidade.TabIndex = 102;
            this.comboSelecioneCidade.Visible = false;
            this.comboSelecioneCidade.SelectionChangeCommitted += new System.EventHandler(this.comboSelecioneCidade_SelectionChangeCommitted);
            // 
            // labelCidadesEncontradas
            // 
            this.labelCidadesEncontradas.AutoSize = true;
            this.labelCidadesEncontradas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCidadesEncontradas.Location = new System.Drawing.Point(12, 56);
            this.labelCidadesEncontradas.Name = "labelCidadesEncontradas";
            this.labelCidadesEncontradas.Size = new System.Drawing.Size(132, 16);
            this.labelCidadesEncontradas.TabIndex = 103;
            this.labelCidadesEncontradas.Text = "Pesquise uma cidade.";
            this.labelCidadesEncontradas.Visible = false;
            // 
            // labelDadosOcorrencia
            // 
            this.labelDadosOcorrencia.AutoSize = true;
            this.labelDadosOcorrencia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDadosOcorrencia.Location = new System.Drawing.Point(13, 174);
            this.labelDadosOcorrencia.Name = "labelDadosOcorrencia";
            this.labelDadosOcorrencia.Size = new System.Drawing.Size(146, 16);
            this.labelDadosOcorrencia.TabIndex = 104;
            this.labelDadosOcorrencia.Text = "Dados da ocorrência:";
            this.labelDadosOcorrencia.Visible = false;
            // 
            // textDadosOcorrencia
            // 
            this.textDadosOcorrencia.Location = new System.Drawing.Point(15, 196);
            this.textDadosOcorrencia.Multiline = true;
            this.textDadosOcorrencia.Name = "textDadosOcorrencia";
            this.textDadosOcorrencia.ReadOnly = true;
            this.textDadosOcorrencia.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textDadosOcorrencia.Size = new System.Drawing.Size(246, 192);
            this.textDadosOcorrencia.TabIndex = 105;
            this.textDadosOcorrencia.Visible = false;
            // 
            // comboOcorrencias
            // 
            this.comboOcorrencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOcorrencias.FormattingEnabled = true;
            this.comboOcorrencias.Location = new System.Drawing.Point(15, 144);
            this.comboOcorrencias.Name = "comboOcorrencias";
            this.comboOcorrencias.Size = new System.Drawing.Size(76, 21);
            this.comboOcorrencias.TabIndex = 106;
            this.comboOcorrencias.Visible = false;
            this.comboOcorrencias.SelectionChangeCommitted += new System.EventHandler(this.comboOcorrencias_SelectionChangeCommitted);
            // 
            // labelOcorrencias
            // 
            this.labelOcorrencias.AutoSize = true;
            this.labelOcorrencias.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOcorrencias.Location = new System.Drawing.Point(12, 123);
            this.labelOcorrencias.Name = "labelOcorrencias";
            this.labelOcorrencias.Size = new System.Drawing.Size(186, 16);
            this.labelOcorrencias.TabIndex = 107;
            this.labelOcorrencias.Text = "Lista de ocorrências na cidade:";
            this.labelOcorrencias.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.labelOcorrencias);
            this.Controls.Add(this.comboOcorrencias);
            this.Controls.Add(this.textDadosOcorrencia);
            this.Controls.Add(this.labelDadosOcorrencia);
            this.Controls.Add(this.labelCidadesEncontradas);
            this.Controls.Add(this.comboSelecioneCidade);
            this.Controls.Add(this.labelSelecioneCidade);
            this.Controls.Add(this.checkHamburger);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.gmapControl);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.textPesquisar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ocorrências Aeronáuticas";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox checkHamburger;
        private System.Windows.Forms.Label labelSelecioneCidade;
        private System.Windows.Forms.ComboBox comboSelecioneCidade;
        private System.Windows.Forms.Label labelCidadesEncontradas;
        private System.Windows.Forms.Label labelDadosOcorrencia;
        private System.Windows.Forms.TextBox textDadosOcorrencia;
        private System.Windows.Forms.ComboBox comboOcorrencias;
        private System.Windows.Forms.Label labelOcorrencias;
    }
}