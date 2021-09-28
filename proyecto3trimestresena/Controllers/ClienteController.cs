using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto3trimestresena.Models;
using System.IO;

namespace proyecto3trimestresena.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize]
        // GET: Cliente
        public ActionResult Index()
        {

            using (var db = new inventario2021Entities())
            {
                return View(db.cliente.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.cliente.Add(cliente);
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
                var findUser = db.cliente.Find(id);
                return View(findUser);
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {

                using (var db = new inventario2021Entities())
                {
                    var findUser = db.cliente.Find(id);

                    db.cliente.Remove(findUser);
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


        public ActionResult Edit(int id)
        {
            try
            {

                using (var db = new inventario2021Entities())
                {
                    cliente findUser = db.cliente.Where(a => a.id == id).FirstOrDefault();
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

        public ActionResult Edit(cliente editUser)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    cliente user = db.cliente.Find(editUser.id);

                    user.nombre = editUser.nombre;
                    user.documento = editUser.documento;
                    user.email = editUser.email;
                    

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
                if (fileForm != null)
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

                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            var newCliente = new cliente
                            {
                                nombre = row.Split(';')[0],
                                documento = row.Split(';')[1],
                                email = row.Split(';')[2],
                              
                            };
                            using (var db = new inventario2021Entities())
                            {
                                db.cliente.Add(newCliente);
                                db.SaveChanges();
                            }
                        }
                    }


                }

                return View();


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


        }
        
}