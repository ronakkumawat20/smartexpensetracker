using SET.Entity;

namespace SET.Repository.Interface
{
    public interface IFaqRepository
    {
        Task<List<Faq>> GetAll();
        Task<Faq> GetById(Guid uniqueId);
        Task<Faq> Add(Faq faq);
        Task<Faq> Update(Faq faq);

    }
}
