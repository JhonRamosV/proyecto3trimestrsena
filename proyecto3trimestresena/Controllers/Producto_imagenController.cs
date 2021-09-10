using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto3trimestresena.Models;

namespace proyecto3trimestresena.Controllers
{
    public class Producto_imagenController : Controller
    {
        
        // GET: Producto_imagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.ToList());
            }
        }

        public static string NombreProductoo(int id_Producto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(id_Producto).nombre;
            }
        }



        public ActionResult ListarProductoo()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_imagen producto_Imagen)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_imagen.Add(producto_Imagen);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                producto_imagen producto_ImagenEdit = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                return View(producto_ImagenEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_imagen producto_ImagenEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldproducto_imagen = db.producto_imagen.Find(producto_ImagenEdit.id);
                    oldproducto_imagen.imagen = producto_ImagenEdit.imagen;
                    oldproducto_imagen.id_producto = producto_ImagenEdit.id_producto;

                    db.SaveChanges();
                    return RedirectToAction("index");








                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_imagen producto_Imagen = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(producto_Imagen);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }
        }
    }
}