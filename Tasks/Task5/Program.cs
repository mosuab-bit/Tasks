using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        //Meeting Room Availability Checker
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
        private static (double StartTime, double EndTime)[] BookedSlots =
        {
           (9, 10),
           (11, 12),
           (15, 16)
        };

        public static string CheckRoomIsOverlap(double startTime, double endTime)
        {
            if (startTime < 0 || endTime > 24 || startTime >= endTime)
                return "Invalid time range";

            foreach (var slot in BookedSlots)
            {
                if (endTime > slot.StartTime && startTime < slot.EndTime)
                    return "Room is not available";
            }
            return "Room is available";
        }

        static void Main(string[] args)
        {
            string result = CheckRoomIsOverlap(12.5, 13.5);
            Console.WriteLine(result);
        }
    }
}

//Solution Using TimeSpan
//{
//    internal class Program
//    {
//        // المواعيد المحجوزة
//        private static (TimeSpan StartTime, TimeSpan EndTime)[] BookedSlots =
//        {
//            (new TimeSpan(9, 0, 0),  new TimeSpan(10, 0, 0)),
//            (new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0)),
//            (new TimeSpan(15, 0, 0), new TimeSpan(16, 0, 0))
//        };

//        public static string CheckRoomIsOverlap(TimeSpan startTime, TimeSpan endTime)
//        {
//            if (startTime >= endTime)
//                return "❌ Invalid time range";

//            foreach (var slot in BookedSlots)
//            {
//                // شرط التداخل
//                if (endTime > slot.StartTime && startTime < slot.EndTime)
//                    return "❌ Room is not available";
//            }

//            return "✅ Room is available";
//        }

//        static void Main(string[] args)
//        {
//            // مثال: من 12:30 إلى 13:30
//            TimeSpan start = new TimeSpan(12, 30, 0);
//            TimeSpan end = new TimeSpan(13, 30, 0);

//            string result = CheckRoomIsOverlap(start, end);
//            Console.WriteLine(result);
//        }
//    }
//}

