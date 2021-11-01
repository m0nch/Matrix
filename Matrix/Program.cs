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
            Console.WriteLine("Please enter width for array: ");
            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter height for array: ");
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter MAX value for random number: ");
            int rndMax = int.Parse(Console.ReadLine());

            int[,] matrix = CreateArray(width, height, rndMax);
            Print(matrix);
            Console.WriteLine(string.Empty);
            int[] diagonal = GetDiagonal(matrix);
            Print(diagonal);
            Console.WriteLine(string.Empty);

            Print("Maximum of two dimensin array is ", GetMax(matrix));
            Print("Maximum of one dimensin array (diagonal) is ", GetMax(diagonal));
            //Console.WriteLine($"Maximum is {GetMax(matrix)}");
            Console.ReadKey();

        }

        public static int[,] CreateArray(int width, int height, int rndMax)
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

        public static int[] GetDiagonal(int[,] array)
        {
            int[] diagonal = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                diagonal[i] = array[i, i];
            }
            return diagonal;
        }
        public static int GetMax(int[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }
            return max;
        }
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

        public static void Print(string str, int value)
        {
            Console.WriteLine($"{str}{value}");
        }
        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine(string.Empty);
            }
        }
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }

        //todo:  summary-ները չմոռանալ, նույնությամբ մինիմումը, տեղերով 
        //փոխել մաքսիմումն ու մինիմուmը, ցուցադրել մաքսիմումի տեղը
    }
}
