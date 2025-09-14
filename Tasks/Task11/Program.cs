using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        //        Meeting Room Availability Checker
        //You are creating a tool to check if a meeting room is available for a given time range.
        //The booked time slots are stored as a list of tuples, where:
        //• First value → Start time (in 24-hour format)
        //• Second value → End time(in 24-hour format)
        //• (start time, end time) this mean the customer has the room from to .
        //Given a requested start time and requested end time, check if the meeting overlaps
        //with any booked slot.
        //• If no overlap → "Meeting room is available."
        //• If overlap → "Meeting room is not available."
        //Example:
        //Booked slots: [(9, 10), (11, 12), (15, 16)]
        //Request: 10 to 11 → Available ✅
        //Request: 9 to 10 → Not available ❌
        //Request: 10 to 11.5 → Available ✅
        //Requirements:
        //1. Meeting times are integers or floats(e.g., 13.5 means 1:30 PM).
        //2. A meeting overlaps if any part of it conflicts with a booked slot.

        private static (double Start, double End)[] bookedSlots =
{
            (9, 10),
            (11, 12),
            (15, 16)
        };

        public static string CheckBokkedSlots(double start,double end)
        {
           foreach(var slot in bookedSlots)
            {
                if (!(slot.End < start || end < slot.Start))
                    return $"slot already Booked";
            }

            return "slot booked successfully";
        }
        static void Main(string[] args)
        {
            string result = CheckBokkedSlots(4,7);
            Console.WriteLine(result);
        }
    }
}
