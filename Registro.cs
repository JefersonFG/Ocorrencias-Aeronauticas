using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe contendo as informações da ocorrência, lidas do arquivo ocorrencias.csv
    /// O campo chave é codigo_ocorrencia
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_ocorrencia { get; set; }


        public Ocorrencia ocorrencia { get; set; }
        public Aeronave aeronave { get; set; }
        public FatorContribuinte fator_contribuinte { get; set;  }
    }
}
