using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    public static class Persistencia
    {
        public static Dictionary<int, DadosOcorrencia> lerCSV(string caminho_arquivo)
        {
            return null;
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
