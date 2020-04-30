using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;
        public PostRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Post Get(int id)
        {
            // Implement Get(id). Include related Blog and Blog.User
            return _dbContext.Posts
                .Include(p => p.Blog)
                .Include(p => p.Blog.User)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            // Implement GetBlogPosts, return all posts for given blog id
            // Include related Blog and AppUser
            return _dbContext.Posts
                .Include(p => p.Blog)
                .Include(p => p.Blog.User)
                .Where(p => p.BlogId == blogId)
                .ToList();
        }

        public Post Add(Post Post)
        {
            // add Post
            _dbContext.Posts.Add(Post);
            _dbContext.SaveChanges();
            return Post;
        }

        public Post Update(Post Post)
        {
            // update Post
            var currentPost = _dbContext.Posts.Find(Post.Id);
            if (currentPost == null) return null;
            _dbContext.Entry(currentPost)
                .CurrentValues
                .SetValues(Post);
            _dbContext.Posts.Update(Post);
            _dbContext.SaveChanges();
            return currentPost;
        }

        public IEnumerable<Post> GetAll()
        {
            // TODO: get all posts
            return _dbContext.Posts
                /*
                 * What all do I need to include?
                 * .Include(p => p.Blog.Name)
                 * .Include(p => p.Blog.User)
                */
                .ToList();
        }

        public void Remove(int id)
        {
            // TODO: remove Post
            _dbContext.Remove(id);
            _dbContext.SaveChanges();
        }

    }
}
