using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe contendo as informações da aeronave envolvida na ocorrência, lidas do arquivo aeronave.csv
    /// O campo chave é codigo_ocorrencia
    /// </summary>
    public class Aeronave
    {
        /// <summary>
        /// Código de identificação de aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_aeronave { get; set; }

        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Matrícula da aeronave
        /// </summary>
        /// <value>
        /// Código de cinco dígitos numéricos
        /// </value>
        public string matricula { get; set; }

        /// <summary>
        /// Código de identificação do operador
        /// </summary>
        /// <value>
        /// Código numérico de até 11 dígitos
        /// </value>
        public int codigo_operador { get; set; }

        /// <summary>
        /// Tipo da aeronave
        /// </summary>
        /// <value>
        /// AVIÃO ou HELICÓPTERO
        /// </value>
        public string equipamento { get; set; }

        /// <summary>
        /// Fabricante da aeronave
        /// </summary>
        /// <value>
        /// Nome da fabricante por extenso
        /// </value>
        public string fabricante { get; set; }

        /// <summary>
        /// Modelo da aeronave
        /// </summary>
        /// <value>
        /// Código alfanumérico da aeronave
        /// </value>
        public string modelo { get; set; }

        /// <summary>
        /// Tipo de motor da aeronave
        /// </summary>
        /// <value>
        /// PISTÃO, JATO, TURBOEIXO ou TURBOHÉLICE
        /// </value>
        public string tipo_motor { get; set; }

        /// <summary>
        /// Quantidade de motores da aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int quantidade_motores { get; set; }

        /// <summary>
        /// Peso máximo para decolagem
        /// </summary>
        /// <value>
        /// Valor em kg
        /// </value>
        public float peso_maximo_decolagem { get; set; }

        /// <summary>
        /// Quantidade de assentos na aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int quantidade_assentos { get; set; }

        /// <summary>
        /// Ano de fabricação da aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int ano_fabricacao { get; set; }

        /// <summary>
        /// País de registro da aeronave
        /// </summary>
        /// <value>
        /// Nome do país por extenso
        /// </value>
        public string pais_registro { get; set; }

        /// <summary>
        /// Categoria de registro da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// Código de até quatro caracteres
        /// </value>
        public string categoria_registro { get; set; }

        /// <summary>
        /// Categoria de aviação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// INSTRUÇÃO, PARTICULAR, REGULAR, TÁXI AÉREO, ADMINISTRAÇÃO DIRETA ou MÚLTIPLA
        /// </value>
        public string categoria_aviacao { get; set; }

        /// <summary>
        /// Origem de vôo da aeronave
        /// </summary>
        /// <value>
        /// Código de origem de vôo, de quatro caracteres
        /// </value>
        public string origem_voo { get; set; }

        /// <summary>
        /// Destino de vôo da aeronave
        /// </summary>
        /// <value>
        /// Código de destino do vôo, de quatro caracteres
        /// </value>
        public string destino_voo { get; set; }

        /// <summary>
        /// Fase de operação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// Fase de operação escrita por extenso
        /// </value>
        public string fase_operacao { get; set; }

        /// <summary>
        /// Tipo de operação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// INSTRUÇÃO, TAXI AÉREO, PRIVADA, REGULAR, POLICIAL ou AGRÍCOLA
        /// </value>
        public string tipo_operacao { get; set; }

        /// <summary>
        /// Nível do dano da aeronave
        /// </summary>
        /// <value>
        /// SUBSTANCIAL, LEVE, NENHUM ou DESTRUÍDA
        /// </value>
        public string nivel_dano { get; set; }

        /// <summary>
        /// Quantidade de fatalidades (mortos) na aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        public int quantidade_fatalidades { get; set; }

        /// <summary>
        /// Dia da extração dos dados na base de dados do CENIPA
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        public DateTime dia_extracao { get; set; }
    }
}
