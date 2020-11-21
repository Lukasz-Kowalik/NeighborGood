using FluentValidation;
using NeighborGood.API.DTOs.Requests;
using NeighborGood.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborGood.API.Validation
{
    public class RegisterUserRequestValidator:AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.PhoneNumber).NotEmpty();
            RuleFor(u => u.Type).NotEmpty();
        }
    }
}
