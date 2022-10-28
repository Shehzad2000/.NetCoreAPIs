using AutoMapper;
using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private string UploadedFile(IFormFile img)
        {
            string uniqueFileName = null;

            if (img != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public AdminController(IAdminProvider adminProvider, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            AdminProvider = adminProvider;
            WebHostEnvironment = webHostEnvironment;
            Mapper = mapper;
        }

        public IAdminProvider AdminProvider { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IMapper Mapper { get; }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Registeration(AdminModel domains)
        {
            AdminDomain data = Mapper.Map<AdminDomain>(domains);
            for (int i = 0; i < domains.MyImage.Length; i++)
            {
                data.AdminImage = data.AdminImage + "_" + UploadedFile(domains.MyImage[i]);
            }
            return Ok(await AdminProvider.AdminRegisteration(data));
        }
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(AdminDomain admin)
        {
            return Ok(await AdminProvider.AdminLogin(admin));
        }
        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(AdminDomain admin)
        {
            return Ok(await AdminProvider.UpdateAdmin(admin));
        }
        [HttpPost, Route("Delete")]
        public async Task<IActionResult> Delete(AdminDomain admin)
        {
            return Ok(await AdminProvider.RemoveAdmin(admin.AdminID));
        }
        [HttpPost, Route("GetAdminByID")]
        public async Task<IActionResult> GetAdminByID(AdminDomain admin)
        {
            return Ok(await AdminProvider.GetAdminByID(admin.AdminID));
        }
        [HttpGet, Route("GetAdmins")]
        public async Task<IActionResult> GetData()
        {
            return Ok(await AdminProvider.GetAllAdmins());
        }
    }
}
