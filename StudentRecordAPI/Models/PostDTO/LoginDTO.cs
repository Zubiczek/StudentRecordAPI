using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordAPI.Models.AddDTO
{
    public class LoginDTO
    {
        [Required]
        [MaxLength(30, ErrorMessage = "E-mail może zawierać maksymalnie 30 znaków")]
        public string Email { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Hasło może zawierać maksymalnie 30 znaków")]
        public string Password { get; set; }
    }
}
