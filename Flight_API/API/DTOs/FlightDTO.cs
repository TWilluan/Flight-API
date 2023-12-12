

using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class Create_FlightDTO : DTOs
{

}

public class Update_FlightDTO : Create_FlightDTO, DTOs { }

public class Reponse_FlightDTO : DTOs
{
}

public class Repons_FlightDetailDTO : Reponse_FlightDTO, DTOs
{
}