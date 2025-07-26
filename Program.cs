using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class TransactionFilter
{
    static void Main()
    {
        List<decimal> transactions = new List<decimal>();
        Console.WriteLine("Enter 20 transaction amounts:");

        while (transactions.Count < 20)
        {
            Console.Write($"Transaction {transactions.Count + 1}: ");
            string input = Console.ReadLine();

            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
            {
                transactions.Add(amount);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        var largeTransactions = transactions.Where(t => t > 10000).ToList();
        decimal total = largeTransactions.Sum();

        Console.WriteLine("\nTransactions above 10,000:");
        foreach (var t in largeTransactions)
        {
            Console.WriteLine(t.ToString("F2"));
        }

        Console.WriteLine($"\nTotal of qualifying transactions: {total:F2}");
    }
}
