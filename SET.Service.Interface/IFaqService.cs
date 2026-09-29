using SET.Entity;
using SET.Models;

namespace SET.Service.Interface
{
    public interface IFaqService
    {
        Task<List<FaqViewModel>> GetAll();
        Task<FaqViewModel> GetById(Guid uniqueId);
        Task<bool> Add(FaqViewModel faqViewModel);
        Task<bool> Update(FaqViewModel faqViewModel);
        Task<bool> Delete(Guid uniqueId);
    }
}
