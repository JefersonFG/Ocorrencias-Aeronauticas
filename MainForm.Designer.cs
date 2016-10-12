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
            this.SuspendLayout();
            // 
            // textPesquisar
            // 
            this.textPesquisar.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPesquisar.Location = new System.Drawing.Point(285, 12);
            this.textPesquisar.Name = "textPesquisar";
            this.textPesquisar.Size = new System.Drawing.Size(214, 26);
            this.textPesquisar.TabIndex = 1;
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
            this.gmapControl.TabIndex = 3;
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
            this.btnConfig.TabIndex = 4;
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
            this.checkHamburger.TabIndex = 5;
            this.checkHamburger.UseVisualStyleBackColor = true;
            this.checkHamburger.CheckedChanged += new System.EventHandler(this.checkHamburger_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnPesquisar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox checkHamburger;
    }
}