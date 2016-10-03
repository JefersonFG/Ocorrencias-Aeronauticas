using System;

namespace Ocorrências_Aeronáuticas
{
    partial class Form_ListaCompleta
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
            this.btnSort = new System.Windows.Forms.Button();
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
            this.gridListaCompleta.Size = new System.Drawing.Size(684, 321);
            this.gridListaCompleta.TabIndex = 0;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(604, 339);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(92, 28);
            this.btnSort.TabIndex = 1;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // Form_ListaCompleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 379);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.gridListaCompleta);
            this.Name = "Form_ListaCompleta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista Completa";
            ((System.ComponentModel.ISupportInitialize)(this.gridListaCompleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridListaCompleta;
        private System.Windows.Forms.Button btnSort;
    }
}