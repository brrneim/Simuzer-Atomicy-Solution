﻿using Atomicy.App.Services;
using Atomicy.App.Services.Base;
using Atomicy.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
    //    Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
     //   Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
