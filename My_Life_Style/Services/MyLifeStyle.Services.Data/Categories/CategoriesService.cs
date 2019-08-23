﻿namespace MyLifeStyle.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext context;

        public CategoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllCategories<TViewModel>()
        {
            var categories = this.context.Categories
                  .OrderBy(x => x.ArticlesCount).ThenBy(x => x.Name)
                  .To<TViewModel>()
                  .ToList();

            return categories;
        }
    }
}