﻿using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        IEnumerable<PostCategory> GetByAlias(string alias);
    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<PostCategory> GetByAlias(string alias)
        {
            return this.DbContext.PostCategories.Where(x => x.Alias == alias);
        }
    }
}