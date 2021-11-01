using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter height for array: ");
            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter width for array: ");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter MAX value for random number: ");
            int rndMax = int.Parse(Console.ReadLine());

            int[,] matrix = CreateArray(height, width, rndMax);
            Print(matrix);
            Console.WriteLine(string.Empty);
            int[] diagonal = GetDiagonal(matrix);
            if (diagonal != null)
            { 
                Print(diagonal); 
            }
            Console.WriteLine(string.Empty);

            Print("Maximum of two dimension array is ", GetMax(matrix));
            Print("Minimum of two dimension array is ", GetMin(matrix));

            if (diagonal != null)
            {
                Print("Maximum of one dimension array (diagonal) is ", GetMax(diagonal));
            }
            Print("Maximim element indexes is ", GetIndexOfMaxElement(matrix));
            Print("Minimum element indexes is ", GetIndexOfMinElement(matrix));
            //Console.WriteLine($"Maximum is {GetMax(matrix)}");

            SwapMaxWithMin(GetIndexOfMaxElement(matrix), GetIndexOfMinElement(matrix), matrix);
            Print(matrix);
            Console.ReadKey();

        }
        /// <summary>
        /// Creates a two-dimensional array with user-specified dimensions and MAX value for random elements.  
        /// </summary>
        /// <param name="width">First dimension of array</param>
        /// <param name="height">Second dimension of array</param>
        /// <param name="rndMax">MAX value for random elements</param>
        /// <returns></returns>
        public static int[,] CreateArray(int height, int width, int rndMax)
        {
            Random rnd = new Random();
            int[,] matrix = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = rnd.Next(rndMax);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Gets a two-dimensional square array and returns a diagonal of it as a one-dimensional array
        /// </summary>
        /// <param name="array">given two-dimensional square array</param>
        /// <returns>returns a diagonal as a one-dimensional array</returns>
        public static int[] GetDiagonal(int[,] array)
        {
            if (array.GetLength(0) == array.GetLength(1))
            {
                int[] diagonal = new int[array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    diagonal[i] = array[i, i];
                }
                return diagonal;
            }
            else
            {
                Console.WriteLine("This array hasn't diagonal!");
                return null;
            }
        }
        /// <summary>
        /// Gets a maximum element of the given array
        /// </summary>
        /// <param name="array">given two-dimensional square array</param>
        /// <returns>returns element with maximum value</returns>
        public static int GetMax(int[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            return max;
        }
        /// <summary>
        /// Gets a maximum element of the given array
        /// </summary>
        /// <param name="array">given one-dimensional array</param>
        /// <returns>returns element with maximum value</returns>
        public static int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }
        /// <summary>
        /// Gets a minimum element of the given array
        /// </summary>
        /// <param name="array">given two-dimensional square array</param>
        /// <returns>returns element with minimum value</returns>
        public static int GetMin(int[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                        min = array[i, j];
                }
            }
            return min;
        }
        /// <summary>
        /// Gets a minimum element of the given array
        /// </summary>
        /// <param name="array">given one-dimensional array</param>
        /// <returns>returns element with minimum value</returns>
        public static int GetMin(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }
            return min;
        }
        /// <summary>
        /// Gets an indexes of a maximum element of the given array
        /// </summary>
        /// <param name="array">given two-dimensional square array</param>
        /// <returns>returns indexes of a maximum element as a one-dimensional array</returns>
        public static int[] GetIndexOfMaxElement(int[,] array)  //միգուցե ստանա էլեմենտ, ոչ թե զանգված, բայց էլեմենտն int-ա, ինդեքս չեմ կարող ստանալ
        {
            int index1 = 0;
            int index2 = 0;
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        index1 = i;
                        index2 = j;
                    }
                }
            }
            int[] index = new int[] { index1, index2 };
            return index;
        }
        /// <summary>
        /// Gets an indexes of a minimum element of the given array
        /// </summary>
        /// <param name="array">given two-dimensional square array</param>
        /// <returns>returns indexes of a minimum element as a one-dimensional array</returns>
        public static int[] GetIndexOfMinElement(int[,] array)  //միգուցե ստանա էլեմենտ...
        {
            int index1 = 0;
            int index2 = 0;
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        index1 = i;
                        index2 = j;
                    }
                }
            }
            int[] index = new int[] { index1, index2 };
            return index;
        }
        /// <summary>
        /// Swaps maximum and minimum element of the given array
        /// </summary>
        /// <param name="max">given maximum element of the given array</param>
        /// <param name="min">given minimum element of the given array</param>
        /// <param name="array">given two-dimensional array</param>
        /// <returns>returns a new two-dimensional array with swapped elements</returns>
        public static int[,] SwapMaxWithMin(int[] max, int[] min, int[,] array) 
        {
            int max0 = max[0];
            int max1 = max[1];
            int min0 = min[0];
            int min1 = min[1];

            int temp = array[max0, max1];
            array[max0, max1] = array[min0, min1];
            array[min0, min1] = temp;

            return array;
        }
        /// <summary>
        /// Prints string result from given parameters
        /// </summary>
        /// <param name="str">given any string</param>
        /// <param name="value">given any Int32 value</param>
        public static void Print(string str, int value)  //մաքսիմումն ու մինիմումը տպելու համար
        {
            Console.WriteLine($"{str}{value}");
        }
        /// <summary>
        /// Prints string result from given parameters
        /// </summary>
        /// <param name="str">given any string</param>
        /// <param name="value">given any Int32 array</param>
        public static void Print(string str, int[] value)  //ինդեքսները տպելու համար
        {
            Console.WriteLine($"{str}{value[0]} {value[1]}");
        }
        /// <summary>
        /// Prints a two-dimensional array elements in console
        /// </summary>
        /// <param name="array">given two-dimensional array</param>
        public static void Print(int[,] array) //զանգվածը տպելու համար
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Prints a one-dimensional array elements in console
        /// </summary>
        /// <param name="array">given one-dimensional array</param>
        public static void Print(int[] array)  //անկյունագիծը տպելու համար
        {
            for (int i = 0; i < array.Length; i++)  
            {
                Console.Write($"{array[i]}\t");
            }
        }
        
    }
}
