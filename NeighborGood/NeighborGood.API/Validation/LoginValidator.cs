using FluentValidation;
using NeighborGood.Models.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborGood.API.Validation
{
    public class LoginValidator:AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
        }
    }
}
