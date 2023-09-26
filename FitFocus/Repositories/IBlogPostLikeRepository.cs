using FitFocus.Models.Domain;

namespace FitFocus.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);

        Task<BlogPostLike>AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
