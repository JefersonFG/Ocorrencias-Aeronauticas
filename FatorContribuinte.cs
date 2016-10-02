using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe contendo as informações dos fatores contribuintes envolvidos com a ocorrência, lidas do arquivo fator_contribuinte.csv
    /// O campo chave é codigo_ocorrencia
    /// </summary>
    public class FatorContribuinte
    {
        /// <summary>
        /// Código de identificação do fator contribuinte
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_fator { get; set; }

        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Fator contribuinte para a ocorrência
        /// </summary>
        /// <value>
        /// Descrição do fator por extenso
        /// </value>
        public string fator { get; set; }

        /// <summary>
        /// Aspecto do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição do aspecto por extenso
        /// </value>
        public string aspecto { get; set; }

        /// <summary>
        /// Condicionante do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição do condicionante por extenso
        /// </value>
        public string condicionante { get; set; }

        /// <summary>
        /// Área do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição da área por extenso
        /// </value>
        public string area { get; set; }

        /// <summary>
        /// Nível de contribuição do fator contribuinte
        /// 
        /// OBS: NÃO APARECE NO CSV
        /// </summary>
        /// <value>
        /// Descrição da contribuição por extenso
        /// </value>
        //public string nivel_contribuicao { get; set; }

        /// <summary>
        /// Detalhe do fator contribuinte
        /// </summary>
        /// <value>
        /// Descrição dos detalhes do fator por extenso
        /// </value>
        public string detalhe_fator { get; set; }

        /// <summary>
        /// Dia da extração dos dados na base de dados do CENIPA
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        public DateTime dia_extracao { get; set; }

        /// <summary>
        /// Preenche um objeto da classe a partir de uma linha lida do arquivo CSV.
        /// </summary>
        /// <param name="linha">Linha a ser lida</param>
        /// <returns>Objeto do tipo FatorContribuinte</returns>
        public FatorContribuinte fromCSV(CsvLinha linha)
        {
            this.codigo_fator = Convert.ToInt32(linha[0]);
            this.codigo_ocorrencia = Convert.ToInt32(linha[1]);
            this.fator = linha[2];
            this.aspecto = linha[3];
            this.condicionante = linha[4];
            this.area = linha[5];
            //this.nivel_contribuicao = linha[6];   //não é utilizado no csv
            this.detalhe_fator = linha[6];
            this.dia_extracao = Convert.ToDateTime(linha[7]);
            return this;
        }
    }
}
