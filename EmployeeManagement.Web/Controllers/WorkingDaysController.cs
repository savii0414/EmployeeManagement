using System.Web.Mvc;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Services.Interfaces;
using System;

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

        // POST: /WorkingDays/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(WorkingDaysViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Validate start date is not Saturday or Sunday
            if (model.StartDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                model.StartDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("StartDate", "Start date cannot be Saturday or Sunday.");
                return View(model);
            }

            // Validate end date is after start date
            if (model.EndDate.Value < model.StartDate.Value)
            {
                ModelState.AddModelError("EndDate", "End date cannot be earlier than start date.");
                return View(model);
            }

            try
            {
                model.WorkingDays = _workingDayService.Calculate(model.StartDate.Value, model.EndDate.Value);
            }
            catch (Exception ex)
            {
                // Show any calculation errors
                ModelState.AddModelError("", ex.Message); // "" shows in the validation summary
            }

            return View(model);
        }
    }
}