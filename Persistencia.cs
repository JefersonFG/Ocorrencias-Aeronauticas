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
        public static void inicializaResultados()
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
    }
}
