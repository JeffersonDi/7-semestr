using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Page
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле 'Заголовок' пустое"), MinLength(2, ErrorMessage = "Минимальная длина Заголовка 2 символа"), 
            Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Сокращение")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Поле 'Содержание' пустое"), MinLength(4, ErrorMessage = "Минимальная длина Заголовка 4 символа"), 
            Display(Name = "Содержание")]
        public string Content { get; set; }

        public int Sorting { get; set; }
    }
}
