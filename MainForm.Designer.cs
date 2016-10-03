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
            this.Gmap = new GMap.NET.WindowsForms.GMapControl();
            this.textAeronaves = new System.Windows.Forms.TextBox();
            this.btnBrowseAeronaves = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.goBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseOcorrencias = new System.Windows.Forms.Button();
            this.textOcorrencias = new System.Windows.Forms.TextBox();
            this.textFatorContribuinte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFatoresContribuintes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Gmap
            // 
            this.Gmap.Bearing = 0F;
            this.Gmap.CanDragMap = true;
            this.Gmap.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gmap.EmptyTileColor = System.Drawing.Color.RoyalBlue;
            this.Gmap.GrayScaleMode = false;
            this.Gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Gmap.LevelsKeepInMemmory = 5;
            this.Gmap.Location = new System.Drawing.Point(0, 0);
            this.Gmap.MarkersEnabled = true;
            this.Gmap.MaxZoom = 18;
            this.Gmap.MinZoom = 2;
            this.Gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Gmap.Name = "Gmap";
            this.Gmap.NegativeMode = false;
            this.Gmap.PolygonsEnabled = true;
            this.Gmap.RetryLoadTile = 0;
            this.Gmap.RoutesEnabled = true;
            this.Gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Gmap.ShowTileGridLines = false;
            this.Gmap.Size = new System.Drawing.Size(484, 273);
            this.Gmap.TabIndex = 0;
            this.Gmap.Zoom = 13D;
            this.Gmap.Load += new System.EventHandler(this.Gmap_Load);
            // 
            // textAeronaves
            // 
            this.textAeronaves.Location = new System.Drawing.Point(12, 306);
            this.textAeronaves.Name = "textAeronaves";
            this.textAeronaves.ReadOnly = true;
            this.textAeronaves.Size = new System.Drawing.Size(379, 20);
            this.textAeronaves.TabIndex = 1;
            // 
            // btnBrowseAeronaves
            // 
            this.btnBrowseAeronaves.Location = new System.Drawing.Point(397, 304);
            this.btnBrowseAeronaves.Name = "btnBrowseAeronaves";
            this.btnBrowseAeronaves.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAeronaves.TabIndex = 2;
            this.btnBrowseAeronaves.Text = "Browse";
            this.btnBrowseAeronaves.UseVisualStyleBackColor = true;
            this.btnBrowseAeronaves.Click += new System.EventHandler(this.btnBrowseAeronaves_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "Arquivo CSV|*.csv";
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(12, 420);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(460, 23);
            this.goBtn.TabIndex = 3;
            this.goBtn.Text = "Go";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.AcceptsReturn = true;
            this.outputBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(12, 449);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(460, 90);
            this.outputBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Arquivo de aeronaves:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Arquivo de ocorrências:";
            // 
            // btnBrowseOcorrencias
            // 
            this.btnBrowseOcorrencias.Location = new System.Drawing.Point(397, 343);
            this.btnBrowseOcorrencias.Name = "btnBrowseOcorrencias";
            this.btnBrowseOcorrencias.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOcorrencias.TabIndex = 8;
            this.btnBrowseOcorrencias.Text = "Browse";
            this.btnBrowseOcorrencias.UseVisualStyleBackColor = true;
            this.btnBrowseOcorrencias.Click += new System.EventHandler(this.btnBrowseOcorrencias_Click);
            // 
            // textOcorrencias
            // 
            this.textOcorrencias.Location = new System.Drawing.Point(12, 345);
            this.textOcorrencias.Name = "textOcorrencias";
            this.textOcorrencias.ReadOnly = true;
            this.textOcorrencias.Size = new System.Drawing.Size(379, 20);
            this.textOcorrencias.TabIndex = 7;
            // 
            // textFatorContribuinte
            // 
            this.textFatorContribuinte.Location = new System.Drawing.Point(12, 384);
            this.textFatorContribuinte.Name = "textFatorContribuinte";
            this.textFatorContribuinte.ReadOnly = true;
            this.textFatorContribuinte.Size = new System.Drawing.Size(379, 20);
            this.textFatorContribuinte.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Arquivo de fatores contribuintes:";
            // 
            // btnFatoresContribuintes
            // 
            this.btnFatoresContribuintes.Location = new System.Drawing.Point(397, 382);
            this.btnFatoresContribuintes.Name = "btnFatoresContribuintes";
            this.btnFatoresContribuintes.Size = new System.Drawing.Size(75, 23);
            this.btnFatoresContribuintes.TabIndex = 11;
            this.btnFatoresContribuintes.Text = "Browse";
            this.btnFatoresContribuintes.UseVisualStyleBackColor = true;
            this.btnFatoresContribuintes.Click += new System.EventHandler(this.btnFatoresContribuintes_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 568);
            this.Controls.Add(this.btnFatoresContribuintes);
            this.Controls.Add(this.textFatorContribuinte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseOcorrencias);
            this.Controls.Add(this.textOcorrencias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.btnBrowseAeronaves);
            this.Controls.Add(this.textAeronaves);
            this.Controls.Add(this.Gmap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ocorrências Aeronáuticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl Gmap;
        private System.Windows.Forms.TextBox textAeronaves;
        private System.Windows.Forms.Button btnBrowseAeronaves;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseOcorrencias;
        private System.Windows.Forms.TextBox textOcorrencias;
        private System.Windows.Forms.TextBox textFatorContribuinte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFatoresContribuintes;
        public System.Windows.Forms.TextBox outputBox;
    }
}

