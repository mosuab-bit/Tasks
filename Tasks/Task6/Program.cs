using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        //        📌 Task Title: Cinema Seat Booking Checker
        //Description:
        //You are building a simple seat booking system for a small cinema hall.The seating
        //arrangement is represented as a list of seats, where:
        //• "A" means the seat is available
        //• "B" means the seat is booked
        //Your task is to check if a requested seat number is available.
        //• If it is available, mark it as booked and display a confirmation message.
        //• If it is already booked, display a message saying the seat is not available.
        //💡 Example Scenario:
        //Initial seating: [A, A, B, A, B, A]
        //        User wants seat 2 → Available → Book seat → Updated seating:
        //[A, B, B, A, B, A]
        //User wants seat 3 → Already booked → Output: "Seat 3 is not
        //available."
        //✅ Requirements:
        //1. The seating arrangement can be hardcoded as a list for testing.
        //2. Seat numbers will be provided as 1-based indexing (Seat 1 is the first seat).
        //3. Output the updated seating arrangement after any booking attempt.
        //4. The solution should handle invalid seat numbers gracefully(e.g., seat number
        //out of range).
        //📥 Input Example:
        //Seat number: 4
        //📤 Output Example:
        //Seat 4 successfully booked.
        //Updated seating: [A, A, B, B, B, A]

        public static List<string> seats = new List<string>
        {
            "A",
            "A",
            "B",
            "A",
            "B",
            "A"
        };

        public static void CheckSeat(int numOfSeat)
        {
            if (numOfSeat < 1 || numOfSeat > seats.Count)
            {
                Console.WriteLine("Number of seat out of range");
                return;
            }

            if (seats[numOfSeat-1] == "A")
            {
                Console.WriteLine("Seat Booked Successfully");
                seats[numOfSeat - 1] = "B";

            }else
            {
                Console.WriteLine("Seat Already Boked");
            }

            foreach (string seat in seats)
            {
                Console.WriteLine(string.Join(",", seat));
            }

        }

        static void Main(string[] args)
        {
            CheckSeat(3);
        }
    }
}
