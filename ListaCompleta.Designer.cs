using System;

namespace Ocorrências_Aeronáuticas
{
    partial class ListaCompleta
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
            this.gridListaCompleta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaCompleta)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListaCompleta
            // 
            this.gridListaCompleta.AllowUserToAddRows = false;
            this.gridListaCompleta.AllowUserToDeleteRows = false;
            this.gridListaCompleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListaCompleta.Location = new System.Drawing.Point(12, 12);
            this.gridListaCompleta.Name = "gridListaCompleta";
            this.gridListaCompleta.ReadOnly = true;
            this.gridListaCompleta.Size = new System.Drawing.Size(684, 400);
            this.gridListaCompleta.TabIndex = 0;
            // 
            // ListaCompleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 424);
            this.Controls.Add(this.gridListaCompleta);
            this.Name = "ListaCompleta";
            this.Text = "Lista Completa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListaCompleta_FormClosed);
            this.Load += new System.EventHandler(this.ListaCompleta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListaCompleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridListaCompleta;
    }
}