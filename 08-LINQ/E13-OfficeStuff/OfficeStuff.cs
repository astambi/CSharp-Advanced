using System;
using System.Collections.Generic;
using System.Linq;

namespace E13_OfficeStuff
{
    public class OfficeStuff
    {
        public static void Main()
        {
            var companies = GetCompanies();
            PrintCompanies(companies);
            //PrintCompaniesLINQ(companies);
        }

        private static void PrintCompanies(SortedDictionary<string, Dictionary<string, long>> companies)
        {
            foreach (var company in companies)
            {
                var products = company.Value.Select(p => p.Key + "-" + p.Value);
                Console.WriteLine($"{company.Key}: {string.Join(", ", products)}");
            }
        }

        private static void PrintCompaniesLINQ(SortedDictionary<string, Dictionary<string, long>> companies)
        {
            companies
                .Select(c => new
                {
                    Name = c.Key,
                    Products = c.Value.Select(p => p.Key + "-" + p.Value)
                })
                .ToList()
                .ForEach(c => Console.WriteLine($"{c.Name}: {string.Join(", ", c.Products)}"));
        }

        private static SortedDictionary<string, Dictionary<string, long>> GetCompanies()
        {
            var companies = new SortedDictionary<string, Dictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                            .Trim('|')
                            .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                var company = tokens[0];
                var amount = long.Parse(tokens[1]);
                var product = tokens[2];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new Dictionary<string, long>();
                }
                if (!companies[company].ContainsKey(product))
                {
                    companies[company][product] = 0;
                }
                companies[company][product] += amount;
            }
            return companies;
        }
    }
}
