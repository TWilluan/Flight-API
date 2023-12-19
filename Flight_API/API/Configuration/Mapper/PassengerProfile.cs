

using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Configuration.Mapper;

public class PassengerProfile : Profile
{
    public PassengerProfile()
    {
        CreateMap<PassengerObject, Reponse_PassengerDTO>().ReverseMap();
        CreateMap<PassengerObject, Reponse_PassengerDetailDTO>().ReverseMap();
        CreateMap<Create_PassengerDTO, PassengerObject>();
        CreateMap<Update_PassengerDTO, PassengerObject>();
    }
}