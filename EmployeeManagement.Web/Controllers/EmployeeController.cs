using System.Linq;
using System.Web.Mvc;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // ---------------------------
        // GET: Employee (List)
        // ---------------------------
        public ActionResult Index()
        {
            var employees = _service.GetAll()
                .Select(e => new EmployeeViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    JobPosition = e.JobPosition,
                    CreatedDate = e.CreatedDate
                }).ToList();

            return View(employees);
        }

        // ---------------------------
        // GET: Create Employee
        // ---------------------------
        public ActionResult Create()
        {
            return View();
        }

        // ---------------------------
        // POST: Create Employee
        // ---------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = new Employee
            {
                Name = vm.Name,
                Email = vm.Email,
                JobPosition = vm.JobPosition
            };

            _service.Create(entity);
            return RedirectToAction("Index");
        }

        // ---------------------------
        // GET: Edit Employee
        // ---------------------------
        public ActionResult Edit(int id)
        {
            var emp = _service.GetById(id);

            if (emp == null)
                return HttpNotFound();

            var vm = new EmployeeViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                JobPosition = emp.JobPosition
            };

            return View(vm);
        }

        // ---------------------------
        // POST: Edit Employee
        // ---------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = new Employee
            {
                Id = vm.Id,
                Name = vm.Name,
                Email = vm.Email,
                JobPosition = vm.JobPosition
            };

            _service.Update(entity);
            return RedirectToAction("Index");
        }

        // ---------------------------
        // GET: Delete Employee (Confirmation Page)
        // ---------------------------
        public ActionResult Delete(int id)
        {
            var emp = _service.GetById(id);

            if (emp == null)
                return HttpNotFound();

            var vm = new EmployeeViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                JobPosition = emp.JobPosition
            };

            return View(vm);
        }

        // ---------------------------
        // POST: Delete Employee
        // ---------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel vm)
        {
            _service.Delete(vm.Id);
            return RedirectToAction("Index");
        }
    }
}
