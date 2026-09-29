using Microsoft.AspNetCore.Mvc;
using SET.Models;
using SET.Service.Interface;

namespace SmartExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAll();
            return View(expenses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _expenseService.Add(model);
                if (result)
                {
                    return RedirectToAction("GetAll");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid uniqueId)
        {
            var expense = await _expenseService.GetById(uniqueId);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _expenseService.Update(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid uniqueId)
        {
            await _expenseService.Delete(uniqueId);
            return RedirectToAction("GetAll");
        }
    }
}
