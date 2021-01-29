using System;
using System.Collections.Generic;
using System.Linq;

namespace sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            BinarySearch(arr, 0, arr.Length-1,10);
        }

        //Міняєм змінні значеннями без тимчасової змінної
        public static void change(int x, int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;

            //Console.WriteLine(x);
            //Console.WriteLine(y);
        }

        public static string[] dirReduc(String[] arr)
        {
            var list = arr.ToList();

            //var i = list.IndexOf("west");
            int shorter = 0;
            for (int i = 0; i < list.Count - shorter; i++)
            {
                switch (list[i])
                {
                    case "WEST":
                        var delIndex = list.IndexOf("EAST");
                        list.RemoveAt(delIndex);
                        shorter++;
                        break;
                    case "EAST":
                        delIndex = list.IndexOf("WEST");
                        list.RemoveAt(delIndex);
                        shorter++;
                        break;
                    case "NORTH":
                        delIndex = list.IndexOf("SOUTH");
                        list.RemoveAt(delIndex);
                        shorter++;
                        break;
                    case "SOUTH":
                        delIndex = list.IndexOf("NORTH");
                        list.RemoveAt(delIndex);
                        shorter++;
                        break;
                    default:
                        throw new ArgumentException("Not valid argument");
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            return list.ToArray();
        }

        public static int FindMissing(List<int> list)
        {
            int dif1 = list[1] - list[0];
            int dif2 = list[list.Count - 1] - list[list.Count - 2];

            int dif = dif1 > dif2 ? dif2 : dif1;

            for (int i = 1; i < list.Count; i++)
            {
                if ((list[i - 1] + dif) == list[i])
                {
                    continue;
                }
                else
                {
                    return list[i - 1] + dif;
                }
            }

            return -1;
        }

        public static int CountBits(int n)
        {
            int ret = 0;
            string binary = Convert.ToString(n, 2);
            for(int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    ret++;
                }       
            }
            return ret;
        }

        public static bool XO(string input)
        {
            int x = 0;
            int o = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if ( input[i] == Convert.ToChar("x") || input[i] == Convert.ToChar("X"))
                {
                    x++;
                }
                else if (input[i] == Convert.ToChar("o") || input[i] == Convert.ToChar("O"))
                {
                    o++;
                }
            }

            if (x == o)
            {
                return true;
            }

            return false;
        }

        public static string AlphabetPosition(string text)
        {
            var prog = new Program();
            //int[] ret = new int[text.Length];

            List<int> ret = new List<int>();
            
            for (int i = 0; i < text.Length; i++)
            {
                var k = ReturnPosNumber(text[i]);
                if (k > 0 && k < 27) {
                    ret.Add(k);
                }
                    
            }

            return String.Join(" ",ret.ConvertAll(i => i.ToString()));
        }

        public static int ReturnPosNumber(char ch)
        {
            //char a = Convert.ToChar(ch);
            int i = Char.ToUpper(ch) - 64;
            return i;
        }

        public static void Buble_sort(int[] array)
        {
            int k = 0;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++) {
                    if (array[j] > array[i])
                    {
                        //k = array[i];
                        //array[i] = array[j];
                        //array[j] = k;
                        array[i] = array[i] ^ array[j];
                        array[j] = array[i] ^ array[j];
                        array[i]  = array[i] ^ array[j];
                    }
                }
            }

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

        }

        //?
        public static int BinarySearch(int[] arr, int low, int high, int find)
        { // Foe binary search array should be sorted
            high--;

            if (!arr.ToList().Contains(find))
            {
                Console.WriteLine("Not found!");
                return -1;
            }

            while (low <= high) 
            {
                //printArray(arr);
                var mid = (high - low) / 2;
               // Console.WriteLine(mid);
                if (arr[mid] == find)
                {
                    Console.WriteLine($"Index of your element is {mid}");
                    
                    return 0;
                }
                else if (find > arr[mid])
                {
                     high = mid + 1;
                }
                else
                {
                    low = mid - 1;
                }
            }
            return -1;
        }


        public static void Selection_sort(int[] array)
        {

            var min = array[0];
            var k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < min)
                    {
                        k = array[i];
                        array[i] = array[j];
                        array[j] = k;
                    }
                }
            }

            foreach (int i in array)
            {
                Console.WriteLine(array[i]);
            }

        }

        //Quick sort functions

        /* This function takes last element as pivot, 
            places the pivot element at its correct 
            position in sorted array, and places all 
            smaller (smaller than pivot) to left of 
            pivot and all greater elements to right 
            of pivot */
        public static int pivot(int[] arr, int low, int high)
        {
            int i = low - 1;
            int pi = arr[high];

            for (int j = low; j <= high; j++)
            {
                if (arr[j] < pi)
                {
                    i++;

                    int k = arr[j];
                    arr[j] = arr[i];
                    arr[i] = k;
                }
            }

            int temp = arr[high];
            arr[high] = arr[i + 1];
            arr[i + 1] = temp;

            return i + 1;
        }

        public static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                var pi = pivot(arr, low, high);

                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);


                //printArray(arr);
            }
        }
        static void printArray(int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
        //------------------------------------------
        static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }

        public static int Mario()
        {
            //This is correct input of height for pyramyd
            int number;
            while (true)
            {
                Console.WriteLine("Input height: ");
                var n = Console.ReadLine();
                
                if (Int32.TryParse(n, out number))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!\n");
                }
            }

            for (int i = 1; i <= number; i++)
            {
                for (int j = 0; j < number-i; j++)
                {
                    Console.Write(" ");
                }
                for (int a = number-i; a < number; a++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Done!");
            return -1;
        }
    }
}
