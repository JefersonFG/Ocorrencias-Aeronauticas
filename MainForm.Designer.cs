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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.goBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(379, 20);
            this.textBox1.TabIndex = 1;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(397, 279);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "csv";
            this.openFileDialog1.Filter = "Arquivo CSV|*.csv";
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(12, 307);
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
            this.outputBox.Location = new System.Drawing.Point(12, 336);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(460, 90);
            this.outputBox.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 438);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox outputBox;
    }
}

