using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CSharpTest.Net.Collections;
using CSharpTest.Net.Serialization;

namespace Ocorrências_Aeronáuticas
{
    public static class Persistencia
    {
        public static string path_btree { get; set; }

        /// <summary>
        /// Lê os arquivos CSV, populando um dicionário e posteriormente gerando 
        /// a árvore B, no disco. Ocorre em três etapas, primeiramente, pois exis-
        /// tem 3 arquivos a serem lidos: primeiro é lido o de Ocorrências, depois
        /// o de Aeronaves e, por fim, o de Fatores Contribuintes. Todos os dados
        /// lidos nestes arquivos servem para popular um único dicionário de Dados
        /// de Ocorrências, onde a chave é o Código de Ocorrência. Feito isso, é
        /// salva a árvore B no disco, para os usos futuros do aplicativo.
        /// </summary>
        /// <param name="caminho_csv_ocorrencias">O caminho do CSV de Ocorrencias.</param>
        /// <param name="caminho_csv_aeronaves">O caminho do CSV de Aeronaves.</param>
        /// <param name="caminho_csv_fator_contribuinte">O caminho do CSV de Fatores Contribuintes.</param>
        public static void lerCSV(string caminho_csv_ocorrencias, 
                                                                string caminho_csv_aeronaves,
                                                                string caminho_csv_fator_contribuinte) 
        {
            var dicionario = new Dictionary<int, DadosOcorrencia>();
            DadosOcorrencia dado_existente;

            // leitura do arquivo de Ocorrencias
            using(var ocorrencias_stream = new StreamReader(caminho_csv_ocorrencias))
            {
                //tenta abrir o CSV e ler todos os registros de uma vez só
                try
                {
                    var leitor = new CsvReader(ocorrencias_stream);
                    leitor.ReadHeader();
                    var ocorrencias = leitor.GetRecords<Ocorrencia>().ToList();
                    
                    //lidos os registros, itera todos e os adiciona no dicionário,
                    //conforme necessário
                    foreach(Ocorrencia ocorrencia in ocorrencias)
                    {
                        if (dicionario.TryGetValue(ocorrencia.codigo_ocorrencia, out dado_existente))
                            dado_existente.ocorrencia = ocorrencia;
                        else
                            dicionario.Add(ocorrencia.codigo_ocorrencia, new DadosOcorrencia(ocorrencia.codigo_ocorrencia, null, ocorrencia, null));
                    }
                }
                //se há qualquer problema na leitura, mostra caixa de exception
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            // leitura do arquivo de Aeronaves
            using (var aeronaves_stream = new StreamReader(caminho_csv_aeronaves))
            {
                var leitor = new CsvReader(aeronaves_stream);
                IEnumerable<Aeronave> aeronaves = leitor.GetRecords<Aeronave>();

                //itera os registros, e os adiciona no dicionário
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
                //se há qualquer problema na leitura, mostra caixa de exception
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            // leitura do arquivo de Fatores Contribuintes 
            using (var fatores_stream = new StreamReader(caminho_csv_fator_contribuinte))
            {
                var leitor = new CsvReader(fatores_stream);
                IEnumerable<FatorContribuinte> fatores = leitor.GetRecords<FatorContribuinte>();

                //itera os registros, e os adiciona no dicionário
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
                //se há qualquer problema na leitura, mostra caixa de exception
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            //Cria a árvore B+ a ser utilizada no programa com os dados lidos dos arquivos CSV
            criaArvore(dicionario);
        } //lerCSV()

        /// <summary>
        /// Cria a árvore à partir dos dados lidos do CSV
        /// </summary>
        /// <param name="dicionario">Dados lidos do CSV</param>
        /// <returns>Indica se houve erro (false) ou não (true) no processo</returns>
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
            //Erro, a árvore já existe!
            else return false;
                
            //Se não houve erros retorna true
            return true;
        } //criaArvore()

        /// <summary>
        /// Busca um valor específico na árvore
        /// </summary>
        /// <returns>Dados lidos da árvore</returns>
        public static List<DadosOcorrencia> buscaValor(string valor)
        {
            //Cria uma nova lista para retornar
            List<DadosOcorrencia> lista = new List<DadosOcorrencia>();

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
                    //Varre a árvore buscando o dado
                    foreach (KeyValuePair<int, DadosOcorrencia> par in tree)
                    {
                        if (par.Value.ocorrencia.localidade.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            lista.Add(par.Value);
                        }
                    }
                }
            }
            else
            {
                //Erro, a árvore não existe!
            }

            //Retorna a lista lida
            return lista;
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
    }//class
} //namespace
