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
        }

        public static List<DadosOcorrencia> pesquisaCidade(string localidade)
        {
            return null;
        } //pesquisaCidade(
    } //class
}//namespace
