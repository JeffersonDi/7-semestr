using Microsoft.AspNetCore.Http;
using Shopping.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Название' пустое"), MinLength(2, ErrorMessage = "Минимальная длина 2 символа"),
            Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Сокращение")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Поле 'Описание' пустое"), MinLength(4, ErrorMessage = "Минимальная длина 4 символа"),
             Display(Name = "Описание")]
        public string Description { get; set; }

        [Column(TypeName ="decimal(18,2)"), Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Категория"), Range(1,int.MaxValue, ErrorMessage ="Вы должны выбрать категорию")]
        public int CategoryId { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped, FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
