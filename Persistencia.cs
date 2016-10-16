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
            DadosOcorrencia dado_existente;

            /* leitura do arquivo de Ocorrencias */
            leitor = new CsvLeitura(caminho_csv_ocorrencias);
            linha = new CsvLinha();
            leitor.LeLinha(linha); //pula a linha de colunas
            while (leitor.LeLinha(linha))
            {
                ocorrencia = new Ocorrencia();
                ocorrencia.codigo_ocorrencia = Convert.ToInt32(linha[0]);
                ocorrencia.classificacao = linha[1];
                ocorrencia.tipo = linha[2];
                ocorrencia.localidade = linha[3];
                ocorrencia.uf = linha[4];
                ocorrencia.pais = linha[5];
                ocorrencia.aerodromo = linha[6];
                ocorrencia.dia_ocorrencia = Convert.ToDateTime(linha[7]);
                ocorrencia.horario_utc = Convert.ToDateTime(linha[8]);
                ocorrencia.sera_investigada = linha[9];
                ocorrencia.comando_investigador = linha[10];
                ocorrencia.status_investigacao = linha[11];
                ocorrencia.numero_relatorio = linha[12];
                ocorrencia.relatorio_publicado = linha[13];
                ocorrencia.dia_publicacao = (linha[14] == "NULL" ? Convert.ToDateTime("01-01-1901") : Convert.ToDateTime(linha[14]));
                ocorrencia.quantidade_recomendacoes = (linha[15] == "NULL" ? 0 : Convert.ToInt32(linha[15]));
                ocorrencia.aeronaves_envolvidas = (linha[16] == "NULL" ? 0 : Convert.ToInt32(linha[16]));
                ocorrencia.saida_pista = (linha[17] == "NULL" ? 0 : Convert.ToInt32(linha[17]));
                ocorrencia.dia_extracao = Convert.ToDateTime(linha[18]);

                if (dicionario.TryGetValue(ocorrencia.codigo_ocorrencia, out dado_existente))
                {
                    dado_existente.ocorrencia = ocorrencia;
                }
                else
                {
                    dicionario.Add(ocorrencia.codigo_ocorrencia, new DadosOcorrencia(ocorrencia.codigo_ocorrencia, null, ocorrencia, null));
                }
            }//while

            leitor.Close();

            /* leitura do arquivo de Aeronaves */
            leitor = new CsvLeitura(caminho_csv_aeronaves);
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

                if (dicionario.TryGetValue(aeronave.codigo_ocorrencia, out dado_existente))
                {
                    dado_existente.aeronave = aeronave;
                }
                else
                {
                    dicionario.Add(aeronave.codigo_ocorrencia, new DadosOcorrencia(aeronave.codigo_ocorrencia, aeronave, null, null));
                }
            }//while

            leitor.Close();

            /* leitura do arquivo de Fatores Contribuintes */
            leitor = new CsvLeitura(caminho_csv_fator_contribuinte);
            linha = new CsvLinha();
            leitor.LeLinha(linha); //pula a linha de colunas
            while (leitor.LeLinha(linha))
            {
                fator_contribuinte = new FatorContribuinte();
                fator_contribuinte.codigo_fator = Convert.ToInt32(linha[0]);
                fator_contribuinte.codigo_ocorrencia = Convert.ToInt32(linha[1]);
                fator_contribuinte.fator = linha[2];
                fator_contribuinte.aspecto = linha[3];
                fator_contribuinte.condicionante = linha[4];
                fator_contribuinte.area = linha[5];
                //fator_contribuinte.nivel_contribuicao = linha[6];   //não é utilizado no csv
                fator_contribuinte.detalhe_fator = linha[6];
                fator_contribuinte.dia_extracao = Convert.ToDateTime(linha[7]);

                if (dicionario.TryGetValue(fator_contribuinte.codigo_ocorrencia, out dado_existente))
                {
                    dado_existente.fator = fator_contribuinte;
                }
                else
                {
                    dicionario.Add(fator_contribuinte.codigo_ocorrencia, new DadosOcorrencia(fator_contribuinte.codigo_ocorrencia, null, null, fator_contribuinte));
                }
            }//while

            leitor.Close();

            return dicionario;

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
