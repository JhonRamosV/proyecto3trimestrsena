using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto3trimestresena.Models;

namespace proyecto3trimestresena.Controllers
{
    public class Producto_compraController : Controller
    {
        // GET: Producto_compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_compra.ToList());
            }
        }

        public static DateTime NombreCompra(int id_Compra)
        {
            using (var db = new inventario2021Entities())
            {
                return db.compra.Find(id_Compra).fecha;
            }
        }



        public ActionResult ListarCompra()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public static string NombreProducto(int id_Producto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(id_Producto).nombre;
            }
        }



        public ActionResult ListarProducto()
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

        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_compra.Add(producto_Compra);
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
                return View(db.producto_compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                producto_compra producto_compraEdit = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(producto_compraEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_compra producto_CompraEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldproducto_compra = db.producto_compra.Find(producto_CompraEdit.id);
                    oldproducto_compra.cantidad = producto_CompraEdit.cantidad;
                    oldproducto_compra.compra = producto_CompraEdit.compra;
                    oldproducto_compra.producto = producto_CompraEdit.producto;

           
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
                    producto_compra producto_Compra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(producto_Compra);
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