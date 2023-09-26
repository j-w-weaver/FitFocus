using FitFocus.Data;
using FitFocus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitFocus.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly FitFocusDbContext blogDbContext;

        public BlogPostLikeRepository(FitFocusDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogDbContext.BlogPostLike.AddAsync(blogPostLike);
            await blogDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid id)
        {
            return await blogDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == id);
        }
    }
}
