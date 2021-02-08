using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Application.Models.DTOs;

namespace TwitterProject.Application.Validations
{
    public class LoginValidation: AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter a UserName");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a Password");
        }
    }
}
