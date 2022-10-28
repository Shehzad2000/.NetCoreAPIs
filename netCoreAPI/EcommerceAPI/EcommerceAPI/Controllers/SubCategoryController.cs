using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryProvider subCategoryProvider;

        public SubCategoryController(ISubCategoryProvider subCategoryProvider)
        {
            this.subCategoryProvider = subCategoryProvider;
        }
        [HttpPost, Route("AddSubcategory")]
        public async Task<IActionResult> AddSubCategory(SubCategoryDomain subCategory)
            => Ok(await subCategoryProvider.RegisterSubCategory(subCategory));
        [HttpPost, Route("UpdateSubCategory")]
        public async Task<IActionResult> UpdateSubCategory(SubCategoryDomain subCategory)
            => Ok(await subCategoryProvider.UpdateSubCategory(subCategory));
        [HttpPost, Route("DeleteSubCategory")]
        public async Task<IActionResult> Delete(SubCategoryDomain subCategory)
            => Ok(await subCategoryProvider.DeleteSubCategory(subCategory.SubCategoryId));
        [HttpGet, Route("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories()
            => Ok(await subCategoryProvider.GetAllSubCategories());
        [HttpGet, Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
            => Ok(await subCategoryProvider.GetCategories());
        [HttpPost, Route("GetSubCategoryByID")]
        public async Task<IActionResult> GetSubcategory(SubCategoryDomain subCategory)
            => Ok(await subCategoryProvider.GetSubCategory(subCategory));
        [HttpPost, Route("GetSubCategoryByCatID")]
        public async Task<IActionResult> GetSubCategoryByCatID(SubCategoryDomain subCategory)
            => Ok(await subCategoryProvider.GetSubCategoryByCatID(subCategory));
    }
}
