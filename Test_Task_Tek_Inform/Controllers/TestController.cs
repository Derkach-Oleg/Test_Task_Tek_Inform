using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test_Task_Tek_Inform.Domain;
using Test_Task_Tek_Inform.Domain.Entities;
using Test_Task_Tek_Inform.Models;
using Test_Task_Tek_Inform.Mvc.CustomServices;

namespace Test_Task_Tek_Inform.Controllers
{
    public class TestController : Controller
    {


        private readonly EFContext _efContext;

        public TestController(EFContext efContext)
        {
            _efContext = efContext;
        }

        [HttpPost]
        public FileResult GetFilesByDate(DateTime selectedDate)
        {
            try
            {
                //EnergyLosses[] arrEnergyLosses = _efContext.EnergyLosses.Where(x =>  x.Date == selectedDate).ToArray();
                List<EnergyLosses> lstEnergyLosses = _efContext.lst.Where(x => x.Date == selectedDate.Date).ToList();

                var workbook = XSLFileCreater.CreateXSLEnergyLosses(lstEnergyLosses);

                if (workbook == null)
                    return null;

                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{lstEnergyLosses[0].Date.ToString("yyyyMMdd")}_eur_losses_regions.xls");
                }
            }
            catch 
            {
                return null;
            }
            
        }

        [HttpPost]
        public void SaveFiles(DateTime selectedDate)
        {
            //EnergyLosses[] arrEnergyLosses = _efContext.EnergyLosses.Where(x =>  x.Date == selectedDate).ToArray();
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
