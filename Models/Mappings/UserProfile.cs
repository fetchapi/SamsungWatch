using AutoMapper;
using SamsungWatch.Data.Entities;

namespace SamsungWatch.Models.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>();
    }
}