using System.Collections.Generic;
using System.IO;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe de controle no modelo MVC.
    /// </summary>
    class Controlador
    {    
        /// <summary>
        /// Pesquisa cidades que contenham esta localidade no nome  
        /// </summary>
        /// <param name="localidade">A localidade a ser buscada</param>
        /// <returns>Lista de ocorrência que ocorreram nessa localidade</returns>
        public static List<DadosOcorrencia> pesquisaCidade(string localidade) 
        {
            //Busca a localidade na árvore
            return Persistencia.buscaValor(localidade);
        } //pesquisaCidade()

        /// <summary>
        /// Verifica se os dados dos arquivos CSV já foram carregados na árvore B+, se não carrega
        /// </summary>
        /// <param name="caminho_pasta_com_csvs">Caminho para a pasta contendo os arquivos de dados CSV</param>
        public static void carregarDados(string caminho_pasta_com_csvs)
        {
            //Verifica se já foi gerada a árvore com os dados, se não lê os arquivos CSV e cria a árvore
            if (!File.Exists(Persistencia.path_btree))
            {
                string caminho_ocorrencias = caminho_pasta_com_csvs + "ocorrencia.csv";
                string caminho_aeronaves = caminho_pasta_com_csvs + "aeronave.csv";
                string caminho_fatores = caminho_pasta_com_csvs + "fator_contribuinte.csv";

                Persistencia.lerCSV(caminho_ocorrencias, caminho_aeronaves, caminho_fatores);
            }
        } // carregarDicionario()
    } //class
}//namespace
