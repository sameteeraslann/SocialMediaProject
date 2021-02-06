using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TwitterProject.Application.Models.DTOs
{
    public class EditProfileDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Must to type into name")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
