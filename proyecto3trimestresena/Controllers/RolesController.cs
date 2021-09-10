using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto3trimestresena.Models;
namespace proyecto3trimestresena.Controllers
{
    
    public class RolesController : Controller
    {
        
        // GET: Roles
        public ActionResult Index()
        {

            using (var db = new inventario2021Entities())
            {
                return View(db.roles.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {

                using (var db = new inventario2021Entities())
                {
                    db.roles.Add(roles);
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
                var findUser = db.roles.Find(id);
                return View(findUser);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {

                using (var db = new inventario2021Entities())
                {
                    var findUser = db.roles.Find(id);

                    db.roles.Remove(findUser);
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
                    roles findUser = db.roles.Where(a => a.id == id).FirstOrDefault();
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

        public ActionResult Edit(roles editUser)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    roles user = db.roles.Find(editUser.id);

                    user.descripcion = editUser.descripcion;
                   


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