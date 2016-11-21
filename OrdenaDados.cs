using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocorrências_Aeronáuticas
{
    public enum TIPO_SORT { BUBBLE, INSERTION, QUICK, SHELL, MERGE, HEAP, RADIX, LINEAR, BINARY, INTERPOLATION, NTH };
    public enum TIPO_DADO_SORT { CODIGO_OCORRENCIA, LOCALIDADE };

    /// <summary>
    /// Funções para ordenamento de dados através de diversos algoritmos distintos - cada
    /// qual com suas vantagens e desvantagens.
    /// Permite que sejam realizados "benchmarks", através do OrdenaForm.
    /// 
    /// Baseado em códigos encontrados no link:
    /// http://www.codeproject.com/Articles/177363/Searching-and-Sorting-Algorithms-via-C
    /// </summary>
    public static class OrdenaDados
    {
        #region Bubble Sort
        /// <summary>
        /// Utiliza Bubble Sort.
        /// A chave é o código de ocorrência
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> bubbleSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada, bool crescente)
        {
            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < lista_ordenada.Count - 1; i++)
                {
                    if(crescente)
                    {
                        if (lista_ordenada[i].codigo_ocorrencia > lista_ordenada[i + 1].codigo_ocorrencia)
                        {
                            // Exchange elements
                            DadosOcorrencia temp = lista_ordenada[i];
                            lista_ordenada[i] = lista_ordenada[i + 1];
                            lista_ordenada[i + 1] = temp;
                            exchanges = true;
                        }
                    }
                    else
                    {
                        if (lista_ordenada[i].codigo_ocorrencia < lista_ordenada[i + 1].codigo_ocorrencia)
                        {
                            // Exchange elements
                            DadosOcorrencia temp = lista_ordenada[i];
                            lista_ordenada[i] = lista_ordenada[i + 1];
                            lista_ordenada[i + 1] = temp;
                            exchanges = true;
                        }
                    }//else
                    
                }//for
            } while (exchanges);

            return lista_ordenada;
        }

        /// <summary>
        /// Utiliza Bubble Sort.
        /// A chave é a localidade
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> bubbleSort_localidade(List<DadosOcorrencia> lista_desordenada, bool crescente)
        {
            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < lista_ordenada.Count - 1; i++)
                {
                    if(lista_ordenada[i].ocorrencia != null)
                    {
                        if(crescente)
                        {
                            if (lista_ordenada[i + 1].ocorrencia.localidade.CompareTo(lista_ordenada[i].ocorrencia.localidade) < 0)
                            {
                                // Exchange elements
                                DadosOcorrencia temp = lista_ordenada[i];
                                lista_ordenada[i] = lista_ordenada[i + 1];
                                lista_ordenada[i + 1] = temp;
                                exchanges = true;
                            }
                        }
                        else
                        {
                            if (lista_ordenada[i].ocorrencia.localidade.CompareTo(lista_ordenada[i + 1].ocorrencia.localidade) < 0)
                            {
                                // Exchange elements
                                DadosOcorrencia temp = lista_ordenada[i];
                                lista_ordenada[i] = lista_ordenada[i + 1];
                                lista_ordenada[i + 1] = temp;
                                exchanges = true;
                            }
                        }
                        
                    }//if
                }//for
            } while (exchanges);

            return lista_ordenada;
        }

        #endregion

        #region Insertion Sort
        /// <summary>
        /// Utiliza Insertion Sort.
        /// A chave é o código de ocorrência
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> insertionSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada, bool crescente)
        {
            int n = lista_desordenada.Count - 1;
            int i, j;

            DadosOcorrencia temp;

            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }

            for (i = 1; i <= n; ++i)
            {
                temp = lista_ordenada[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if(crescente)
                    {
                        if (temp.codigo_ocorrencia < lista_ordenada[j].codigo_ocorrencia)
                            lista_ordenada[j + 1] = lista_ordenada[j];
                        else break;
                    }
                    else
                    {
                        if (temp.codigo_ocorrencia > lista_ordenada[j].codigo_ocorrencia)
                            lista_ordenada[j + 1] = lista_ordenada[j];
                        else break;
                    }
                    
                }
                lista_ordenada[j + 1] = temp;
            }//for

            return lista_ordenada;
        }//insertionSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada, bool crescente) 

        /// <summary>
        /// Utiliza Insertion Sort.
        /// A chave é a localidade
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> insertionSort_localidade(List<DadosOcorrencia> lista_desordenada, bool crescente)
        {
            int n = lista_desordenada.Count - 1;
            int i, j;

            DadosOcorrencia temp;

            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }

            for (i = 1; i <= n; ++i)
            {
                temp = lista_ordenada[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if(crescente)
                    {
                        if (lista_ordenada[j].ocorrencia.localidade.CompareTo(temp.ocorrencia.localidade) > 0)
                            lista_ordenada[j + 1] = lista_ordenada[j];
                        else
                            break;
                    }
                    else
                    {
                        if (temp.ocorrencia.localidade.CompareTo(lista_ordenada[j].ocorrencia.localidade) > 0)
                            lista_ordenada[j + 1] = lista_ordenada[j];
                        else
                            break;
                    }
                    
                }
                lista_ordenada[j + 1] = temp;
            } //for

            return lista_ordenada;
        } //insertionSort_localidade(List<DadosOcorrencia> lista_desordenada, bool crescente)

        /*
        public static List<DadosOcorrencia> BinaryInsertionSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada)
        {
            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }

            for (int i = 1; i < lista_ordenada.Count; i++)
            {
                int low = 0;
                int high = i - 1;
                DadosOcorrencia temp = lista_ordenada[i];
                //Find
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (temp.codigo_ocorrencia < lista_ordenada[mid].codigo_ocorrencia)
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                //backward shift
                for (int j = i - 1; j >= low; j--)
                    lista_ordenada[j + 1] = lista_ordenada[j];
                lista_ordenada[low] = temp;
            }
            return lista_ordenada;
        }
        */
        #endregion

        #region Quick Sort
        /// <summary>
        /// Utiliza Quick Sort.
        /// A chave é o código de ocorrência
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> QSRM_Ocorrencia (List<DadosOcorrencia> listaDesordenada, bool crescente)
        {
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortOcorrencia(listaOrdenada, 0, listaOrdenada.Count - 1, crescente);
            return listaOrdenada;
        }

        /// <summary>
        /// Utiliza Quick Sort.
        /// A chave é a localidade
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> QSRM_Localizacao(List<DadosOcorrencia> listaDesordenada, bool crescente)
        {
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortLocalizacao(listaOrdenada, 0, listaOrdenada.Count - 1, crescente);
            return listaOrdenada;
        }

        /// <summary>
        /// Função auxiliar com chamada recursiva, que representa a "visão geral" do procedimento.
        /// É feita uma partição inicial, posteriormente refinada até chegar-se a uma lista ordenada.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        public static void RandomizedQuickSortOcorrencia(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            if (left < right)
            {
                int q = RandomizedPartitionOcorrencia(input, left, right, crescente);
                RandomizedQuickSortOcorrencia(input, left, q - 1, crescente);
                RandomizedQuickSortOcorrencia(input, q + 1, right, crescente);
            }
        }

        /// <summary>
        /// Função auxiliar com chamada recursiva, que representa a "visão geral" do procedimento.
        /// É feita uma partição inicial, posteriormente refinada até chegar-se a uma lista ordenada.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        public static void RandomizedQuickSortLocalizacao(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            if (left < right)
            {
                int q = RandomizedPartitionLocalizacao(input, left, right, crescente);
                RandomizedQuickSortLocalizacao(input, left, q - 1, crescente);
                RandomizedQuickSortLocalizacao(input, q + 1, right, crescente);
            }
        }

        /// <summary>
        /// Randomiza o pivô para posterior partição da lista.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int RandomizedPartitionOcorrencia(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosOcorrencia pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionOcorrencia(input, left, right, crescente);
        }

        /// <summary>
        /// Randomiza o pivô para posterior partição da lista.
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int RandomizedPartitionLocalizacao(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosOcorrencia pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionLocalizacao(input, left, right, crescente);
        }

        /// <summary>
        /// Efetivamente particiona a lista, para que o algoritmo funcione.
        /// Utiliza como chave o código de ocorrência
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int PartitionOcorrencia(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            DadosOcorrencia pivot = input[right];
            DadosOcorrencia temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if(crescente)
                {
                    if (input[j].codigo_ocorrencia <= pivot.codigo_ocorrencia)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                else
                {
                    if (input[j].codigo_ocorrencia >= pivot.codigo_ocorrencia)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }

        /// <summary>
        /// Efetivamente particiona a lista, para que o algoritmo funcione.
        /// Utiliza como chave a localização
        /// </summary>
        /// <param name="input">A lista desordenada.</param>
        /// <param name="left">Pivô esquerdo.</param>
        /// <param name="right">Pivô direito.</param>
        /// <param name="crescente">Se <c>true</c> [crescente].</param>
        /// <returns>Retorna um inteiro a ser utilizado como pivô nas chamadas recursivas.</returns>
        private static int PartitionLocalizacao(List<DadosOcorrencia> input, int left, int right, bool crescente)
        {
            DadosOcorrencia pivot = input[right];
            DadosOcorrencia temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if(crescente)
                {
                    if (pivot.ocorrencia.localidade.CompareTo(input[j].ocorrencia.localidade) >= 0)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                else
                {
                    if (input[j].ocorrencia.localidade.CompareTo(pivot.ocorrencia.localidade) >= 0)
                    {
                        temp = input[j];
                        input[j] = input[i];
                        input[i] = temp;
                        i++;
                    }
                }
                
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }
        #endregion

        #region Shell Sort

        /// <summary>
        /// Utiliza Shell Sort.
        /// A chave é o código de ocorrência
        /// 
        /// (NÃO É POSSÍVEL ESCOLHER A DIREÇÃO DO SORT)
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> ShellSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada)
        {
            int i, j;
            int increment = 4;

            DadosOcorrencia temp;

            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }

            while (increment > 0)
            {
                for (i = 0; i < lista_ordenada.Count; i++)
                {
                    j = i;
                    temp = lista_ordenada[i];

                    while ((j >= increment) && (lista_ordenada[j - increment].codigo_ocorrencia < temp.codigo_ocorrencia))
                    {
                        lista_ordenada[j] = lista_ordenada[j - increment];
                        j = j - increment;
                    }

                    lista_ordenada[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }

            return lista_ordenada;
        }

        /// <summary>
        /// Utiliza Shell Sort.
        /// A chave é a localização
        /// 
        /// (NÃO É POSSÍVEL ESCOLHER A DIREÇÃO DO SORT)
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> ShellSort_localidade(List<DadosOcorrencia> lista_desordenada)
        {
            int i, j;
            int increment = 4;

            DadosOcorrencia temp;

            List<DadosOcorrencia> lista_ordenada = new List<DadosOcorrencia>();
            foreach (DadosOcorrencia dados_ocorrencia in lista_desordenada)
            {
                lista_ordenada.Add(dados_ocorrencia);
            }

            while (increment > 0)
            {
                for (i = 0; i < lista_ordenada.Count; i++)
                {
                    j = i;
                    temp = lista_ordenada[i];

                    while ((j >= increment) && (lista_ordenada[j - increment].ocorrencia.localidade.CompareTo(temp.ocorrencia.localidade) < 0))
                    {
                        lista_ordenada[j] = lista_ordenada[j - increment];
                        j = j - increment;
                    }

                    lista_ordenada[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }

            return lista_ordenada;
        }
        #endregion

        #region Merge Sort (NÃO FUNCIONA)

        public static List<DadosOcorrencia> MGST_Ocorrencia (List<DadosOcorrencia> listaDesordenada)
        {
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;
            MergeSort(listaOrdenada, 0, listaOrdenada.Count - 1);
            return listaOrdenada;
        }

        public static void MergeSort(List<DadosOcorrencia> x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(x, left, middle);
                MergeSort(x, middle + 1, right);
                Merge(x, left, middle, middle + 1, right);
            }
        }

        public static void Merge(List<DadosOcorrencia> x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            List<DadosOcorrencia> temp = new List<DadosOcorrencia>();
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left].codigo_ocorrencia <= x[middle1].codigo_ocorrencia)
                    temp.Add(x[left++]);
                else
                    temp.Add(x[middle1++]);
            }
            if (left > middle)
                for (int j = middle1; j <= right; j++)
                    temp.Add(x[middle1++]);
            else
                for (int j = left; j <= middle; j++)
                    temp.Add(x[left++]);
            //temp.CopyTo(0, x.ToArray(), oldPosition, size);
            temp.AddRange(x);
            x = temp;
        }

        /*
        public static void MergeSort(ref int[] x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(ref x, left, middle);
                MergeSort(ref x, middle + 1, right);
                Merge(ref x, left, middle, middle + 1, right);
            }
        }

        public static void Merge(ref int[] x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left] <= x[middle1])
                    temp[i++] = x[left++];
                else
                    temp[i++] = x[middle1++];
            }
            if (left > middle)
                for (int j = middle1; j <= right; j++)
                    temp[i++] = x[middle1++];
            else
                for (int j = left; j <= middle; j++)
                    temp[i++] = x[left++];
            Array.Copy(temp, 0, x, oldPosition, size);
        }
        */
        #endregion

        #region Heap Sort
        /// <summary>
        /// Utiliza Heap Sort.
        /// A chave é o código de ocorrência
        /// 
        /// (NÃO É POSSÍVEL ESCOLHER A DIREÇÃO DO SORT)
        /// </summary>
        /// <param name="listaDesordenada">A lista desordenada.</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> HeapsortOcorrencia(List<DadosOcorrencia> listaDesordenada)
        {
            int i;
            DadosOcorrencia temp;
            int n = listaDesordenada.Count - 1;
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDownOcorrencia(listaOrdenada, i, n);
            }

            for (i = n; i >= 1; i--)
            {
                temp = listaOrdenada[0];
                listaOrdenada[0] = listaOrdenada[i];
                listaOrdenada[i] = temp;
                siftDownOcorrencia(listaOrdenada, 0, i - 1);
            }
            return listaOrdenada;
        }

        /// <summary>
        /// Função auxiliar, que faz o procedimento de "sift-down" do algoritmo.
        /// A chave é o código de ocorrência
        /// </summary>
        /// <param name="inputList">A lista desordenada.</param>
        /// <param name="root">A raíz da árvore.</param>
        /// <param name="bottom">A folha da árvore.</param>
        public static void siftDownOcorrencia(List<DadosOcorrencia> inputList, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            DadosOcorrencia temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (inputList[root * 2].codigo_ocorrencia < inputList[root * 2 + 1].codigo_ocorrencia)
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (inputList[root].codigo_ocorrencia > inputList[maxChild].codigo_ocorrencia)
                {
                    temp = inputList[root];
                    inputList[root] = inputList[maxChild];
                    inputList[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }

        /// <summary>
        /// Utiliza Heap Sort.
        /// A chave é a localização
        /// 
        /// (NÃO É POSSÍVEL ESCOLHER A DIREÇÃO DO SORT)
        /// </summary>
        /// <param name="lista_desordenada">A lista desordenada.</param>
        /// <returns>Retorna a lista devidamente ordenada.</returns>
        public static List<DadosOcorrencia> HeapsortLocalizacao(List<DadosOcorrencia> listaDesordenada)
        {
            int i;
            DadosOcorrencia temp;
            int n = listaDesordenada.Count - 1;
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDownLocalizacao(listaOrdenada, i, n);
            }

            for (i = n; i >= 1; i--)
            {
                temp = listaOrdenada[0];
                listaOrdenada[0] = listaOrdenada[i];
                listaOrdenada[i] = temp;
                siftDownLocalizacao(listaOrdenada, 0, i - 1);
            }
            return listaOrdenada;
        }

        /// <summary>
        /// Função auxiliar, que faz o procedimento de "sift-down" do algoritmo.
        /// A chave é a localização
        /// </summary>
        /// <param name="inputList">A lista desordenada.</param>
        /// <param name="root">A raíz da árvore.</param>
        /// <param name="bottom">A folha da árvore.</param>
        public static void siftDownLocalizacao(List<DadosOcorrencia> inputList, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            DadosOcorrencia temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (inputList[root * 2].ocorrencia.localidade.CompareTo(inputList[root * 2 + 1].ocorrencia.localidade) < 0)
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (inputList[root].ocorrencia.localidade.CompareTo(inputList[maxChild].ocorrencia.localidade) > 0)
                {
                    temp = inputList[root];
                    inputList[root] = inputList[maxChild];
                    inputList[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        #endregion

        #region Radix Sort (NÃO FUNCIONA)

        //RadixSort takes an array and the number of bits used as 
        //the key in each iteration.
        public static void RadixSort(ref int[] x, int bits)
        {
            //Use an array of the same size as the original array 
            //to store the result of each iteration.
            int[] b = new int[x.Length];
            int[] b_orig = b;

            //Mask is the bitmask used to extract the sort key. 
            //We start with the bits least significant bits and
            //left-shift it the same amount at each iteration. 
            //When all the bits are shifted out of the word, we are done.
            int rshift = 0;
            for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
            {
                //An array is needed to store the count for each key value.
                int[] cntarray = new int[1 << bits];

                //Count each key value
                for (int p = 0; p < x.Length; ++p)
                {
                    int key = (x[p] & mask) >> rshift;
                    ++cntarray[key];
                }

                //Sum up how many elements there are with lower 
                //key values, for each key.
                for (int i = 1; i < cntarray.Length; ++i)
                    cntarray[i] += cntarray[i - 1];

                //The values in cntarray are used as indexes 
                //for storing the values in b. b will then be
                //completely sorted on this iteration's key. 
                //Elements with the same key value are stored 
                //in their original internal order.
                for (int p = x.Length - 1; p >= 0; --p)
                {
                    int key = (x[p] & mask) >> rshift;
                    --cntarray[key];
                    b[cntarray[key]] = x[p];
                }

                //Swap the a and b references, so that the 
                //next iteration works on the current b, 
                //which is now partially sorted.
                int[] temp = b; b = x; x = temp;
            }
        }
        #endregion
    }
}
