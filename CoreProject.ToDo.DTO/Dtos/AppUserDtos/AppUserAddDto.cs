using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.ToDo.DTO.Dtos.AppUserDtos
{
    public class AppUserAddDto
    {
        //[Required(ErrorMessage = "Kulanıcı adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        //[Display(Name = "Parola:")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        //[Display(Name = "Parolanızı Tekrar Giriniz:")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //[EmailAddress(ErrorMessage = "Geçersiz Email Adresi")]
        //[Required(ErrorMessage = "Email boş geçilemez")]
        //[Display(Name = "Email:")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Ad boş geçilemez")]
        //[Display(Name = "Ad:")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Soyad boş geçilemez")]
        //[Display(Name = "Soyad:")]
        public string Surname { get; set; }
    }
}
