using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PirateLootDistribution
{
    class Program
    {
        static void DistributeLoot(int countOfPirates, int[] arr)
        {
            bool isLootDistributed = false;
            int leftIndex = 0;
            int rightIndex = arr.Length - 1;
            int[] lootDetails = new int[countOfPirates + 1];
            // 5 3 2 4 2
            while (!isLootDistributed)
            {
                for (int i = 0; i < countOfPirates; i++)
                {
                    if (rightIndex < leftIndex)
                    {
                        isLootDistributed = true;
                        break;
                    }

                    if (arr[leftIndex] > arr[rightIndex])
                    {
                        lootDetails[i + 1] += arr[leftIndex];
                        leftIndex++;
                    }
                    else if (arr[leftIndex] < arr[rightIndex])
                    {
                        lootDetails[i + 1] += arr[rightIndex];
                        rightIndex--;
                    }
                    else if (arr[leftIndex] == arr[rightIndex])
                    {
                        lootDetails[i + 1] += arr[rightIndex];
                        rightIndex--;
                    }
                }
            }
            //string result = string.Empty;
            for (int i = 0; i < lootDetails.Length - 1; i++)
            {
                //result += lootDetails[i + 1];
                Console.Write(lootDetails[i + 1]);
                if (i < lootDetails.Length - 2)
                    Console.Write(" ");
                else
                    Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    //string line = reader.ReadLine();
                    //Console.WriteLine(line);
                    //// Tell me what is the line value after running?


                    int countOfPirates = Convert.ToInt32(reader.ReadLine());
                    int[] arr = Array.ConvertAll(reader.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                    DistributeLoot(countOfPirates, arr);
                    //Console.WriteLine(line);
                }
        }
    }
}

