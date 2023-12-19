


using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Configuration.Mapper;

public class FlightProfile : Profile
{
    public FlightProfile()
    {
        CreateMap<FlightObject, Reponse_FlightDTO>().ReverseMap();
        CreateMap<FlightObject, Reponse_FlightDetailDTO>().ReverseMap();
        CreateMap<Create_FlightDTO, FlightObject>();
        CreateMap<Update_FlightDTO, FlightObject>();
    }
}