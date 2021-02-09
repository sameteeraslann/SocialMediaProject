using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterProject.Application.Models.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        //Remember me
        public bool Rememberme { get; set; }
    }
}
