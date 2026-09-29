using Microsoft.EntityFrameworkCore;
using SET.Entity;
using SET.Infrastructure;
using SET.Repository.Interface;

namespace SET.Repository
{
    public class FaqRepository : IFaqRepository
    {
        public readonly SetDbContext _context;
        public FaqRepository(SetDbContext context)
        {
            _context = context;
        }
        public async Task<Faq> Add(Faq faq)
        {
            await _context.Faq.AddAsync(faq);
            await _context.SaveChangesAsync();
            return faq;
        }

        public async Task<List<Faq>> GetAll()
        {
            var faqs = await _context.Faq.Where(a => !a.IsDeleted).ToListAsync();
            return faqs;
        }

        public async Task<Faq> GetById(Guid uniqueId)
        {
            var faq = await _context.Faq.FirstOrDefaultAsync(a => a.UniqueId == uniqueId);
            return faq;
        }

        public async Task<Faq> Update(Faq faq)
        {
            _context.Faq.Update(faq);
            await _context.SaveChangesAsync();
            return faq;
        }
    }
}
