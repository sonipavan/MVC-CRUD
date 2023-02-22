using MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities Database1Entities = new Database1Entities();
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<MVC_Tbl_Emplyee> data = Database1Entities.MVC_Tbl_Emplyee.ToList();
            ViewData.Model = data;
            return View(data);
        }
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MVC_Tbl_Emplyee Emplyee)
        {
            if(ModelState.IsValid)
            {
                //add data to  tbl model
                Database1Entities.MVC_Tbl_Emplyee.Add(Emplyee);
                //save
                Database1Entities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int Id)
        {
            var data = Database1Entities.MVC_Tbl_Emplyee.Where(x => x.Id == Id).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(MVC_Tbl_Emplyee data1)
        {
            var data = Database1Entities.MVC_Tbl_Emplyee.FirstOrDefault(x => x.Id == data1.Id);
            if(data!=null)
            {
                data.Emp_Name = data1.Emp_Name;
                data.Emp_MobileNo = data1.Emp_MobileNo;
                data.Emp_Gender = data1.Emp_Gender;
                data.Emp_Age = data1.Emp_Age;
                Database1Entities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            var Data = Database1Entities.MVC_Tbl_Emplyee.Where(x => x.Id == Id).SingleOrDefault();
            return View(Data);
        }
        [HttpPost]
        public ActionResult Delete(MVC_Tbl_Emplyee mVC_Tbl_Emplyee)
        {
            var data = Database1Entities.MVC_Tbl_Emplyee.FirstOrDefault(x=>x.Id == mVC_Tbl_Emplyee.Id);
            if (data!=null)
            {
                Database1Entities.MVC_Tbl_Emplyee.Remove(data);
                Database1Entities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
    
}