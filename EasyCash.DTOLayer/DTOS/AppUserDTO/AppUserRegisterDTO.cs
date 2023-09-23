using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DTOLayer.DTOS.AppUserDTO
{
    public class AppUserRegisterDTO
    {
        //[Required(ErrorMessage = "Ad alanını boş geçemezsiniz!")]
        //[Display(Name = "İsim:")]
        //[MaxLength(30, ErrorMessage = "En fazla 30 karakter girilmelidir.")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
