namespace Ocorrências_Aeronáuticas
{
    partial class OrdenaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCampo = new System.Windows.Forms.ComboBox();
            this.checkDecrescente = new System.Windows.Forms.CheckBox();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.gridDados = new System.Windows.Forms.DataGridView();
            this.textDadoSelecionado = new System.Windows.Forms.TextBox();
            this.textTempoExecucao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algoritmo:";
            // 
            // comboAlgoritmo
            // 
            this.comboAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgoritmo.FormattingEnabled = true;
            this.comboAlgoritmo.Items.AddRange(new object[] {
            "Bubble Sort (BBST)",
            "Heap Sort (HPST)",
            "Insertion Sort com Busca Linear (ISBL)",
            "Quick Sort Randomizado (QSRM)",
            "Shell Sort (SHST)"});
            this.comboAlgoritmo.Location = new System.Drawing.Point(15, 25);
            this.comboAlgoritmo.Name = "comboAlgoritmo";
            this.comboAlgoritmo.Size = new System.Drawing.Size(233, 21);
            this.comboAlgoritmo.Sorted = true;
            this.comboAlgoritmo.TabIndex = 1;
            this.comboAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.comboAlgoritmo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Campo a ser ordenado:";
            // 
            // comboCampo
            // 
            this.comboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCampo.FormattingEnabled = true;
            this.comboCampo.Items.AddRange(new object[] {
            "código da ocorrência",
            "localidade"});
            this.comboCampo.Location = new System.Drawing.Point(15, 69);
            this.comboCampo.Name = "comboCampo";
            this.comboCampo.Size = new System.Drawing.Size(233, 21);
            this.comboCampo.TabIndex = 3;
            // 
            // checkDecrescente
            // 
            this.checkDecrescente.AutoSize = true;
            this.checkDecrescente.Location = new System.Drawing.Point(15, 100);
            this.checkDecrescente.Name = "checkDecrescente";
            this.checkDecrescente.Size = new System.Drawing.Size(87, 17);
            this.checkDecrescente.TabIndex = 4;
            this.checkDecrescente.Text = "Decrescente";
            this.checkDecrescente.UseVisualStyleBackColor = true;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Location = new System.Drawing.Point(143, 128);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(105, 23);
            this.btnOrdenar.TabIndex = 5;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // gridDados
            // 
            this.gridDados.AllowUserToAddRows = false;
            this.gridDados.AllowUserToDeleteRows = false;
            this.gridDados.AllowUserToOrderColumns = true;
            this.gridDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDados.Location = new System.Drawing.Point(267, 25);
            this.gridDados.MultiSelect = false;
            this.gridDados.Name = "gridDados";
            this.gridDados.ReadOnly = true;
            this.gridDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDados.Size = new System.Drawing.Size(199, 200);
            this.gridDados.TabIndex = 6;
            this.gridDados.SelectionChanged += new System.EventHandler(this.gridDados_SelectionChanged);
            // 
            // textDadoSelecionado
            // 
            this.textDadoSelecionado.Location = new System.Drawing.Point(472, 25);
            this.textDadoSelecionado.Multiline = true;
            this.textDadoSelecionado.Name = "textDadoSelecionado";
            this.textDadoSelecionado.ReadOnly = true;
            this.textDadoSelecionado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textDadoSelecionado.Size = new System.Drawing.Size(187, 200);
            this.textDadoSelecionado.TabIndex = 7;
            // 
            // textTempoExecucao
            // 
            this.textTempoExecucao.Location = new System.Drawing.Point(12, 248);
            this.textTempoExecucao.Multiline = true;
            this.textTempoExecucao.Name = "textTempoExecucao";
            this.textTempoExecucao.ReadOnly = true;
            this.textTempoExecucao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textTempoExecucao.Size = new System.Drawing.Size(547, 112);
            this.textTempoExecucao.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Benchmarks:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lista de ocorrências:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ocorrência selecionada:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(581, 288);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 31);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // OrdenaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 389);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTempoExecucao);
            this.Controls.Add(this.textDadoSelecionado);
            this.Controls.Add(this.gridDados);
            this.Controls.Add(this.btnOrdenar);
            this.Controls.Add(this.checkDecrescente);
            this.Controls.Add(this.comboCampo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboAlgoritmo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OrdenaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ordenar dados";
            this.Load += new System.EventHandler(this.OrdenaForm_Load);
            this.Shown += new System.EventHandler(this.OrdenaForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAlgoritmo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCampo;
        private System.Windows.Forms.CheckBox checkDecrescente;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.DataGridView gridDados;
        private System.Windows.Forms.TextBox textDadoSelecionado;
        private System.Windows.Forms.TextBox textTempoExecucao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvar;
    }
}