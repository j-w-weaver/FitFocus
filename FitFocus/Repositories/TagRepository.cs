﻿using FitFocus.Data;
using FitFocus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitFocus.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FitFocusDbContext blogDbContext;

        public TagRepository(FitFocusDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDbContext.Tags.AddAsync(tag);
            await blogDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                blogDbContext.Tags.Remove(existingTag);
                await blogDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await blogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null) 
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await blogDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
