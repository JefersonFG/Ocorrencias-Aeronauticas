using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    public class DadosOcorrencia
    {
        public int codigo_ocorrencia { get; set; }
        public Aeronave aeronave { get; set; }
        public Ocorrencia ocorrencia { get; set; }
        public FatorContribuinte fator { get; set; }

        public DadosOcorrencia(int codigo_ocorrencia, Aeronave aeronave, Ocorrencia ocorrencia, FatorContribuinte fator)
        {
            this.codigo_ocorrencia = codigo_ocorrencia;
            this.aeronave = aeronave;
            this.ocorrencia = ocorrencia;
            this.fator = fator;
        }
        
    }
}
