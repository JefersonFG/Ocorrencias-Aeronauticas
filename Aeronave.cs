using ProtoBuf;

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe contendo as informações da aeronave envolvida na ocorrência, lidas do arquivo aeronave.csv
    /// O campo chave é codigo_ocorrencia
    /// </summary>
    [ProtoContract]
    public class Aeronave
    {
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (dia_extracao)
        /// </summary>
        private string _diaExtracao;
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (quantidade_fatalidades)
        /// </summary>
        private string _qtdFatalidades;
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (quantidade_motores)
        /// </summary>
        private string _qtdMotores;
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (peso_maximo_decolagem)
        /// </summary>
        private string _pesoMaximo;
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (quantidade_assentos)
        /// </summary>
        private string _qtdAssentos;
        /// <summary>
        /// Variável para testes de consistência. Evita que dados não esperados
        /// sejam lidos.
        /// (ano_fabricacao)
        /// </summary>
        private string _anoFabricacao;

        /// <summary>
        /// Código de identificação de aeronave
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(1)]
        public int codigo_aeronave { get; set; }

        /// <summary>
        /// Código de identificação de ocorrência
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(2)]
        public int codigo_ocorrencia { get; set; }

        /// <summary>
        /// Matrícula da aeronave
        /// </summary>
        /// <value>
        /// Código de cinco dígitos numéricos
        /// </value>
        [ProtoMember(3)]
        public string matricula { get; set; }

        /// <summary>
        /// Código de identificação do operador
        /// </summary>
        /// <value>
        /// Código numérico de até 11 dígitos
        /// </value>
        [ProtoMember(4)]
        public int codigo_operador { get; set; }

        /// <summary>
        /// Tipo da aeronave
        /// </summary>
        /// <value>
        /// AVIÃO ou HELICÓPTERO
        /// </value>
        [ProtoMember(5)]
        public string equipamento { get; set; }

        /// <summary>
        /// Fabricante da aeronave
        /// </summary>
        /// <value>
        /// Nome da fabricante por extenso
        /// </value>
        [ProtoMember(6)]
        public string fabricante { get; set; }

        /// <summary>
        /// Modelo da aeronave
        /// </summary>
        /// <value>
        /// Código alfanumérico da aeronave
        /// </value>
        [ProtoMember(7)]
        public string modelo { get; set; }

        /// <summary>
        /// Tipo de motor da aeronave
        /// </summary>
        /// <value>
        /// PISTÃO, JATO, TURBOEIXO ou TURBOHÉLICE
        /// </value>
        [ProtoMember(8)]
        public string tipo_motor { get; set; }

        /// <summary>
        /// Quantidade de motores da aeronave.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(9)]
        public string quantidade_motores
        {
            get { return _qtdMotores.Equals("NULL") ? "Desconhecido" : _qtdMotores; }
            set { _qtdMotores = value; }
        }

        /// <summary>
        /// Peso máximo para decolagem.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Valor em kg
        /// </value>
        [ProtoMember(10)]
        public string peso_maximo_decolagem
        {
            get { return _pesoMaximo.Equals("NULL") ? "Desconhecido" : _pesoMaximo; }
            set { _pesoMaximo = value; }
        }

        /// <summary>
        /// Quantidade de assentos na aeronave.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(11)]
        public string quantidade_assentos
        {
            get { return _qtdAssentos.Equals("NULL") ? "Desconhecido" : _qtdAssentos; }
            set { _qtdAssentos = value; }
        }

        /// <summary>
        /// Ano de fabricação da aeronave.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(12)]
        public string ano_fabricacao
        {
            get { return _anoFabricacao.Equals("NULL") ? "Desconhecido" : _anoFabricacao; }
            set { _anoFabricacao = value; }
        }

        /// <summary>
        /// País de registro da aeronave.
        /// </summary>
        /// <value>
        /// Nome do país por extenso
        /// </value>
        [ProtoMember(13)]
        public string pais_registro { get; set; }

        /// <summary>
        /// Categoria de registro da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// Código de até quatro caracteres
        /// </value>
        [ProtoMember(14)]
        public string categoria_registro { get; set; }

        /// <summary>
        /// Categoria de aviação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// INSTRUÇÃO, PARTICULAR, REGULAR, TÁXI AÉREO, ADMINISTRAÇÃO DIRETA ou MÚLTIPLA
        /// </value>
        [ProtoMember(15)]
        public string categoria_aviacao { get; set; }

        /// <summary>
        /// Origem de vôo da aeronave
        /// </summary>
        /// <value>
        /// Código de origem de vôo, de quatro caracteres
        /// </value>
        [ProtoMember(16)]
        public string origem_voo { get; set; }

        /// <summary>
        /// Destino de vôo da aeronave
        /// </summary>
        /// <value>
        /// Código de destino do vôo, de quatro caracteres
        /// </value>
        [ProtoMember(17)]
        public string destino_voo { get; set; }

        /// <summary>
        /// Fase de operação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// Fase de operação escrita por extenso
        /// </value>
        [ProtoMember(18)]
        public string fase_operacao { get; set; }

        /// <summary>
        /// Tipo de operação da aeronave no momento da ocorrência
        /// </summary>
        /// <value>
        /// INSTRUÇÃO, TAXI AÉREO, PRIVADA, REGULAR, POLICIAL ou AGRÍCOLA
        /// </value>
        [ProtoMember(19)]
        public string tipo_operacao { get; set; }

        /// <summary>
        /// Nível do dano da aeronave
        /// </summary>
        /// <value>
        /// SUBSTANCIAL, LEVE, NENHUM ou DESTRUÍDA
        /// </value>
        [ProtoMember(20)]
        public string nivel_dano { get; set; }

        /// <summary>
        /// Quantidade de fatalidades (mortos) na aeronave.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Valor inteiro
        /// </value>
        [ProtoMember(21)]
        public string quantidade_fatalidades
        {
            get { return _qtdFatalidades.Equals("NULL") ? "0" : _qtdFatalidades; }
            set { _qtdFatalidades = value; }
        }

        /// <summary>
        /// Dia da extração dos dados na base de dados do CENIPA.
        /// Lida como string para evitar inconsistências.
        /// </summary>
        /// <value>
        /// Data no formato dd/mm/aaaa
        /// </value>
        [ProtoMember(22)]
        public string dia_extracao
        {
            get { return _diaExtracao.Equals("NULL") ? "Desconhecido" : _diaExtracao; }
            set { _diaExtracao = value; }
        }
    }
}
