using EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseApplication.Repository;
namespace EntityFrameworkUsingCrud.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository empRepo = null;
        public EmployeeController()
        {
            empRepo = new EmployeeRepository();
        }
        public ActionResult Index()
        {
            var data = empRepo.GetAllEmployee();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddressModel model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = empRepo.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Recorded is Added";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = empRepo.GetEmployee(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            empRepo.UpdateEmployee(model.Id,model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            empRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}