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
        
        /*[HttpPost]

public ActionResult Index(HttpPostedFileBase postedFile)
{
   List<Medicamento> medicamentos = new List<Medicamento>();
   string filePath = string.Empty;
   if (postedFile != null)
   {
       string path = Server.MapPath("~/uploads/");
       if (!Directory.Exists(path))
       {
           Directory.CreateDirectory(path);
       }
       filePath = path + Path.GetFileName(postedFile.FileName);
       string extension = Path.GetExtension(postedFile.FileName);
       postedFile.SaveAs(filePath);

       string csvData = System.IO.File.ReadAllText(filePath);//ReadAllText
       foreach (string row in csvData.Split('\n'))
       {
           if (!string.IsNullOrEmpty(row))
           {
               medicamentos.Add(new Models.Medicamento
               {
                   id_medicamento =Convert.ToInt32(row.Split(',')[0]),
                   nombre = row.Split(',')[1],
                   descripcion = row.Split(',')[1],
                   casa_productora = row.Split(',')[3],
                   precio = row.Split(',')[4],
                   existencia = Convert.ToInt32( row.Split(',')[5])
               });
           }
       }

   }
   return View(medicamentos);
}*/

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