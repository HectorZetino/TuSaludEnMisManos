using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LibraryClassTrees;

namespace TuSaludEnMisManos.Controllers
{
    public class MedicamentosController : Controller
    {
        public static AVLTree.AVLTree ArbolMedicamentos = new AVLTree.AVLTree.AVLTree();
        public static AVLTree.Medicamento[] mostrar;
        public static List<AVLTree.Medicamento> medicamentos = new List<AVLTree.Medicamento>();
        public static int a = 0;

        // GET: Medicamentos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicamentos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medicamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medicamentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
