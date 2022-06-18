using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordAPI.Models.AddDTO
{
    public class NewUserDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Imię zawiera zbyt dużo znaków!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Nazwisko zawiera zbyt dużo znaków!")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "E-mail może zawierać maksymalnie 30 znaków")]
        public string Email { get; set; }
        [Required]
        [StringLength(9)]
        public string PhoneNumber { get; set; }
    }
}
