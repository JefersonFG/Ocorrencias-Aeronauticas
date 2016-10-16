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
    } //class
}//namespace
