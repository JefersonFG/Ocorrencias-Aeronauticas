using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    class Controlador
    {
        private static Dictionary<int, DadosOcorrencia> dic_dados_ocorrencia;

        public static void dicionarioInicial(Dictionary<int, DadosOcorrencia> dicionario)
        {
            dic_dados_ocorrencia = dicionario;
        } //dicionarioInicial()

        //pesquisa cidades que contenham esta localidade no nome
        public static List<DadosOcorrencia> pesquisaCidade(string localidade) 
        {

            List<DadosOcorrencia> lista = new List<DadosOcorrencia>();

            Ocorrencia ocorrencia;

            foreach (KeyValuePair<int, DadosOcorrencia> registro in dic_dados_ocorrencia)
            {
                ocorrencia = registro.Value.ocorrencia;
                if (ocorrencia.localidade.IndexOf(localidade, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lista.Add(registro.Value);
                }

            } //foreach


            return lista;
        } //pesquisaCidade()

        public static Dictionary<int, DadosOcorrencia> carregarDicionario(string caminho_pasta_com_csvs)
        {
            string caminho_ocorrencias = caminho_pasta_com_csvs + "ocorrencia.csv";
            string caminho_aeronaves = caminho_pasta_com_csvs + "aeronave.csv";
            string caminho_fatores = caminho_pasta_com_csvs + "fator_contribuinte.csv";

            return Persistencia.lerCSV(caminho_ocorrencias, caminho_aeronaves, caminho_fatores);
        } // carregarDicionario()

    } //class
}//namespace
