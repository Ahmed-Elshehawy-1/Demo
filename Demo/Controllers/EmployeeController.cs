using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        ITIEntity context = new ITIEntity();

        public IActionResult New()
        {
            ViewData["Dept_List"] = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewData["Dept_List"] = context.Departments.ToList();
            return View("New" , employee);
        }
        public IActionResult Index()
        {
            List<Employee> Emplist = context.Employees.ToList();
            return View(Emplist);
        }

        public IActionResult Edit(int id)
        {
            Employee empModel = context.Employees.FirstOrDefault(x => x.Id == id);
            ViewData["Dept_List"] = context.Departments.ToList();
            return View(empModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id,Employee newEmp)
        {
            if(ModelState.IsValid)
            {
                Employee oldEmployee = context.Employees.FirstOrDefault(x=>x.Id == id);
                if(oldEmployee != null)
                {
                    oldEmployee.Name = newEmp.Name;
                    oldEmployee.Dept_Id = newEmp.Dept_Id;
                    oldEmployee.Image = newEmp.Image;
                    oldEmployee.salary = newEmp.salary;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewData["DeptList"] = context.Departments.ToList();
            return View("Edit", newEmp);
        }
    }
}
