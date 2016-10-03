using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//código: http://www.codeproject.com/Articles/177363/Searching-and-Sorting-Algorithms-via-C

namespace Ocorrências_Aeronáuticas
{
    public static class Sorting //mamãe
    {
        #region Bubble Sort
        public static List<DadosOcorrencia> bubbleSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada)
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
                    if (lista_ordenada[i].codigo_ocorrencia > lista_ordenada[i + 1].codigo_ocorrencia)
                    {
                        // Exchange elements
                        DadosOcorrencia temp = lista_ordenada[i];
                        lista_ordenada[i] = lista_ordenada[i + 1];
                        lista_ordenada[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);

            return lista_ordenada;
        }

        public static List<DadosOcorrencia> bubbleSort_localidade(List<DadosOcorrencia> lista_desordenada)
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
                        if (lista_ordenada[i].ocorrencia.localidade.CompareTo(lista_ordenada[i + 1].ocorrencia.localidade) > 0)
                        {
                            // Exchange elements
                            DadosOcorrencia temp = lista_ordenada[i];
                            lista_ordenada[i] = lista_ordenada[i + 1];
                            lista_ordenada[i + 1] = temp;
                            exchanges = true;
                        }
                    }
                }
            } while (exchanges);

            return lista_ordenada;
        }

        #endregion

        #region Insertion Sort
        public static List<DadosOcorrencia> InsertionSort_codigo_ocorrencia(List<DadosOcorrencia> lista_desordenada)
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
                    if (temp.codigo_ocorrencia < lista_ordenada[j].codigo_ocorrencia) lista_ordenada[j + 1] = lista_ordenada[j];
                    else break;
                }
                lista_ordenada[j + 1] = temp;
            }

            return lista_ordenada;
        }

        public static List<DadosOcorrencia> InsertionSort_localidade(List<DadosOcorrencia> lista_desordenada)
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
                    if (temp.ocorrencia.localidade.CompareTo(lista_ordenada[j].ocorrencia.localidade) < 0)
                        lista_ordenada[j + 1] = lista_ordenada[j];
                    else
                        break;
                }
                lista_ordenada[j + 1] = temp;
            }

            return lista_ordenada;
        }


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

        #endregion

        #region Quick Sort

        public static List<DadosOcorrencia> QSRM_Ocorrencia (List<DadosOcorrencia> listaDesordenada)
        {
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortOcorrencia(listaOrdenada, 0, listaOrdenada.Count - 1);
            return listaOrdenada;
        }

        public static List<DadosOcorrencia> QSRM_Localizacao(List<DadosOcorrencia> listaDesordenada)
        {
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = listaDesordenada;
            RandomizedQuickSortLocalizacao(listaOrdenada, 0, listaOrdenada.Count - 1);
            return listaOrdenada;
        }

        public static void RandomizedQuickSortOcorrencia(List<DadosOcorrencia> input, int left, int right)
        {
            if (left < right)
            {
                int q = RandomizedPartitionOcorrencia(input, left, right);
                RandomizedQuickSortOcorrencia(input, left, q - 1);
                RandomizedQuickSortOcorrencia(input, q + 1, right);
            }
        }

        public static void RandomizedQuickSortLocalizacao(List<DadosOcorrencia> input, int left, int right)
        {
            if (left < right)
            {
                int q = RandomizedPartitionLocalizacao(input, left, right);
                RandomizedQuickSortLocalizacao(input, left, q - 1);
                RandomizedQuickSortLocalizacao(input, q + 1, right);
            }
        }

        private static int RandomizedPartitionOcorrencia(List<DadosOcorrencia> input, int left, int right)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosOcorrencia pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionOcorrencia(input, left, right);
        }

        private static int RandomizedPartitionLocalizacao(List<DadosOcorrencia> input, int left, int right)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            DadosOcorrencia pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return PartitionLocalizacao(input, left, right);
        }

        private static int PartitionOcorrencia(List<DadosOcorrencia> input, int left, int right)
        {
            DadosOcorrencia pivot = input[right];
            DadosOcorrencia temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (input[j].codigo_ocorrencia <= pivot.codigo_ocorrencia)
                {
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                }
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }

        private static int PartitionLocalizacao(List<DadosOcorrencia> input, int left, int right)
        {
            DadosOcorrencia pivot = input[right];
            DadosOcorrencia temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (input[j].ocorrencia.localidade.CompareTo(pivot.ocorrencia.localidade) <= 0)
                {
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                    i++;
                }
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }
        /*
        public static void QuickSort(ref int[] x)
        {
            qs(x, 0, x.Length - 1);
        }

        public static void qs(int[] x, int left, int right)
        {
            int i, j;
            int pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        */
        #endregion

        #region Shell Sort

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

                    while ((j >= increment) && (lista_ordenada[j - increment].codigo_ocorrencia > temp.codigo_ocorrencia))
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

                    while ((j >= increment) && (lista_ordenada[j - increment].ocorrencia.localidade.CompareTo(temp.ocorrencia.localidade) > 0))
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

        #region Merge Sort

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
        #endregion

        #region Heap Sort

        public static List<DadosOcorrencia> HeapsortOcorrencia(List<DadosOcorrencia> x)
        {
            int i;
            DadosOcorrencia temp;
            int n = x.Count - 1;
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = x;

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

        public static void siftDownOcorrencia(List<DadosOcorrencia> x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            DadosOcorrencia temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2].codigo_ocorrencia > x[root * 2 + 1].codigo_ocorrencia)
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root].codigo_ocorrencia < x[maxChild].codigo_ocorrencia)
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }

        public static List<DadosOcorrencia> HeapsortLocalizacao(List<DadosOcorrencia> x)
        {
            int i;
            DadosOcorrencia temp;
            int n = x.Count - 1;
            List<DadosOcorrencia> listaOrdenada = new List<DadosOcorrencia>();
            listaOrdenada = x;

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

        public static void siftDownLocalizacao(List<DadosOcorrencia> x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            DadosOcorrencia temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2].ocorrencia.localidade.CompareTo(x[root * 2 + 1].ocorrencia.localidade) > 0)
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root].ocorrencia.localidade.CompareTo(x[maxChild].ocorrencia.localidade) < 0)
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }

        /*
        public static void Heapsort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDown(ref x, i, n);
            }

            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                siftDown(ref x, 0, i - 1);
            }
        }

        public static void siftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2] > x[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        */
        #endregion

        #region Radix Sort

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

        #region Linear Search
        public static int LinearSearch(ref int[] x, int valueToFind)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (valueToFind == x[i])
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region Binary Search

        public static int BinSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted array x, or -1 if not found
            int left = 0;
            int right = x.Length;
            return binarySearch(ref x, searchValue, left, right);
        }

        public static int binarySearch(ref int[] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return binarySearch(ref x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return binarySearch(ref x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }
        #endregion

        #region Interpolation Search

        public static int InterpolationSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                if (x[mid] < searchValue)
                    low = mid + 1;
                else if (x[mid] > searchValue)
                    high = mid - 1;
                else
                    return mid;
            }

            if (x[low] == searchValue)
                return low;
            else
                return -1; // Not found
        }
        #endregion

        #region Nth Largest
        /*
        public static int NthLargest1(int[] array, int n)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            QuickSort(ref tempArray);
            //Return the n-th largest value in the sorted array
            return tempArray[tempArray.Length - n];
        }

        public static int NthLargest2(int[] array, int k)
        {
            int maxIndex;
            int maxValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < k; i++)
            {
                maxIndex = i;       // index of minimum element
                maxValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    // if we've located a higher value
                    if (tempArray[j] > maxValue)
                    {   // capture it
                        maxIndex = j;
                        maxValue = tempArray[j];
                    }
                }
                Swap(ref tempArray[i], ref tempArray[maxIndex]);
            }
            return tempArray[k - 1];
        }
        #endregion

        #region Mth Smallest

        public static int MthSmallest1(int[] array, int m)
        {
            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);
            //Sort the array
            QuickSort(ref tempArray);
            //Return the m-th smallest value in the sorted array
            return tempArray[m - 1];
        }

        public static int MthSmallest2(int[] array, int m)
        {
            int minIndex;
            int minValue;

            //Copy input data array into a temporary array
            //so that original array is unchanged
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            for (int i = 0; i < m; i++)
            {
                minIndex = i;      // index of minimum element
                minValue = tempArray[i];// assume minimum is the first array element
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (tempArray[j] < minValue)
                    {   // capture it
                        minIndex = j;
                        minValue = tempArray[j];
                    }
                }
                Swap(ref tempArray[i], ref tempArray[minIndex]);
            }
            return tempArray[m - 1];
        }
        */
        #endregion

        #region Miscellaneous Utilities

        public static int FindMax(int[] x)
        {
            int max = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > max) max = x[i];
            }
            return max;
        }

        public static int FindMin(int[] x)
        {
            int min = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < min) min = x[i];
            }
            return min;
        }

        static void MixDataUp(ref int[] x, Random rdn)
        {
            for (int i = 0; i <= x.Length - 1; i++)
            {
                x[i] = (int)(rdn.NextDouble() * x.Length);
            }
        }

        static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        // Determines if int array is sorted from 0 -> Max
        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from A -> Z
        public static bool IsSorted(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0) // If previous is bigger, return false
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if int array is sorted from Max -> 0
        public static bool IsSortedDescending(int[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        // Determines if string array is sorted from Z -> A
        public static bool IsSortedDescending(string[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i].CompareTo(arr[i + 1]) < 0) // If previous is smaller, return false
                {
                    return false;
                }
            }
            return true;
        }

        public static void DisplayElements(ref int[] xArray, char status, string sortname)
        {
            if (status == 'a')
                Console.WriteLine("After sorting using algorithm: " + sortname);
            else
                Console.WriteLine("Before sorting");
            for (int i = 0; i <= xArray.Length - 1; i++)
            {
                if ((i != 0) && (i % 10 == 0))
                    Console.Write("\n");
                Console.Write(xArray[i] + " ");
            }
            Console.ReadLine();
        }
        #endregion
    }
}
