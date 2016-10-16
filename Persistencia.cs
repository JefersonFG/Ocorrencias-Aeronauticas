using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    public static class Persistencia
    {
        public static Dictionary<int, DadosOcorrencia> lerCSV(string caminho_csv_ocorrencias, 
                                                                string caminho_csv_aeronaves,
                                                                string caminho_csv_fator_contribuinte) 
        {
            CsvLinha linha;
            CsvLeitura leitor;

            Ocorrencia ocorrencia;
            Aeronave aeronave;
            FatorContribuinte fator_contribuinte;

            Dictionary<int, DadosOcorrencia> dicionario = new Dictionary<int, DadosOcorrencia>();

            /* leitura do arquivo de Ocorrencias */
            leitor = new CsvLeitura(caminho_csv_ocorrencias);
            linha = new CsvLinha();
            leitor.LeLinha(linha); //pula a linha de colunas
            while (leitor.LeLinha(linha))
            {
                aeronave = new Aeronave();
                aeronave.codigo_aeronave = Convert.ToInt32(linha[0]);
                aeronave.codigo_ocorrencia = Convert.ToInt32(linha[1]);
                aeronave.matricula = linha[2];
                aeronave.codigo_operador = (linha[3] == "NULL" ? 0 : Convert.ToInt32(linha[3]));
                aeronave.equipamento = linha[4];
                aeronave.fabricante = linha[5];
                aeronave.modelo = linha[6];
                aeronave.tipo_motor = linha[7];
                aeronave.quantidade_motores = (linha[8] == "NULL" ? 0 : Convert.ToInt32(linha[8]));
                aeronave.peso_maximo_decolagem = (linha[9] == "NULL" ? 0 : Convert.ToSingle(linha[9]));
                aeronave.quantidade_assentos = (linha[10] == "NULL" ? 0 : Convert.ToInt32(linha[10]));
                aeronave.ano_fabricacao = (linha[11] == "NULL" ? 0 : Convert.ToInt32(linha[11]));
                aeronave.pais_registro = linha[12];
                aeronave.categoria_registro = linha[13];
                aeronave.categoria_aviacao = linha[14];
                aeronave.origem_voo = linha[15];
                aeronave.destino_voo = linha[16];
                aeronave.fase_operacao = linha[17];
                aeronave.tipo_operacao = linha[18];
                aeronave.nivel_dano = linha[19];
                aeronave.quantidade_fatalidades = (linha[20] == "NULL" ? 0 : Convert.ToInt32(linha[20]));
                aeronave.dia_extracao = Convert.ToDateTime(linha[21]);


            }

            leitor.Close();

        } //lerCSV()

        public static void escreverResultados(TIPO_SORT tipo_sort, TIPO_DADO_SORT tipo_dado_sort, int qtde_dados, float tempo_ms)
        {

        } //escreverResultados()

        /*public static void inicializaResultados()
        {
            File.WriteAllText("../../resultados_Aerosafe.txt", string.Empty);
        }

        public static void escreveResultado(string resultado)
        {
            using (StreamWriter sw = new StreamWriter("../../resultados_Aerosafe.txt", true))
            {
                sw.WriteLine(resultado);
            }
        } */
    }//class
} //namespace
