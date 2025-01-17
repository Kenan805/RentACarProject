﻿using Core.Entities.Conrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).Must(AtLeastOneUppercase).WithMessage("Azi bir boyuk herf olmalidir");
            RuleFor(u => u.Password).Must(AtLeastOneLowercase).WithMessage("Azi bir kicik herf olmalidir"); ;
            RuleFor(u => u.Password).Must(AtLeastOneDigit).WithMessage("Azi bir reqem olmalidir"); ;

        }

        private bool AtLeastOneDigit(string arg)
        {
            return Regex.IsMatch(arg, "(?=.*?[0-9])");
        }

        private bool AtLeastOneLowercase(string arg)
        {
            return Regex.IsMatch(arg, "(?=.*?[a-z])");
        }

        private bool AtLeastOneUppercase(string arg)
        {
            return Regex.IsMatch(arg, "(?=.*?[A-Z])");
        }
    }
}
