using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CsvHelper;

//código: http://www.codeproject.com/Articles/415732/Reading-and-Writing-CSV-Files-in-Csharp
//malandragem, maluco.

namespace Ocorrências_Aeronáuticas
{
    /// <summary>
    /// Classe para armazenar uma linha do CSV
    /// </summary>
    public class CsvLinha : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Classe para escrever dados em um CSV
    /// </summary>
    public class CsvEscrita : StreamWriter
    {
        public CsvEscrita(Stream stream)
            : base(stream)
        {
        }

        public CsvEscrita(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Escreve uma única linha no CSV
        /// </summary>
        /// <param name="linha">A linha a ser escrita</param>
        public void EscreveLinha(CsvLinha linha)
        {
            StringBuilder builder = new StringBuilder();
            bool firstColumn = true;
            foreach (string value in linha)
            {
                // Separa se não é o primeiro valor
                if (!firstColumn)
                    builder.Append(',');
                // Como lidar com valores que incluem vírgulas ou aspas?
                // Bota dentro de aspas e adapta o que for necessário
                if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                else
                    builder.Append(value);
                firstColumn = false;
            }
            linha.LineText = builder.ToString();
            WriteLine(linha.LineText);
        }
    }

    /// <summary>
    /// Classe para ler dados de um CSV
    /// </summary>
    public class CsvLeitura : StreamReader
    {
        public CsvLeitura(Stream stream)
            : base(stream)
        {
        }

        public CsvLeitura(string filename)
            : base(filename)
        {
        }

        /// <summary>
        /// Lê uma linha do CSV
        /// </summary>
        /// <param name="linha">A linha a ser lida</param>
        /// <returns>
        /// Retorna verdadeiro se uma coluna foi lida, falso caso contrário
        /// </returns>
        public bool LeLinha(CsvLinha linha)
        {
            linha.LineText = ReadLine();
            if (String.IsNullOrEmpty(linha.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < linha.LineText.Length)
            {
                string value;

                // Como lidar com aspas?
                if (linha.LineText[pos] == '"')
                {
                    // Pula a "aspa inicial"
                    pos++;

                    // Interpreta o resto
                    int start = pos;
                    while (pos < linha.LineText.Length)
                    {
                        // Testa as próximas aspas
                        if (linha.LineText[pos] == '"')
                        {
                            // Achou uma
                            pos++;

                            // Se tiver duas aspas juntas, fica só com uma delas
                            // Caso contrário, significa o fim do dado lido
                            if (pos >= linha.LineText.Length || linha.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = linha.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    // Interpreta o que tiver sem aspas
                    int start = pos;
                    while (pos < linha.LineText.Length && linha.LineText[pos] != ',')
                        pos++;
                    value = linha.LineText.Substring(start, pos - start);
                }

                // Adiciona o campo à lista
                if (rows < linha.Count)
                    linha[rows] = value;
                else
                    linha.Add(value);
                rows++;

                // Pega todo resto, até a vírgula inclusive
                while (pos < linha.LineText.Length && linha.LineText[pos] != ',')
                    pos++;
                if (pos < linha.LineText.Length)
                    pos++;
            }
            // Deleta o que não foi usado
            while (linha.Count > rows)
                linha.RemoveAt(rows);

            // Retorna verdadeiro se uma coluna (?) inteira foi lida
            return (linha.Count > 0);
        }
    }

    
}