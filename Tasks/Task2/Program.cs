using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
//  REQUIRMENT:      �
//� Problem: Group Words by Length
//Description: 
//Write a method that takes a list of strings and returns a dictionary where each key is 
//the length of the words, and the value is a list of all words that have that length.
//✅ Requirements: 
// Method signature: 
//Dictionary<int, List<string>> GroupWordsByLength(List<string>
//words)
// The method should not use LINQ(you can ask for a version with LINQ later
//if needed). 
// Assume the list is non-null. 
//�
//� Example: 
//Input: ["apple", "bat", "car", "code", "a", "hi"]
//Output: 
//{ 
//} 
//1: ["a"], 
//2: ["hi"], 
//3: ["bat", "car"], 
//4: ["code"], 
//5: ["apple"]

        public static SortedDictionary<int, List<string>> GroupWordsByLength(List<string>words)
        {
            SortedDictionary<int,List<string>> GroupWordsByLength = new SortedDictionary<int,List<string>>();
            foreach (string word in words)
            {
                if (!GroupWordsByLength.ContainsKey(word.Length))
                {
                    GroupWordsByLength[word.Length] = new List<string>();
                }
                GroupWordsByLength[word.Length].Add(word);
            }
            return GroupWordsByLength;
        }

        static void Main(string[] args)
        {
            List<string> words = new List<string> { "apple", "bat", "car", "code", "a", "hi" };
            SortedDictionary<int, List<string>> groupWordsByLength = GroupWordsByLength(words);
            
            foreach(KeyValuePair<int,List<string>> kvp in groupWordsByLength)
            {
                Console.WriteLine($"{kvp.Key}: [{string.Join(", ", kvp.Value)}]");
            }
        }
    }
}
