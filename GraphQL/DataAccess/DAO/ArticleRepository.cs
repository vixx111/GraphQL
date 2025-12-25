using GraphQL.Data;
using GraphQL.Entity;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class ArticleRepository
    {
        private readonly AppDbContext _context;
        public ArticleRepository(AppDbContext context) => _context = context;

        public List<Article> GetArticlesByJournalNumber(int journalNumber) =>
            _context.Articles
                .Where(a => a.JournalNumber == journalNumber)
                .Include(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.Fee)
                .ToList();

        public decimal CalculateHonorariumForJournal(int journalNumber) =>
            _context.Articles
                .Where(a => a.JournalNumber == journalNumber)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);

        public List<Article> GetArticlesByAuthor(int authorId) =>
            _context.Articles
                .Where(a => a.AuthorId == authorId)
                .Include(a => a.Fee)
                .ToList();

        public List<Article> GetArticlesByCategory(int categoryId) =>
            _context.Articles
                .Where(a => a.CategoryId == categoryId)
                .Include(a => a.Author)
                .ToList();

        public decimal CalculateHonorariumForCategory(int categoryId, DateTime startDate, DateTime endDate) =>
            _context.Articles
                .Where(a => a.CategoryId == categoryId &&
                           a.PublicationDate >= startDate &&
                           a.PublicationDate <= endDate)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);

        public async Task<Article> CreateArticle(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return article;
        }
        public async Task<bool> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null) return false;

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<Article> GetAllArticles() =>
    _context.Articles
        .Include(a => a.Author)
        .Include(a => a.Category)
        .Include(a => a.Fee)
        .ToList();

        public List<ArticleWithFeeDto> GetAuthorArticlesWithFees(int authorId)
        {
            return _context.Articles
                .Where(a => a.AuthorId == authorId)
                .Include(a => a.Fee)
                .Select(a => new ArticleWithFeeDto
                {
                    Article = a,
                    FeeAmount = a.Fee != null ? a.Fee.Amount : 0
                })
                .ToList();
        }

        public class ArticleWithFeeDto
        {
            public Article Article { get; set; }
            public decimal FeeAmount { get; set; }
        }
    }

}