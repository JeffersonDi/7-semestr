using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' пустое"), MinLength(2, ErrorMessage = "Минимальная длина 2 символа"),
             Display(Name = "Имя")]
        //[RegularExpression(@"^\D+$", ErrorMessage = "Разрешены только буквы")]
        public string Name { get; set; }
        [Display(Name = "Сокращение")]
        public string Slug { get; set; }
        public int Sorting { get; set; }
    }
}
