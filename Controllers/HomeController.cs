using CRUD_CODE_FIRST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace CRUD_CODE_FIRST.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeRepository ER = new EmployeeRepository();        
        public ActionResult Index(int? page)
        {
            var data = ER.Employees.ToList().ToPagedList(page ?? 1, 3);
            return View(data);
        }
        [HttpPost]        
        public ActionResult Index(FormCollection formCollection)
        {
            int res = 0;
            string[] EmpID = formCollection["EmpID"].Split(new char[]{ ','});
            foreach(string id in EmpID)
            {
                var Empid = this.ER.Employees.Find(int.Parse(id));
                this.ER.Employees.Remove(Empid);
                res = this.ER.SaveChanges();
            }
            if (res > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Data Deleted')</script>";
            }
            else
            {
                TempData["DeleteMsg"] = "<script>alert('Deletion Unsuccessfull!!!')</script>";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                ER.Employees.Add(e);
                int res = ER.SaveChanges();
                if (res > 0)
                {
                    TempData["CreateMsg"] = "New Employee Added";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CreateMsg = "<script>alert('No Data Added')</script>";
                    //ModelState.Clear();
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var data = ER.Employees.Where(model => model.EmpID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                ER.Entry(e).State = EntityState.Modified;
                int res = ER.SaveChanges();
                if (res > 0)
                {
                    TempData["UpdateMsg"] = "<script>alert('Data Updated')</script>";
                    //ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CreateMsg = "<script>alert('Updation Unsuccessfull!!!')</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var data = ER.Employees.Where(model => model.EmpID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCofirm(int id)
        {
            /*ER.Entry(e).State = EntityState.Deleted;
            ER.SaveChanges();
            int res = ER.SaveChanges();
            if (res > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Data Deleted')</script>";                      
            }
            else
            {
                TempData["DeleteMsg"] = "<script>alert('Deletion Unsuccessfull!!!')</script>";
            }*/

            Employee e = ER.Employees.Find(id);
            ER.Employees.Remove(e);
            int res = ER.SaveChanges();
            if (res > 0)
            {
                TempData["DeleteMsg"] = "<script>alert('Data Deleted')</script>";
            }
            else
            {
                TempData["DeleteMsg"] = "<script>alert('Deletion Unsuccessfull!!!')</script>";
            }
            return RedirectToAction("Index");
        }
        
    }
}