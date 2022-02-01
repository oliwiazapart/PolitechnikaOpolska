using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using aventuras.common.Enums;
using FluentValidation;

namespace aventuras.BindingModels
{
    public class EditUser
    {
        [Required]
        [Display(Name = "Username")]
        public string Name { get; set; }
       
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "EditionDate")]
        public DateTime EditionDate { get; set; }

        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }

}
