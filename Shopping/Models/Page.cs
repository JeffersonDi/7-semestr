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
        [Required]
        [Display(Name ="Заголовок")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Сокращение")]
        public string Slug { get; set; }
        [Required]
        [Display(Name = "Содержание")]
        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
