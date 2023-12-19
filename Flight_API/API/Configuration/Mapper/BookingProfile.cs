

using API.DTOs;
using AutoMapper;
using API.Models;

namespace API.Configuration.Mapper;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<PassengerFlight_Booking, Reponse_BookingDTO>().ReverseMap();
    }
}