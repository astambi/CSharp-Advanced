using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                //FilterAndTake(wantedData, ExcellentFilter, studentsToTake);   // Replaced by LINQ
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                //FilterAndTake(wantedData, AverageFilter, studentsToTake);     // Replaced by LINQ
                FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                //FilterAndTake(wantedData, PoorFilter, studentsToTake);        // Replaced by LINQ
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
        int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                //double averageMark = Average(userName_Points.Value);      // Replaced by LINQ
                double averageScore = userName_Points.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double averageMark = percentageOfFullfilment * 4 + 2;

                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        // Replaced by LINQ

        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5;
        //}

        //private static bool AverageFilter(double mark)
        //{
        //    return mark < 5 && mark >= 3.5;
        //}

        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.5;
        //}

        //private static double Average(List<int> scoresOnTask)
        //{
        //    int totalScore = 0;
        //    foreach (var score in scoresOnTask)
        //    {
        //        totalScore += score;
        //    }
        //    var percentageOfAll = totalScore / (scoresOnTask.Count * 100.0);
        //    var mark = percentageOfAll * 4 + 2;

        //    return mark;
        //}
    }
}
