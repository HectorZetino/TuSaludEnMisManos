using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LibraryClassTrees;
using TuSaludEnMisManos.Models;
using TuSaludEnMisManos.Controllers;
using TuSaludEnMisManos.ViewModels;

namespace TuSaludEnMisManos.Controllers
{
    public class MedicamentosController : Controller
    {
        public static LibraryClassTrees.BinaryTree ArbolMedicamentos = new LibraryClassTrees.BinaryTree();
        public static LibraryClassTrees.MedicamentoBT[] mostrar;
        public static List<LibraryClassTrees.MedicamentoBT> medicamentos = new List<LibraryClassTrees.MedicamentoBT>();
        public static int a = 0;

        // GET: Medicamentos
        public void leerArchivo()
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"~/App_Data/MOCK_DATA.csv";
            LibraryClassTrees.MedicamentoBT aux;
            using (StreamReader sr = System.IO.File.OpenText(Path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s != "")
                    {
                        aux = new LibraryClassTrees.MedicamentoBT();
                        aux.Id = Convert.ToInt32(s.Split('|')[0]);
                        aux.Nombre = s.Split('|')[1];
                        aux.Descripcion = s.Split('|')[2];
                        aux.Productora = s.Split('|')[3];
                        aux.Precio = Convert.ToDouble(s.Split('|')[4]);
                        aux.Cantidad = Convert.ToInt32(s.Split('|')[5]);
                        ArbolMedicamentos.AgregarElemento(aux);
                        medicamentos.Add(aux);
                    }
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MostrarPost()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            if (a == 0)
                a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(1, a);
            ViewBag.Matriz = mostrar;
            GuardarJson("MEDICAMENTOS PostOrden");
            return View();
        }
        public ActionResult MostrarIn()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            if (a == 0)
                a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(3, a);
            ViewBag.Matriz = mostrar;
            GuardarJson("MEDICAMENTOS InOrden");
            return View();
        }
        public ActionResult MostrarPre()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            if (a == 0)
                a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(2, a);
            ViewBag.Matriz = mostrar;
            GuardarJson("MEDICAMENTOS PreOrden");
            return View();
        }
        public static LibraryClassTrees.MedicamentoBT BuscarC;
        public ActionResult BuscarNombre()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            var visi = medicamentos;
            foreach (var item in visi)
            {
                if ((Request.Form["Nombre"]) == item.Nombre)
                {
                    BuscarC = new LibraryClassTrees.MedicamentoBT { Id = item.Id, Nombre = item.Nombre, Cantidad = item.Cantidad, Precio = item.Precio };
                    ViewBag.Mostrar = BuscarC;
                }
            }
            return View();
        }
        public ActionResult BuscarNombre2()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            return View();
        }
        public LibraryClassTrees.MedicamentoBT v1;
        public ActionResult NuevoMedicamento()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            return View();
        }
        public ActionResult Ingresa(string Nombre, int Id, double Precio)
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            Random num = new Random();
            int Cantidad = num.Next(0, 15);
            v1 = new LibraryClassTrees.MedicamentoBT { Nombre = Nombre, Id = Id, Precio = Precio, Cantidad = Cantidad };
            ArbolMedicamentos.AgregarElemento(v1);
            a++;
            return View(v1);
        }

        public ActionResult Pedir()
        {
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            ViewBag.Pedir = BuscarC;
            return View();
        }
        public ActionResult RealizarPedido(string Nombre, string Direccion, int Nit)
        {
            int Cantidad = 1;
            if (ArbolMedicamentos.Raiz == null)
                leerArchivo();

            if (Cantidad == BuscarC.Cantidad)
            {
                ArbolMedicamentos.EliminarElemento(BuscarC.Id);
            }
            else
            {
                BuscarC.Cantidad = Cantidad;
                ArbolMedicamentos.ActualizaDatos(BuscarC);
            }

            return View();
        }
        public void GuardarJson(string A)
        {
            string path;
            string pathJ;
            path = @"~/App_Data/ " + A + ".txt"; 
            pathJ = @"~/App_Data/ " + A + ".txt";
            string root = @"~/App_Data/ ";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!System.IO.File.Exists(path))
            {
                using (FileStream strm = System.IO.File.Create(path))
                using (StreamWriter sw = new StreamWriter(strm))
                {
                    sw.WriteLine("No_Info");
                    sw.Close();
                }
            }
            using (StreamWriter file = System.IO.File.CreateText(@"C:\LAB3\" + A + ".txt"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, mostrar);
            }
        }
    }
}
