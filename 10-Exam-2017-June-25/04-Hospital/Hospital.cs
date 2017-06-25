using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    public class Hospital
    {
        public const int maxDepartmentCapacity = 20 * 3;

        public static void Main()
        {
            var patientsByDepartment = new Dictionary<string, HashSet<string>>();
            var patientsByDoctor = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Output") break;

                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                var department = tokens[0];
                var doctor = tokens[1] + " " + tokens[2];
                var patient = string.Join(" ", tokens.Skip(3));

                if (!patientsByDepartment.ContainsKey(department))
                {
                    patientsByDepartment[department] = new HashSet<string>();
                }
                if (!patientsByDoctor.ContainsKey(doctor))
                {
                    patientsByDoctor[doctor] = new SortedSet<string>();
                }
                int departmentCapacity = patientsByDepartment[department].Count();
                if (departmentCapacity < maxDepartmentCapacity)
                {
                    patientsByDepartment[department].Add(patient);
                    patientsByDoctor[doctor].Add(patient);
                }
            }

            SearchHospital(patientsByDepartment, patientsByDoctor);
        }

        private static void SearchHospital(Dictionary<string, HashSet<string>> patientsByDepartment, Dictionary<string, SortedSet<string>> patientsByDoctor)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                string department = tokens[0];

                switch (tokens.Count)
                {
                    case 2: // Department Room
                        if (patientsByDepartment.ContainsKey(department))
                        {
                            int room = int.Parse(tokens[1]);
                            patientsByDepartment[department]
                                .Skip(3 * (room - 1))
                                .Take(3)
                                .OrderBy(p => p) // alphabetical
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        else // Doctor [name surname]
                        {
                            var doctor = tokens[0] + ' ' + tokens[1];
                            if (patientsByDoctor.ContainsKey(doctor))
                            {
                                patientsByDoctor[doctor]
                                    .ToList()
                                    .ForEach(p => Console.WriteLine(p));
                            }
                        }
                        break;
                    case 1: // Department
                        if (patientsByDepartment.ContainsKey(department))
                        {
                            patientsByDepartment[department]
                                .ToList() // order of appearance
                                .ForEach(p => Console.WriteLine(p));
                        }
                        break;
                    default: break;
                }
            }
        }
    }
}
