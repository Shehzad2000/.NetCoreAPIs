using AutoMapper;
using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandProvider brandProvider;
        private readonly IMapper mapper;

        public BrandController(IBrandProvider brandProvider, IMapper Mapper)
        {
            this.brandProvider = brandProvider;
            mapper = Mapper;
        }

        [HttpPost, Route("BrandRegisteration")]
        public async Task<IActionResult> BrandRegisteration(BrandModel model)
        {
            BrandDomain brand = mapper.Map<BrandDomain>(model);
            return Ok(await brandProvider.BrandRegisteration(brand));
        }
        [HttpPost, Route("UpdateBrandDetails")]
        public async Task<IActionResult> Update(BrandModel model)
        {
            BrandDomain brandDomain = mapper.Map<BrandDomain>(model);
            return Ok(await brandProvider.UpdateBrandDetails(brandDomain));
        }
        [HttpPost, Route("GetBrand")]
        public async Task<IActionResult> GetBrand(BrandModel model)
        {
            BrandDomain brandDomain = mapper.Map<BrandDomain>(model);
            return Ok(await brandProvider.GetBrand(brandDomain.BrandID));
        }
        [HttpGet, Route("GetBrands")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await brandProvider.GetBrands());
        }
        [HttpPost, Route("RemoveBrand")]
        public async Task<IActionResult> Remove(BrandModel model)
        {
            BrandDomain brandDomain = mapper.Map<BrandDomain>(model);
            return Ok(await brandProvider.RemoveBrand(brandDomain.BrandID));
        }
    }
}
