using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Tsak7.Program;

namespace Tsak7
{
    internal class Program
    {
        //        Task Title: Car Rental Suggestion by Similarity
        //You are building a car rental suggestion system.The company has 3 cars.Each car
        //has:
        //• id: car number(1, 2, 3)
        //• rental_times: an array of time slots the car is already rented(e.g., "10:00-
        //12:00")
        //• similarity: a dictionary showing similarity to other cars (value 0–1, higher =
        //more similar)
        //Example Data:
        //cars = [
        // { "id": 1, "rental_times": ["10:00-12:00"], "similarity": {2:
        //0.8, 3: 0.6} },
        // { "id": 2, "rental_times": ["09:00-10:30"], "similarity": {1:
        //0.8, 3: 0.7} },
        // {
        //    "id": 3, "rental_times": ["11:00-13:00"], "similarity": {
        //        1:
        //0.6, 2: 0.7}
        //}
        //]
        //Task:
        //Write a function suggest_car(cars, requested_car_id, requested_time) that:
        //1.Checks if the requested car is available at the requested time.
        //2. If available → return "Car X is available"
        //3. If not available → find the most similar available car (highest similarity
        //score) and return "Car Y is suggested"
        //4. If no car is available → return "No cars available at this time"
        //Example Usage:
        //suggest_car(cars, 1, "10:30-11:30")
        //# Output: "Car 2 is suggested" (Car1 is rented, Car2 is most similar
        //and available)
        //Constraints:
        //• Time slots can be compared as strings (or assume simple non-overlapping
        //time format).
        //• All logic should be implemented in a single function.

        public class Car
        {
            public int Id { get; set; }
            public List<string> RentalTimes { get; set; }
            public Dictionary<int, double> Similarity { get; set; }
        }

        public static List<Car> Cars = new List<Car>
        {
               new Car
        {
            Id = 1,
            RentalTimes = new List<string> { "10:00-12:00" },
            Similarity = new Dictionary<int, double> { {2, 0.8}, {3, 0.6} }
        },
        new Car
        {
            Id = 2,
            RentalTimes = new List<string> { "09:00-10:30" },
            Similarity = new Dictionary<int, double> { {1, 0.8}, {3, 0.7} }
        },
        new Car
        {
            Id = 3,
            RentalTimes = new List<string> { "11:00-13:00" },
            Similarity = new Dictionary<int, double> { {1, 0.6}, {2, 0.7} }
        }
        };

        public static string SuggestCar(List<Car> cars,int requestedCarId,string requestedTime)
        {
           bool IsOverLap(string Time1,string Time2)
           {
                var t1 = Time1.Split('-');
                var t2 = Time2.Split('-');

                int start1 = int.Parse(t1[0].Replace(":",""));
                int end1 = int.Parse(t1[1].Replace(":", ""));

                int start2 = int.Parse(t2[0].Replace(":", ""));
                int end2 = int.Parse(t2[1].Replace(":", ""));

                return !(end1 <= start2 || end2 <= start1);

           }

           bool IsAvailable(Car car,string time)
            {
                foreach(var t in car.RentalTimes)
                {
                    if(IsOverLap(t, time))
                        return false;
                }
                return true;
            }
           
            var RequestedCar = cars.FirstOrDefault(c=>c.Id == requestedCarId);
            if (IsAvailable(RequestedCar, requestedTime))
                return $"Car {requestedCarId} is available";

            var sortedSimilarities = RequestedCar.Similarity.OrderByDescending(c => c.Value);
            foreach(var t in sortedSimilarities)
            {
                var car = cars.FirstOrDefault(c => c.Id == t.Key);
                if(IsAvailable(car, requestedTime))
                    return $"Car {car.Id} is suggested";
            }

            return "No cars available at this time";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(SuggestCar(Cars, 1, "10:30-11:30"));
        }
    }
}
