using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace E14_ExportToExcell
{
    public class ExportToExcell
    {
        public static void Main()
        {
            // Install EPPlus package
            var xmlPackage = CreateFile();
            SaveFile(xmlPackage);
        }

        private static ExcelPackage CreateFile()
        {
            var excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("StudentData");

            using (var reader = new StreamReader("../../Import/StudentData.txt"))
            {
                var row = 1;
                FormatTitle(workSheet);

                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;

                    row++;
                    var data = line
                               .Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries)
                               .ToList();
                    FillInRowData(workSheet, row, data);
                    if (row == 2)
                    {
                        FormatHeadings(workSheet, row, data.Count);
                    }
                }
            }
            return excel;
        }

        private static void FormatHeadings(ExcelWorksheet workSheet, int row, int cols)
        {
            var headings = workSheet.Cells[row, 1, row, cols];
            headings.Style.Font.Size = 12;
            headings.Style.Font.Bold = true;
            headings.Style.Font.Color.SetColor(Color.ForestGreen);
            headings.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            headings.Style.Border.Bottom.Color.SetColor(Color.ForestGreen);
            headings.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headings.Style.WrapText = true;
        }

        private static void FormatTitle(ExcelWorksheet workSheet)
        {
            var title = workSheet.Cells[1, 1, 1, 11];
            title.Merge = true;
            title.Value = "SoftUni - LINQ / Problem 14. Export to Excell";
            title.Style.Font.Bold = true;
            title.Style.Font.Size = 16;
            title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            title.Style.WrapText = true;
            title.Style.Fill.PatternType = ExcelFillStyle.LightTrellis;
            title.Style.Fill.BackgroundColor.SetColor(Color.ForestGreen);
        }

        private static void FillInRowData(ExcelWorksheet workSheet, int row, List<string> data)
        {
            for (int col = 0; col < data.Count; col++)
            {
                if (row > 2 && col > 3 && col < data.Count - 1)
                {
                    workSheet.Cells[row, col + 1].Value = int.Parse(data[col]);
                }
                else
                {
                    workSheet.Cells[row, col + 1].Value = data[col];
                }
            }
        }

        private static void SaveFile(ExcelPackage xmlPackage)
        {
            using (var output = new FileStream("../../Export/StudentData.xlsx", FileMode.Create))
            {
                xmlPackage.SaveAs(output);
            }
        }
    }
}
