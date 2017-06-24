using System;
using System.Linq;
using System.Text;

namespace L01_StudentsResults
{
    public class StudentsResults
    {
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            builder.AppendLine("Name      |   CAdv|   COOP| AdvOOP|Average|");

            for (int i = 0; i < studentsCount; i++)
            {
                var args = Console.ReadLine()
                          .Trim()
                          .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var student = args[0];
                var results = args[1]
                            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(double.Parse)
                            .ToArray();
                var resultCAdv = results[0];
                var resultCOOP = results[1];
                var resultAdvOOP = results[2];
                var averageResult = (resultCAdv + resultCOOP + resultAdvOOP) / 3.00;

                builder.AppendLine($"{student,-10}|{resultCAdv,7:f2}|{resultCOOP,7:f2}|{resultAdvOOP,7:f2}|{averageResult,7:f4}|");
            }
            Console.Write(builder.ToString());
        }
    }
}
