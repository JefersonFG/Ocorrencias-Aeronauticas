using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe que agrega os dados da ocorrência lida dos três arquivos, cada uma no seu objeto.
    /// A classe será usada no dicionário que por sua vez será usado para ordenação dos dados.
    /// Os dados podem ser ordenados pelo campo codigo_ocorrencia ou localidade.
    /// </summary>
    [ProtoContract]
    public class DadosOcorrencia
    {
        /// <summary>
        /// Código de identificação de ocorrência, comum aos três objetos
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(1)]
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo aeronave.csv, com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo Aeronave
        /// </value>
        [ProtoMember(2)]
        public Aeronave aeronave { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo ocorrencia.csv, com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo Ocorrencia
        /// </value>
        [ProtoMember(3)]
        public Ocorrencia ocorrencia { get; set; }

        /// <summary>
        /// Objeto contendo os dados lidos do arquivo fator_contribuinte.csv, com o codigo_ocorrencia acima
        /// </summary>
        /// <value>
        /// Objeto do tipo FatorContribuinte
        /// </value>
        [ProtoMember(4)]
        public FatorContribuinte fator { get; set; }

        /// <summary>
        /// Construtor que inicializa uma nova instância de DadosOcorrência.
        /// </summary>
        /// <param name="codigo_ocorrencia">Código da Ocorrencia, para identificação.</param>
        /// <param name="aeronave">Informações sobre a aeronave.</param>
        /// <param name="ocorrencia">Informações sobre a ocorrencia.</param>
        /// <param name="fator">Informações sobre os fatores contribuintes.</param>
        public DadosOcorrencia(int codigo_ocorrencia, Aeronave aeronave, Ocorrencia ocorrencia, FatorContribuinte fator)
        {
            this.codigo_ocorrencia = codigo_ocorrencia;
            this.aeronave = aeronave;
            this.ocorrencia = ocorrencia;
            this.fator = fator;
        }

        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public DadosOcorrencia()
        {
            this.codigo_ocorrencia = 0;
            this.aeronave = null;
            this.ocorrencia = null;
            this.fator = null;
        }
    }
}
