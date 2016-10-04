﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ocorrências_Aeronáuticas
{
    public partial class Form_Sort : Form
    {
        private List<DadosOcorrencia> lista_dados_ocorrencias = null;

        public Form_Sort(List<DadosOcorrencia> lista_desordenada)
        {
            InitializeComponent();
            lista_dados_ocorrencias = lista_desordenada;
        }

        private void btnSortGo_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            Form_Aguarde pleaseWait = new Form_Aguarde();

            // Display form modelessly
            pleaseWait.Show();
            this.Enabled = false;

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            #region Bubble Sort
            if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Bubble Sort (BBST)"))
            {
                
                //MessageBox.Show("Bubble Sort selecionado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.bubbleSort_codigo_ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach(DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "BBST, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.bubbleSort_localidade(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "BBST, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                
            }
            #endregion
            #region Quick Sort
            else if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Quick Sort Randomizado (QSRM)"))
            {

                textBenchmarks.AppendText("Quick Sort Randomizado (QSRM): \r\n");

                

                //MessageBox.Show("Bubble Sort selecionado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    textBenchmarks.AppendText(" sort \"codigo_ocorrencia\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.QSRM_Ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "QSRM, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    textBenchmarks.AppendText(" sort \"localidade\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.QSRM_Localizacao(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "QSRM, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
            }
            #endregion
            #region Insertion Sort
            else if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Insertion Sort com Busca Linear (ISBL)"))
            {
                textBenchmarks.AppendText("Insertion Sort com Busca Linear (ISBL): \r\n");

                

                if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    textBenchmarks.AppendText(" sort \"codigo_ocorrencia\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.InsertionSort_codigo_ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "ISBL, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    textBenchmarks.AppendText(" sort \"localidade\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.InsertionSort_localidade(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "ISBL, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
            }
            #endregion
            #region Shell Sort
            else if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Shell Sort (SHST)"))
            {
                textBenchmarks.AppendText("Shell Sort (SHST): \r\n");

                if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    textBenchmarks.AppendText(" sort \"codigo_ocorrencia\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.ShellSort_codigo_ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "SHST, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    textBenchmarks.AppendText(" sort \"localidade\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.ShellSort_localidade(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "SHST, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
            }
            #endregion
            #region Heap Sort
            else if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Heap Sort (HPST)"))
            {
                textBenchmarks.AppendText("Heap Sort (HPST): \r\n");

                if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    textBenchmarks.AppendText(" sort \"codigo_ocorrencia\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.HeapsortOcorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "HPST, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    textBenchmarks.AppendText(" sort \"localidade\":\r\n");

                    Stopwatch sw = new Stopwatch();

                    sw.Start();

                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.HeapsortLocalizacao(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    sw.Stop();

                    textBenchmarks.AppendText("  Time Elapsed: " + sw.Elapsed + "\r\n");

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "HPST, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
            }
            #endregion
            #region Merge Sort
            else if (comboAlgoritmos.GetItemText(this.comboAlgoritmos.SelectedItem).Equals("Merge Sort (MGST)"))
            {
                if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("codigo_ocorrencia"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.MGST_Ocorrencia(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "MGST, numerico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
                else if (comboCampo.GetItemText(this.comboCampo.SelectedItem).Equals("localidade"))
                {
                    List<DadosOcorrencia> lista_dados_ordenada = Sorting.HeapsortLocalizacao(lista_dados_ocorrencias);

                    Dictionary<int, DadosOcorrencia> lista_dados_resultado = new Dictionary<int, DadosOcorrencia>();
                    foreach (DadosOcorrencia dados in lista_dados_ordenada)
                    {
                        lista_dados_resultado.Add(dados.codigo_ocorrencia, dados);
                    }

                    pleaseWait.Close();
                    this.Enabled = true;
                    this.Show();
                    timer.Stop();
                    string text_output = "MGST, categorico, " + lista_dados_resultado.Count + ", " + timer.ElapsedMilliseconds.ToString();
                    mainForm.outputBox.Text += text_output + "\r\n";

                    Persistencia.escreveResultado(text_output);

                    Form_ListaCompleta form_listacompleta = new Form_ListaCompleta(lista_dados_resultado);
                    form_listacompleta.ShowDialog();
                }
            }
            #endregion
            else
            {
                MessageBox.Show("Este sort não funciona no momento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pleaseWait.Close();
                this.Enabled = true;
                this.Show();
            }


        } //btnSortGo_Click()
    }
}
