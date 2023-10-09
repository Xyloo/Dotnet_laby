using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Contact
    {
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
        public string Surname { get; set; }

        [DisplayName("Adres e-mail")]
        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [EmailAddress(ErrorMessage = "Adres e-mail jest niepoprawny")]
        public string Email { get; set; }

        [DisplayName("Miejscowość")]
        [Required(ErrorMessage = "Miejscowość jest wymagana")]
        [StringLength(200, ErrorMessage = "Miejscowość nie może być dłuższa niż 200 znaków")]
        public string City { get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone(ErrorMessage = "Numer telefonu jest niepoprawny")]
        public string PhoneNumber { get; set; }
    }
}
