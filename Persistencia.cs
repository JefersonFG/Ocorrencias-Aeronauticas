using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    class Persistencia
    {
        public static void escreveResultado(string algoritmo, string tipo_dado, int tamanho_array, double tempo_decorrido)
        {
            StreamWriter sw = new StreamWriter("resultados_Aerosafe.txt");

            string resultado = algoritmo + ", " + tipo_dado + ", " + tamanho_array + ", " + tempo_decorrido;

            sw.WriteLine(resultado);
        }
    }
}
