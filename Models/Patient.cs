using System.ComponentModel.DataAnnotations;

namespace MvcPatients.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string SocialSecurityNumber { get; set; }
    public DateTime CreatedDate { get; set; }
}