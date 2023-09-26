using FitFocus.Controllers;
using FitFocus.Data;
using FitFocus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitFocus.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly FitFocusDbContext blogDbContext;

        public BlogPostCommentRepository(FitFocusDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
            
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogDbContext.BlogPostComment.AddAsync(blogPostComment);   
            await blogDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await blogDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
