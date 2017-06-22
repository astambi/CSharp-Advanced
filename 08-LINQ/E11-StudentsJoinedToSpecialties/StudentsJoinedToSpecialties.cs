using System;
using System.Collections.Generic;
using System.Linq;

namespace E11_StudentsJoinedToSpecialties
{
    public class StudentsJoinedToSpecialties
    {
        public class Student
        {
            public string StudentName { get; set; }
            public string FacultyNumber { get; set; }
        }
        public class StudentSpecialty
        {
            public string SpecialtyName { get; set; }
            public string StudentFacultyNumber { get; set; }
        }

        public static void Main()
        {
            var studentSpecialties = GetSpecialties();
            var students = GetStudents();
            PrintStudentsWithSpecialties(students, studentSpecialties);
        }

        private static void PrintStudentsWithSpecialties(List<Student> students, List<StudentSpecialty> studentSpecialties)
        {
            students
                .Join(
                    studentSpecialties,
                    st => st.FacultyNumber,
                    sp => sp.StudentFacultyNumber,
                    (st, sp) => new
                    {
                        StudentName = st.StudentName,
                        FacultyNumber = st.FacultyNumber,
                        SpecialtyName = sp.SpecialtyName
                    }
                )
                .OrderBy(st => st.StudentName)
                .ToList()
                .ForEach(st => Console.WriteLine(
                            $"{st.StudentName} {st.FacultyNumber} {st.SpecialtyName}"));
        }

        private static List<Student> GetStudents()
        {
            var students = new List<Student>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                students.Add(new Student
                {
                    FacultyNumber = tokens[0],
                    StudentName = tokens[1] + " " + tokens[2]
                });
            }
            return students;
        }

        private static List<StudentSpecialty> GetSpecialties()
        {
            var studentSpecialties = new List<StudentSpecialty>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Students:") break;

                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                studentSpecialties.Add(new StudentSpecialty
                {
                    SpecialtyName = tokens[0] + " " + tokens[1],
                    StudentFacultyNumber = tokens[2]
                });
            }
            return studentSpecialties;
        }
    }
}
