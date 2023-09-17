using Atomicy.App.Contracts;
using Atomicy.App.Services.Base;
using Atomicy.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.App.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
        public string Message { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategories();
           
        }
    }
}
