using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel.DataAnnotations;


namespace SellAndBuy.Web.Models.Adds
{
    public class CreateAddViewModel
    {
        const int minLenght = 4;
        const int maxLenght = 200;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Price")]
        public double Price { get; set; }
        [Required]
        [StringLength(maxLenght, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = minLenght)]
        public string Description { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string Category { get; set; }


        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [Display(Name = "Image")]
        public HttpPostedFileBase File { get; set; }


        public ICollection<string> Cities { get; set; }

        public ICollection<string> Categories { get; set; }

    }
}
