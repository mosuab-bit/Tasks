using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3
{
    internal class Program
    {
         //        You have a list of tasks, each with a name and a due date(YYYY-MM-DD).
         //You need to sort the tasks in ascending order of due date without using the built-in
         //sort or sorted functions — implement the sorting logic yourself.
         //This will help practice basic algorithm implementation while still being in a realworld scenario.
         //Tasks:
         //("Submit report", "2025-08-15")
         //("Pay bills", "2025-08-12")
         //("Buy groceries", "2025-08-13")
         //Expected:
         //("Pay bills", "2025-08-12")
         //("Buy groceries", "2025-08-13")
         //("Submit report", "2025-08-15")
         //1. No built-in sorting functions.
         //2. Compare dates by converting them into YYYYMMDD integers or using manual
         //date comparison.
         //3. Output the sorted list.
        // This way called selection sort
        static void Main(string[] args)
        {
            (string, string)[] tasks = {
            ("Submit report", "2025-08-15"),
            ("Pay bills", "2025-08-12"),
            ("Buy groceries", "2025-08-13")
            };

            for(int i = 0;i < tasks.Length - 1;i++)
            {
                int mainIndex = i;
                for(int j = i+1;j < tasks.Length;j++)
                {
                    int date1 = int.Parse(tasks[mainIndex].Item2.Replace("-",""));
                    int date2 = int.Parse(tasks[j].Item2.Replace("-", ""));

                    if(date2 < date1)
                       mainIndex = j;

                }

                var temp = tasks[mainIndex];
                tasks[mainIndex] = tasks[i];
                tasks[i] = temp;    
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"({task.Item1}, {task.Item2})");
            }
        }
    }
}
