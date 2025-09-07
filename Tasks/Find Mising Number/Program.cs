using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Find_Mising_Number
{
    internal class Program
    {
          // “Missing Number Finder”
          //• Description: You are given an array of integers containing numbers from 1 to
          //N, but one number is missing.Write a function to find the missing number
          //without using any built-in set operations.
          //• Example:
          //Input: [1, 2, 4, 5]
          //Output: 3

        public static int FindMissingNumber(int[] numbers)
        {
            int actualSum = 0;
            //we add 1 to length because there is number is missing
            int n = numbers.Length + 1;
            int expectedSum = n * (n + 1) / 2;
            for (int i = 0; i < numbers.Length; i++)
            {
                actualSum += numbers[i];
            }

            int MissingNum = expectedSum - actualSum;
            return MissingNum;
            
        }
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 4, 5 };
            int missingNum = FindMissingNumber(numbers);
            Console.WriteLine(missingNum);
        }
    }
}
