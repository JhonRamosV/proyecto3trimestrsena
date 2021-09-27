using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto3trimestresena.Models;
using System.IO;
namespace proyecto3trimestresena.Controllers
{
    
    public class ProveedorController : Controller
    {
        
        // GET: Proveedor
        public ActionResult Index()
        {

            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {

                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
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
                var findUser = db.proveedor.Find(id);
                return View(findUser);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {

                using (var bd = new inventario2021Entities())
                {
                    var findUser = bd.proveedor.Find(id);

                    bd.proveedor.Remove(findUser);
                    bd.SaveChanges();
                    return RedirectToAction("index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                using (var bd = new inventario2021Entities())
                {
                    proveedor findUser = bd.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }




        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(proveedor editUser)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor user = db.proveedor.Find(editUser.id);

                    user.nombre = editUser.nombre;
                    user.direccion = editUser.direccion;
                    user.telefono = editUser.telefono;
                    user.nombre_contacto = editUser.nombre_contacto;

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



        public ActionResult uploadCSV()
        {
            return View();
        }


        [HttpPost]

        public ActionResult uploadCSV(HttpPostedFileBase fileForm)
        {
            try
            {

                string filePath = string.Empty;
                if(fileForm != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(fileForm.FileName);

                    string extension = Path.GetExtension(fileForm.FileName);

                    fileForm.SaveAs(filePath);

                    string csvData = System.IO.File.ReadAllText(filePath);

                    foreach(string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            var newProveedor = new proveedor
                            {
                                nombre = row.Split(';')[0],
                                direccion = row.Split(';')[1],
                                telefono = row.Split(';')[2],
                                nombre_contacto = row.Split(';')[3]
                            };
                            using (var db = new inventario2021Entities())
                            {
                                db.proveedor.Add(newProveedor);
                                db.SaveChanges();
                            }
                        }
                    }

               
                }

                return View();


            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}