using GraphQL.Data;
using GraphQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class FeeRepository
    {
        private readonly AppDbContext _context;
        public FeeRepository(AppDbContext context) => _context = context;

        public decimal CalculateHonorariumForJournal(int journalNumber) =>
            _context.Articles
                .Where(a => a.JournalNumber == journalNumber)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);

        public List<decimal> GetAuthorFeesPerArticle(int authorId) =>
            _context.Articles
                .Where(a => a.AuthorId == authorId)
                .Include(a => a.Fee)
                .Select(a => a.Fee != null ? a.Fee.Amount : 0)
                .ToList();

        public decimal CalculateHonorariumForCategory(int categoryId, DateTime startDate, DateTime endDate) =>
            _context.Articles
                .Where(a => a.CategoryId == categoryId &&
                           a.PublicationDate >= startDate &&
                           a.PublicationDate <= endDate)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);

        public decimal CalculateAuthorTotalHonorarium(int authorId) =>
            _context.Articles
                .Where(a => a.AuthorId == authorId)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);

        public async Task<Fee> CreateFee(Fee fee)
        {
            await _context.Fees.AddAsync(fee);
            await _context.SaveChangesAsync();
            return fee;
        }

        public async Task<Fee> UpdateFee(Fee fee)
        {
            _context.Fees.Update(fee);
            await _context.SaveChangesAsync();
            return fee;
        }

        public async Task<Fee> GetFeeById(int id)
        {
            return await _context.Fees.FindAsync(id);
        }
        public List<Fee> GetAllFees() =>
    _context.Fees
        .Include(f => f.Author)
        .Include(f => f.Articles)
        .ThenInclude(a => a.Category)
        .OrderByDescending(f => f.PaymentDate)
        .ToList();
    }
}