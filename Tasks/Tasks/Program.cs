using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        //        You’re working as a developer for an e-commerce website.The product page allows
        //users to add multiple quantities of an item to their shopping cart.Each product may
        //also have a discount if the quantity is above a certain number. 
        //Your job is to complete the function below that calculates the total price for a
        //        product based on quantity, price, and discount rules.
        //Task: 
        //Complete the calculateTotalPrice function. 
        //Product details: - unitPrice: number (e.g. 20) - quantity: number(e.g. 6) - discountRule: if quantity >= minQuantity, apply discountPercentage
        //Example: 
        //unitPrice = 20 
        //quantity = 6 
        //discountRule = { minQuantity: 5, discountPercentage: 10 } 
        //Expected output:  
        //Total = (20 * 6) - 10% discount = 120 - 12 = 108 
        //*/ 
        //function calculateTotalPrice(unitPrice, quantity, discountRule)
        //    {
        //        let total = 0;
        //        // 🧠 Complete the logic here 
        //        return total;
        //    }
        //    // Example test 
        //    console.log(
        //    calculateTotalPrice(20, 6, { minQuantity: 5, discountPercentage: 10 
        //}) 
        //); // Should return 108 
        public class DiscountRule
        {
            public int minQuantity { get; set; }
            public double discountPercentage { get; set; }
        }

        public static double CalculateTotalPrice(double unitPrice, int quantity, DiscountRule discountRule)
        {
            double totalPrice = unitPrice * quantity;

            if (quantity >= discountRule.minQuantity)
            {
                double discount = totalPrice * (discountRule.discountPercentage / 100);
                totalPrice -= discount;
            }

            return totalPrice;
        }

        static void Main(string[] args)
        {
            double price = CalculateTotalPrice(20, 6, new DiscountRule { minQuantity = 5, discountPercentage = 10 });
            Console.WriteLine(price); // 108
        }
    }
}
