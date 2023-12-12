


using System.ComponentModel.DataAnnotations;

namespace API.Models;

/*********************************************************
    Represents a people object containing a person's 
        general information
**********************************************************/
public class People
{
    [Required]
    [MaxLength(24)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(24)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "The email is not valid")]
    public string Email { get; set; } = string.Empty + "@gmail.com";
}