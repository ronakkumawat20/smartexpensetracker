using SET.Entity;
using SET.Models;
using SET.Repository.Interface;
using SET.Service.Interface;

//An implementation (e.g., FaqRepository) does the actual database operations
//(using Entity Framework Core, Dapper, ADO.NET, etc.).
//The service calls those methods but doesn't implement them.
namespace SET.Service
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _faqRepository;

        public FaqService(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }

        //_faqRepository is data-access abstraction.

        public async Task<bool> Add(FaqViewModel faqViewModel)
        {
            Faq faq = new()
            {
                UniqueId = Guid.NewGuid(),
                FaqQuestion = faqViewModel.FaqQuestion,
                FaqAnswer = faqViewModel.FaqAnswer,
                CreatedBy = "User",
                CreatedByProgram = "null",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            var newFaq = await _faqRepository.Add(faq);

            if (newFaq != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<FaqViewModel>> GetAll()
        {
            var faqs = await _faqRepository.GetAll();

            List<FaqViewModel> faqList = new();

            foreach (var faq in faqs)
            {
                faqList.Add(new FaqViewModel
                {
                    UniqueId = faq.UniqueId,
                    FaqQuestion = faq.FaqQuestion,
                    FaqAnswer = faq.FaqAnswer
                });
            }

            return faqList;
        }

        public async Task<FaqViewModel> GetById(Guid uniqueId)
        {
            var faq = await _faqRepository.GetById(uniqueId);

            FaqViewModel faqViewModel = new()
            {
                FaqAnswer = faq.FaqAnswer,
                FaqQuestion = faq.FaqQuestion,
                UniqueId = uniqueId
            };

            return faqViewModel;
        }

        public async Task<bool> Update(FaqViewModel faqViewModel)
        {
            Faq faq = await _faqRepository.GetById(faqViewModel.UniqueId);

            faq.FaqQuestion = faqViewModel.FaqQuestion;
            faq.FaqAnswer = faqViewModel.FaqAnswer;
            faq.ModifiedDate = DateTime.Now;

            var updatedFaq = await _faqRepository.Update(faq);

            if (updatedFaq != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid uniqueId)
        {
            Faq faq = await _faqRepository.GetById(uniqueId);
            faq.IsDeleted = true;
            faq.ModifiedDate = DateTime.Now;

            var updatedFaq = await _faqRepository.Update(faq);

            if (updatedFaq != null)
            {
                return true;
            }
            return false;
        }
    }
}
