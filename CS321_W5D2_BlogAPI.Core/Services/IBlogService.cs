using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public interface IBlogService
    {
        Blog Add(Blog newBlog);
        Blog Update(Blog updatedBlog);
        Blog Get(int id);
        IEnumerable<Blog> GetAll();
      //Should this be int id?? Or Blog blog??
        void Remove(int id);
    }
}
