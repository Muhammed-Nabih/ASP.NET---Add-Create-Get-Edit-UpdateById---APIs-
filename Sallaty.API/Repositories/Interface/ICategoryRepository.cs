﻿using Sallaty.API.Models.Domain;

namespace Sallaty.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}