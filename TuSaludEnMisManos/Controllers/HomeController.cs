using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuSaludEnMisManos.Models;
using TuSaludEnMisManos.Controllers;
using System.IO;
using System.Text.RegularExpressions;
using LibraryClassTrees;
using TuSaludEnMisManos.ViewModels;

namespace TuSaludEnMisManos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Medicamento<int>> medicamentos = new List<Medicamento<int>>();
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/csv.txt"));

            var avltree = new AVLTree<int>();
            foreach (string row in fileContents.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var medicamento = new Medicamento<int>
                    {
                        Id_medicamento = Convert.ToInt32(row.Split(',')[0]),
                        nombre = row.Split(',')[1],
                        descripcion = row.Split(',')[2],
                        casa_productora = row.Split(',')[3],
                        precio = row.Split(',')[4],
                        Existencia = Convert.ToInt32(row.Split(',')[5])
                    };
                    avltree.Add(medicamento.Id_medicamento, medicamento.nombre, medicamento.Existencia);
                }
            }

            IList<int> srtlist = new List<int>();
            avltree.InOrderTraversal(medicamentos.Add);
            //return Json(medicamentos, JsonRequestBehavior.AllowGet);
            var indexView = new IndexViewModel
            {
                Medicamentos = medicamentos
            };

            return View(indexView);
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