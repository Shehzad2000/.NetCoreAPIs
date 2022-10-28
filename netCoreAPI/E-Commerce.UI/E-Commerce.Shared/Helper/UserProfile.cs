using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Helper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AdminModel, AdminDomain>().ReverseMap();
        }
    }
}
