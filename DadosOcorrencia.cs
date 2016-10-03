using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe que agrega os dados da ocorrência lida dos três arquivos, cada uma no seu objeto
    /// A classe será usada no dicionário que por sua vez será usado para ordenação dos dados
    /// Os dados podem ser ordenados pelo campo codigo_ocorrencia ou localidade
    /// </summary>
    public class DadosOcorrencia
    {
        /// <summary>
        /// Código de identificação de ocorrência, comum aos três ojetos
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Cidade / município onde houve a ocorrência, presente no objeto ocorrencia
        /// </summary>
        /// <value>
        /// String contendo o nome do município por extenso
        /// </value>
        public string localidade { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo aeronave.csv com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo Aeronave
        /// </value>
        public Aeronave aeronave { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo ocorrencia.csv com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo Ocorrencia
        /// </value>
        public Ocorrencia ocorrencia { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo fator_contribuinte.csv com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo FatorContribuinte
        /// </value>
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
