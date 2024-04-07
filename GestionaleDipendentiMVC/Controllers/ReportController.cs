using FastReport.Web;
using GestionaleDipendentiMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GestionaleDipendentiMVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly GestionaleDipendentiMVCContext _context;
        public ReportController(IWebHostEnvironment environment,GestionaleDipendentiMVCContext context)
        {

            _environment = environment;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetReport() 
        {
            var webReport = new WebReport();
            webReport.Report.Load("reports/CiProvo.frx"); // carico il report nel mio percorso file report

            // Carica i dati dal file XML nel DataSet
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("dipendenti.xml"); // Sostituisci con il percorso del tuo file XML

            // Imposta l'origine dei dati del report sul DataSet appena caricato
            webReport.Report.RegisterData(dataSet, "Data"); // "YourData" è il nome del dataset nel report


            return View(webReport);
        } 
    }
}
