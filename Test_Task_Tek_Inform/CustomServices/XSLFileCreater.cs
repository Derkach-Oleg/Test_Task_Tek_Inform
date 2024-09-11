using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Test_Task_Tek_Inform.Domain.Entities;

namespace Test_Task_Tek_Inform.Mvc.CustomServices
{
    public class XSLFileCreater
    {
        public static XLWorkbook CreateXSLEnergyLosses(List<EnergyLosses> lstEnergyLosses)
        {
            if (lstEnergyLosses?.Count > 0)
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Лист1");
                worksheet.Cell("A" + 1).Value = "Отчет об объемах суммарных нагрузочных потерь (агрегированно по субъектам РФ)";
                worksheet.Cell("A" + 2).Value = "Дата";
                worksheet.Cell("B" + 2).Value = lstEnergyLosses[0].Date.ToString("d");
                worksheet.Cell("A4").Value = "Субъект РФ";
                worksheet.Cell("A4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell("A4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Range("A4:A5").Merge();
                worksheet.Cell("B4").Value = "Объем потерь, МВтЧ.";
                worksheet.Cell("B4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell("B4").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Range("B4:B5").Merge();

                int rowNumber = 6;

                foreach (EnergyLosses energyLosses in lstEnergyLosses)
                {
                    worksheet.Cell("A" + rowNumber).Value = energyLosses.Region.Name;
                    worksheet.Cell("B" + rowNumber).Value = energyLosses.VolumeOfLosses.ToString();
                    rowNumber++;
                }
                worksheet.Columns().AdjustToContents();

                return workbook;
            }
            else
                return null;
        }
    }
}
