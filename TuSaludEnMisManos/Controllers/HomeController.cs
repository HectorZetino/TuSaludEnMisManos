using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuSaludEnMisManos.Models;
using TuSaludEnMisManos.Controllers;
using System.IO;
using System.Text.RegularExpressions;

namespace TuSaludEnMisManos.Controllers
{
    public class HomeController : Controller
    {

        private Stream path;

        public ActionResult Index()
        {
            return View();
        }
        public void FileReader()
        {
            using (StreamReader Lector = new StreamReader(@"C: \URL - Primer ciclo 2019\Estructura de datos\Laboratorios\TuSaludEnMisManos\TuSaludEnMisManos\MOCK_DATA (4)"))
            {
                Regex Parse = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                List<Medicamento<int>> medicina = new List<Medicamento<int>>();
                Lector.ReadLine();
                string Line;

                while ((Line = Lector.ReadLine()) != null)
                {
                    string[] values = Parse.Split(Line);

                    var medicamento = new Medicamento<int>
                    {
                        Id_medicamento = Convert.ToInt32(values[0]),
                        nombre = values[1],
                        existencia = Convert.ToInt32(values[2]),
                    };
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}