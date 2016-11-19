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
        //variáveis para testes de consistência.
        private string _diaOcorrencia;
        private string _horario;
        private string _diaPublicacao;
        private string _saidaPista;
        private string _diaExtracao;

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
        //public DateTime dia_ocorrencia { get; set; }

        public string dia_ocorrencia
        {
            get { return _diaOcorrencia.Equals("NULL") ? "Desconhecido" : _diaOcorrencia; }
            set { _diaOcorrencia = value; }
        }

        /// <summary>
        /// Horário da ocorrência no padrão UTC
        /// </summary>
        /// <value>
        /// Horário no formato hh:mm:ss
        /// </value>
        public string horario
        {
            get { return _diaOcorrencia.Equals("NULL") ? "Desconhecido" : _horario; }
            set { _horario = value; }
        }

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
        public string dia_publicacao
        {
            get { return _diaPublicacao.Equals("NULL") ? "Desconhecido" : _diaPublicacao; }
            set { _diaPublicacao = value; }
        }

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
        public string saida_pista
        {
            get { return _saidaPista.Equals("NULL") ? "Desconhecido" : _saidaPista; }
            set { _saidaPista = value; }
        }

        /// <summary>
        /// Dia da extração dos dados na base de dados do CENIPA
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        public string dia_extracao
        {
            get { return _diaExtracao.Equals("NULL") ? "Desconhecido" : _diaExtracao; }
            set { _diaExtracao = value; }
        }
    }
}
