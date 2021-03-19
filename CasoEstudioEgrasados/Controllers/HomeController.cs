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
            OperacionUsuario ou = new OperacionUsuario();
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
            OperacionUsuario op = new OperacionUsuario();
            Usuario usu = new Usuario
            {
                Usu_documento = int.Parse(collection["usu_documento"]),
                Usu_tipodoc = collection["usu_tipodoc"],
                Usu_nombre = collection["usu_nombre"],
                Usu_celular = int.Parse(collection["usu_celular"],
                Usu_email = collection["usu_email"],
                Usu_genero = collection["usu_genero"],
                Usu_aprendiz = int.Parse(collection["usu_aprendiz"]),
                Usu_egresado = int.Parse(collection["usu_egresado"]),
                Usu_areaformacion = collection["usu_areaformacion"],
                Usu_fechaegresado = collection["usu_fechaegresado"],
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
