using GraphQL.Entity;
using GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DAO
{
    public class AuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context) => _context = context;

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorById(int id) => _context.Authors.Find(id);

        public decimal GetAuthorTotalHonorarium(int authorId) =>
            _context.Articles
                .Where(a => a.AuthorId == authorId)
                .Include(a => a.Fee)
                .Sum(a => a.Fee != null ? a.Fee.Amount : 0);
        public async Task<Author> CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Author> UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        internal async Task<bool> DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}