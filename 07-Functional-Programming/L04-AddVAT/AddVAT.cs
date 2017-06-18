using System;
using System.Linq;

namespace L04_AddVAT
{
    public class AddVAT
    {
        public static void Main()
        {
            //Func<double, double> addVAT = n => n * 1.2;

            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(p => p * 1.20)
                //.Select(addVAT)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p:f2}"));
        }
    }
}
