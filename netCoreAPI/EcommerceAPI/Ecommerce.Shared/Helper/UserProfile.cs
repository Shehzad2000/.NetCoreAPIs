using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;

namespace Ecommerce.Shared.Helper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AdminModel, AdminDomain>().ReverseMap();
        }
    }
}
