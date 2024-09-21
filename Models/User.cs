using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Models
{

    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is required.")]
        public required string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Birthdate is required.")]
        public DateTime Birthdate { get; set; }

        [RegularExpression(@"^\+\d{1,3}\d{9,12}$", ErrorMessage = "Phone number must be in the format: +<country_code><number>")]
        public required string PhoneNumber { get; set; }


        [Required(ErrorMessage = "LivingCountry is required.")]
        public required string LivingCountry { get; set; }

        [Required(ErrorMessage = "CitizenCountry is required.")]
        public required string CitizenCountry { get; set; }
    }
}
