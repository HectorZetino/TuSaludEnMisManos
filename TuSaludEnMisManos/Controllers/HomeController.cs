using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuSaludEnMisManos.Models;
using TuSaludEnMisManos.Controllers;
using System.IO;


namespace TuSaludEnMisManos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<Medicamento>());
        }
        [HttpPost]

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