using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe contendo as informações dos fatores contribuintes envolvidos com a ocorrência, lidas do arquivo
    /// fator_contribuinte.csv.
    /// O campo chave é codigo_ocorrencia.
    /// </summary>
    [ProtoContract]
    public class FatorContribuinte
    {
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (dia_extracao)
        /// </summary>
        private string _diaExtracao;

        /// <summary>
        /// Código de identificação do fator contribuinte
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(1)]
        public int codigo_fator { get; set; }

        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(2)]
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Fator contribuinte para a ocorrência
        /// </summary>
        /// <value>
        /// Descrição do fator por extenso
        /// </value>
        [ProtoMember(3)]
        public string fator { get; set; }

        /// <summary>
        /// Aspecto do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição do aspecto por extenso
        /// </value>
        [ProtoMember(4)]
        public string aspecto { get; set; }

        /// <summary>
        /// Condicionante do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição do condicionante por extenso
        /// </value>
        [ProtoMember(5)]
        public string condicionante { get; set; }

        /// <summary>
        /// Área do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição da área por extenso
        /// </value>
        [ProtoMember(6)]
        public string area { get; set; }

        /// <summary>
        /// Nível de contribuição do fator contribuinte
        /// 
        /// OBS: NÃO APARECE NO CSV!!
        /// </summary>
        /// <value>
        /// Descrição da contribuição por extenso
        /// </value>
        /// [ProtoMember(10)]
        //public string nivel_contribuicao { get; set; }

        /// <summary>
        /// Detalhe do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição dos detalhes do fator por extenso
        /// </value>
        [ProtoMember(7)]
        public string detalhe_fator { get; set; }

        /// <summary>
        /// Dia da extração dos dados na base de dados do CENIPA.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        [ProtoMember(8)]
        public string dia_extracao
        {
            get { return _diaExtracao.Equals("NULL") ? "Desconhecido" : _diaExtracao; }
            set { _diaExtracao = value; }
        }
    }
}
