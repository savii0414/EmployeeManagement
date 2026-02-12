using System.Web.Mvc;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Web.Controllers
{
    public class WorkingDaysController : Controller
    {
        private readonly IWorkingDayService _workingDayService;

        public WorkingDaysController(IWorkingDayService workingDayService)
        {
            _workingDayService = workingDayService;
        }

        // GET: /WorkingDays
        public ActionResult Index()
        {
            return View(new WorkingDaysViewModel());
        }

        // POST: /WorkingDays/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(WorkingDaysViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.WorkingDays = _workingDayService.Calculate(model.StartDate.Value, model.EndDate.Value);
            }

            return View("Index", model);
        }
    }
}