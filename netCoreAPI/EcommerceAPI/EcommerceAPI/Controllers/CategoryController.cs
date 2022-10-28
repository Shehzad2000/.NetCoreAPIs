using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryProvider categoryProvider;

        public CategoryController(ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }
        [HttpPost, Route("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDomain category)
            => Ok(await categoryProvider.RegisterCategory(category));
        [HttpPost, Route("UpdateCategory")]
        public async Task<IActionResult> Update(CategoryDomain category)
            => Ok(await categoryProvider.UpdateCategory(category));
        [HttpPost, Route("DeleteCategory")]
        public async Task<IActionResult> Delete(CategoryDomain category)
            => Ok(await categoryProvider.RemoveCategory(category.CategoryID));
        [HttpGet, Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
            => Ok(await categoryProvider.GetAllCategories());
        [HttpPost, Route("GetCategoryByID")]
        public async Task<IActionResult> GetCategory(CategoryDomain category)
            => Ok(await categoryProvider.GetCategory(category.CategoryID));
    }
}
