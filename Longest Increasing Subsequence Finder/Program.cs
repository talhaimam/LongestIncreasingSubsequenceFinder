using System;
using System.Collections.Generic;

namespace Longest_Increasing_Subsequence_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> sequence = new List<int>();
            string[] integers = Console.ReadLine().Split(' ');
            for (int i = 0; i < integers.Length; i++)
            {
                sequence.Add(int.Parse(integers[i]));
            }
            foreach (var integer in GetLongestIncreasingSubSequence(sequence))
            {
                Console.Write(integer + " ");
            }
            Console.ReadLine();
        }
        static List<int> GetLongestIncreasingSubSequence(List<int> arr)
        {
            int n = arr.Count;
            List<int> sorted = new List<int>();
            int maxSubsetLenght = 0;
            for (int i = 1; i <= (int)Math.Pow(2, n) - 1; i++)
            {
                int tempSubsetLenght = 0;
                List<int> temp = new List<int>();


                for (int j = 1; j <= n; j++)
                {
                    if (((i >> (j - 1)) & 1) == 1)
                    {
                        temp.Add(arr[j - 1]);
                        tempSubsetLenght++;
                    }

                }

                if ((tempSubsetLenght > maxSubsetLenght) && (CheckAscending(temp)))
                {
                    sorted = temp;
                    maxSubsetLenght = tempSubsetLenght;
                }
            }
            return sorted;
        }
        static bool CheckAscending(List<int> list)
        {
            bool ascending = true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    ascending = false;
                }
            }

            return ascending;
        }
        static int GetLongestIncreasingSubSequence(int[] arr, int n)
        {
            int[] lis = new int[n];
            //List<int,int>
            int i, j, max = 0;

            for (i = 0; i < n; i++)
                lis[i] = 1;

            for (i = 1; i < n; i++)
            {
                for (j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;
                }
            }

            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];

            return max;
        }
        //static int GetLongestIncreasingSubSequence(int[] source)
        //{
        //    int LIS = 0;
        //    for (int i = 0; i < source.Count(); i++)
        //    {
        //        int temp = 0;
        //        int n = source[i];
        //        for (int j = i+1; j < source.Count(); j++)
        //        {
        //            if (n<source[j])
        //            {
        //                n = source[j];
        //                temp++;
        //            }
        //        }
        //        if (temp>LIS)
        //        {
        //            LIS = temp;
        //        }
        //    }
        //    return LIS;
        //}
    }
}
