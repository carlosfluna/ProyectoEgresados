using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoEstudioEgrasados.Models;

namespace CasoEstudioEgrasados.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            OperacionUsuarios ou = new OperacionUsuarios();
            return View(ou.RecuperarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            OperacionUsuarios op = new OperacionUsuarios();
            Usuario usu = new Usuario
            {
                Usu_documento = int.Parse(collection["usu_documento"]),
                Usu_tipodoc = collection["usu_tipodoc"],
                Usu_nombre = collection["usu_nombre"],
                Usu_celular = int.Parse(collection["usu_celular"]),
                Usu_email = collection["Usu_email"],
                Usu_genero = collection["usu_genero"],
                Usu_aprendiz = bool.Parse(collection["usu_aprendiz"]),
                Usu_egresado = bool.Parse(collection["usu_egresado"]),
                Usu_areaformacion = collection["usu_areaformacion"],
                Usu_fechaegresado = DateTime.Parse(collection["usu_fechaegresado"].ToString()),
                Usu_direccion = collection["usu_direccion"],
                Usu_barrio = collection["usu_barrio"],
                Usu_ciudad = collection["usu_ciudad"],
                Usu_departamento = collection["usu_departamento"]
            };
            op.Alta(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
