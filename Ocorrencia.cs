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
    public class Ocorrencia
    {
        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Classificação da ocorrência
        /// </summary>
        /// <value>
        /// ACIDENTE ou INCIDENTE GRAVE
        /// </value>
        public string classificacao { get; set; }

        /// <summary>
        /// Tipo da ocorrência
        /// </summary>
        /// <value>
        /// Caracterização da ocorrência, resumo do ocorrido
        /// </value>
        public string tipo { get; set; }

        /// <summary>
        /// Cidade / município onde houve a ocorrência
        /// </summary>
        /// <value>
        /// Nome do município por extenso
        /// </value>
        public string localidade { get; set; }

        /// <summary>
        /// Estado / província onde houve a ocorrência
        /// </summary>
        /// <value>
        /// Sigla do estado
        /// </value>
        public string uf { get; set; }

        /// <summary>
        /// País onde houve a ocorrência
        /// </summary>
        /// <value>
        /// Nome do país por extenso
        /// </value>
        public string pais { get; set; }

        /// <summary>
        /// Código ICAO do aeródromo onde houve a ocorrência
        /// </summary>
        /// <value>
        /// Código de 4 caracteres
        /// </value>
        public string aerodromo { get; set; }

        /// <summary>
        /// Data da ocorrência
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        public DateTime dia_ocorrencia { get; set; }

        /// <summary>
        /// Horário da ocorrência no padrão UTC
        /// </summary>
        /// <value>
        /// Horário no formato hh:mm:ss
        /// </value>
        public DateTime horario_utc { get; set; }

        /// <summary>
        /// Informação se a ocorrência será ou não investigada
        /// </summary>
        /// <value>
        /// SIM ou NÃO
        /// </value>
        public string sera_investigada { get; set; }

        /// <summary>
        /// Comando investigador responsável pela ocorrência
        /// </summary>
        /// <value>
        /// Identificação do comando investigador
        /// </value>
        public string comando_investigador { get; set; }

        /// <summary>
        /// Informação se a investigação está ativa ou finalizada
        /// </summary>
        /// <value>
        /// ATIVA ou FINALIZADA
        /// </value>
        public string status_investigacao { get; set; }

        /// <summary>
        /// Número de identificação do relatório final de investigação
        /// </summary>
        /// <value>
        /// Identificação do relatório, até 50 caracteres
        /// </value>
        public string numero_relatorio { get; set; }

        /// <summary>
        /// Informação se o relatório final de investigação foi ou não publicado
        /// </summary>
        /// <value>
        /// Se afirmativo 1, caso contrário 0
        /// </value>
        public string relatorio_publicado { get; set; }

        /// <summary>
        /// Dia da publicação do relatório final de investigação
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        public DateTime dia_publicacao { get; set; }

        /// <summary>
        /// Quantidade de recomendações de segurança emitidas
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int quantidade_recomendacoes { get; set; }

        /// <summary>
        /// Quantidade de aeronaves envolvidas na ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int aeronaves_envolvidas { get; set; }

        /// <summary>
        /// Informação se houve ou não saída de pista na ocorrência
        /// </summary>
        /// <value>
        /// Se afirmativo 1, caso contrário 0
        /// </value>
        public int saida_pista { get; set; }

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
        /// <returns>Objeto do tipo Ocorrência</returns>
        public Ocorrencia fromCSV(CsvLinha linha)
        {
            this.codigo_ocorrencia = Convert.ToInt32(linha[0]);
            this.classificacao = linha[1];
            this.tipo = linha[2];
            this.localidade = linha[3];
            this.uf = linha[4];
            this.pais = linha[5];
            this.aerodromo = linha[6];
            this.dia_ocorrencia = Convert.ToDateTime(linha[7]);
            this.horario_utc = Convert.ToDateTime(linha[8]);
            this.sera_investigada = linha[9];
            this.comando_investigador = linha[10];
            this.status_investigacao = linha[11];
            this.numero_relatorio = linha[12];
            this.relatorio_publicado = linha[13];
            this.dia_publicacao = (linha[14] == "NULL" ? Convert.ToDateTime("01-01-1901") : Convert.ToDateTime(linha[14]));
            this.quantidade_recomendacoes = (linha[15] == "NULL" ? 0 : Convert.ToInt32(linha[15]));
            this.aeronaves_envolvidas = (linha[16] == "NULL" ? 0 : Convert.ToInt32(linha[16]));
            this.saida_pista = (linha[17] == "NULL" ? 0 : Convert.ToInt32(linha[17]));
            this.dia_extracao = Convert.ToDateTime(linha[18]);
            return this;
        }
    }
}
