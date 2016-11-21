using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;

namespace Ocorrências_Aeronáuticas
{
    public static class Persistencia
    {
        public static string path_btree { get; set; }

        public static Dictionary<int, DadosOcorrencia> lerCSV(string caminho_csv_ocorrencias, 
                                                                string caminho_csv_aeronaves,
                                                                string caminho_csv_fator_contribuinte) 
        {
            //CsvLinha linha;
            //CsvLeitura leitor;

            //Ocorrencia ocorrencia;
            //Aeronave aeronave;
            //FatorContribuinte fator_contribuinte;

            var dicionario = new Dictionary<int, DadosOcorrencia>();
            DadosOcorrencia dado_existente;

            // leitura do arquivo de Ocorrencias
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
                    leitor.ReadHeader();
                    var ocorrencias = leitor.GetRecords<Ocorrencia>().ToList();
                
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

            // leitura do arquivo de Aeronaves
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

            // leitura do arquivo de Fatores Contribuintes 
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

        /// <summary>
        /// Cria a árvore à partir dos dados lidos do CSV
        /// </summary>
        /// <param name="dicionario">Dados lidos do CSV</param>
        /// <returns>Indica se houve erro ou não no processo</returns>
        public static bool criaArvore (Dictionary<int, DadosOcorrencia> dicionario)
        {
            //Cria o componente responsável por serializar os dados a serem escritos na árvore
            ProtoNetSerializer<DadosOcorrencia> serializer = new ProtoNetSerializer<DadosOcorrencia>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosOcorrencia>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = path_btree;

            //Checa se o arquivo já existe
            if (!File.Exists(path_btree))
            {
                using (var tree = new BPlusTree<int, DadosOcorrencia>(tree_options))
                {
                    foreach (KeyValuePair<int, DadosOcorrencia> entry in dicionario)
                    {
                        //Percorre o dicionário e adiciona na árvore
                        tree.Add(entry.Key, entry.Value);
                    }
                }
            }
            else
            {
                //Erro, a árvore já existe!
                return false;
            }

            //Se não houve erros retorna true
            return true;
        } //criaArvore()

        /// <summary>
        /// Busca um valor específico na árvore
        /// </summary>
        /// <returns>Dados lidos da árvore</returns>
        public static Dictionary<int, DadosOcorrencia> buscaValor(string valor)
        {
            //Cria um novo dicionário para retornar
            Dictionary<int, DadosOcorrencia> dicionario = new Dictionary<int, DadosOcorrencia>();

            //Cria o componente responsável por desserializar os dados a serem lidos da árvore
            ProtoNetSerializer<DadosOcorrencia> serializer = new ProtoNetSerializer<DadosOcorrencia>();

            //Prepara as opções da árvore
            var tree_options = new BPlusTree<int, DadosOcorrencia>.OptionsV2(PrimitiveSerializer.Int32, serializer);

            tree_options.CalcBTreeOrder(8, 30);
            tree_options.CreateFile = CreatePolicy.IfNeeded;
            tree_options.FileName = path_btree;

            //Checa se o arquivo já existe
            if (File.Exists(path_btree))
            {
                using (var tree = new BPlusTree<int, DadosOcorrencia>(tree_options))
                {
                    //TODO Colocar o código de pesquisa aqui
                    foreach (KeyValuePair<int, DadosOcorrencia> par in tree)
                    {
                        if (par.Value.ocorrencia.localidade == valor)
                        {
                            dicionario.Add(par.Key, par.Value);
                        }
                    }
                }
            }
            else
            {
                //Erro, a árvore não existe!
            }

            //Retorna o dicionário lido
            return dicionario;
        } //buscaValor()

        /// <summary>
        /// Construtor que obtém o caminho da árvore no disco
        /// </summary>
        static Persistencia()
        {
            //Obtém o caminho padrão da árvore          
            string path = Environment.CurrentDirectory;
            path_btree = Path.GetFullPath(Path.Combine(path, @"..\..\data\Arvore.bin"));
        } //Persistencia()

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
        }
        */
    }//class
} //namespace
