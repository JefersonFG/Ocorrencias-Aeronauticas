using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    class DadosOcorrencia
    {
        public int codigo_ocorrencia { get; set; }
        public Aeronave aeronave { get; set; }
        public Ocorrencia ocorrencia { get; set; }
        public FatorContribuinte fator { get; set; }
    }
}
