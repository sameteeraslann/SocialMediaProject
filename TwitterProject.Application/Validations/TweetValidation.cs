using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterProject.Application.Models.DTOs;

namespace TwitterProject.Application.Validations
{
    public class TweetValidation: AbstractValidator<AddTweetDTO>
    {
        public TweetValidation()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Can not't be empty").MaximumLength(256).WithMessage("Must be less then 256 character");
        }
    }
}
