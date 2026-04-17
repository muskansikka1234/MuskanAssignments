using Microsoft.AspNetCore.Identity;
using StudentInquiryAPI.Models;

public class User : IdentityUser
{
   // public string Username { get; set; }
    public string MobileNumber { get; set; }
    public string UserRole { get; set; }

    public Student? Student { get; set; }
}