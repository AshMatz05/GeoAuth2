using System.ComponentModel.DataAnnotations;

namespace GeoAuth2.Models
{
    public class LoginViewModel
    {
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
