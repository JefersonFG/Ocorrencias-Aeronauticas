using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace Ocorrências_Aeronáuticas
{
    public static class Persistencia
    {
        public static Dictionary<int, DadosOcorrencia> lerCSV(string caminho_csv_ocorrencias, 
                                                                string caminho_csv_aeronaves,
                                                                string caminho_csv_fator_contribuinte) 
        {
            //CsvLinha linha;
            //CsvLeitura leitor;

            //Ocorrencia ocorrencia;
            //Aeronave aeronave;
            //FatorContribuinte fator_contribuinte;

            Dictionary<int, DadosOcorrencia> dicionario = new Dictionary<int, DadosOcorrencia>();
            DadosOcorrencia dado_existente;

            ///* leitura do arquivo de Ocorrencias */
            //leitor = new CsvLeitura(caminho_csv_ocorrencias);
            //linha = new CsvLinha();

            //leitor.LeLinha(linha); //pula a linha de colunas

            //while (leitor.LeLinha(linha))
            //{
            //    try
            //    {
            //        ocorrencia = new Ocorrencia();
            //        ocorrencia.fromCSV(linha);

            //        if (dicionario.TryGetValue(ocorrencia.codigo_ocorrencia, out dado_existente))
            //        {
            //            dado_existente.ocorrencia = ocorrencia;
            //        }
            //        else
            //        {
            //            dicionario.Add(ocorrencia.codigo_ocorrencia, new DadosOcorrencia(ocorrencia.codigo_ocorrencia, null, ocorrencia, null));
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        // o que fazer aqui ?
            //    }            
            //}//while

            //leitor.Close();

            //descobrir por que não está funcionando!
            using(var ocorrencias_stream = new StreamReader(caminho_csv_ocorrencias))
            {
                try
                {
                    var leitor = new CsvReader(ocorrencias_stream);
                    var ocorrencias = leitor.GetRecords<Ocorrencia>();
                
                    foreach(Ocorrencia ocorrencia in ocorrencias)
                    {
                        if (dicionario.TryGetValue(ocorrencia.codigo_ocorrencia, out dado_existente))
                            dado_existente.ocorrencia = ocorrencia;
                        else
                            dicionario.Add(ocorrencia.codigo_ocorrencia, new DadosOcorrencia(ocorrencia.codigo_ocorrencia, null, ocorrencia, null));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            ///* leitura do arquivo de Aeronaves */
            //leitor = new CsvLeitura(caminho_csv_aeronaves);
            //linha = new CsvLinha();
            //leitor.LeLinha(linha); //pula a linha de colunas

            //while (leitor.LeLinha(linha))
            //{
            //    try
            //    {
            //        aeronave = new Aeronave();
            //        aeronave.fromCSV(linha);

            //        if (dicionario.TryGetValue(aeronave.codigo_ocorrencia, out dado_existente))
            //        {
            //            dado_existente.aeronave = aeronave;
            //        }
            //        else
            //        {
            //            dicionario.Add(aeronave.codigo_ocorrencia, new DadosOcorrencia(aeronave.codigo_ocorrencia, aeronave, null, null));
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        // o que fazer aqui ?
            //    }
            //}//while

            //leitor.Close();

            using (var aeronaves_stream = new StreamReader(caminho_csv_aeronaves))
            {
                var leitor = new CsvReader(aeronaves_stream);
                IEnumerable<Aeronave> aeronaves = leitor.GetRecords<Aeronave>();
                try
                {
                    foreach (Aeronave aeronave in aeronaves)
                    {
                        if (dicionario.TryGetValue(aeronave.codigo_ocorrencia, out dado_existente))
                            dado_existente.aeronave = aeronave;
                        else
                            dicionario.Add(aeronave.codigo_ocorrencia, new DadosOcorrencia(aeronave.codigo_ocorrencia, aeronave, null, null));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            /* leitura do arquivo de Fatores Contribuintes */
            //leitor = new CsvLeitura(caminho_csv_fator_contribuinte);
            //linha = new CsvLinha();
            //leitor.LeLinha(linha); //pula a linha de colunas

            //while (leitor.LeLinha(linha))
            //{
            //    try
            //    {
            //        fator_contribuinte = new FatorContribuinte();
            //        fator_contribuinte.fromCSV(linha);

            //        if (dicionario.TryGetValue(fator_contribuinte.codigo_ocorrencia, out dado_existente))
            //        {
            //            dado_existente.fator = fator_contribuinte;
            //        }
            //        else
            //        {
            //            dicionario.Add(fator_contribuinte.codigo_ocorrencia, new DadosOcorrencia(fator_contribuinte.codigo_ocorrencia, null, null, fator_contribuinte));
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        // o que fazer aqui ?
            //    }
            //}//while

            //leitor.Close();

            using (var fatores_stream = new StreamReader(caminho_csv_fator_contribuinte))
            {
                var leitor = new CsvReader(fatores_stream);
                IEnumerable<FatorContribuinte> fatores = leitor.GetRecords<FatorContribuinte>();
                try
                {
                    foreach (FatorContribuinte fator in fatores)
                    {
                        if (dicionario.TryGetValue(fator.codigo_ocorrencia, out dado_existente))
                            dado_existente.fator = fator;
                        else
                            dicionario.Add(fator.codigo_ocorrencia, new DadosOcorrencia(fator.codigo_ocorrencia, null, null, fator));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            return dicionario;

        } //lerCSV()

        public static void escreverResultados(TIPO_SORT tipo_sort, TIPO_DADO_SORT tipo_dado_sort, int qtde_dados, float tempo_ms)
        {

        } //escreverResultados()

        /*public static void inicializaResultados()
        {
            File.WriteAllText("../../resultados_Aerosafe.txt", string.Empty);
        }

        public static void escreveResultado(string resultado)
        {
            using (StreamWriter sw = new StreamWriter("../../resultados_Aerosafe.txt", true))
            {
                sw.WriteLine(resultado);
            }
        } */
    }//class
} //namespace
