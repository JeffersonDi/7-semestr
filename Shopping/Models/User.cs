using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class User
    {
        [Required(ErrorMessage = "Поле 'Имя пользователя' пустое"), MinLength(2, ErrorMessage = "Минимальная длина 2 символа"),
            Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле 'Email' пустое"), MinLength(2, ErrorMessage = "Минимальная длина 2 символа"),
            Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(2, ErrorMessage = "Минимальная длина 2 символа"),
            Display(Name = "Пароль"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
