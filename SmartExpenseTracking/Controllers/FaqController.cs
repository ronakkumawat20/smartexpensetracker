using Microsoft.AspNetCore.Mvc;
using SET.Models;
using SET.Service.Interface;

namespace SmartExpenseTracker.Controllers
{
    public class FaqController : Controller
    {
        private readonly IFaqService _faqService;
        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FaqViewModel model)
        {
            if (ModelState.IsValid)
            {
                var faqs = await _faqService.Add(model);
                return RedirectToAction("GetAll");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faqs = await _faqService.GetAll();
            return View(faqs);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid uniqueId)
        {
            var faq = await _faqService.GetById(uniqueId);
            return View(faq);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FaqViewModel model)
        {
            var faq = await _faqService.Update(model);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid uniqueId)
        {
            await _faqService.Delete(uniqueId);
            return RedirectToAction("GetAll");
        }
    }
}
