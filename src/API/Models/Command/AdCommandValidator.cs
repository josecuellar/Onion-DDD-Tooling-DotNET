using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Command
{
    public class AdCommandValidator : AbstractValidator<AdCommand>
    {
          public AdCommandValidator() 
          {
                RuleFor(ad => ad.Id).NotEmpty();
                RuleFor(ad => ad.Title).NotEmpty().WithMessage("Please specify a first name");
                //RuleFor(customer => customer.Discount).NotEqual(0).When(customer => customer.HasDiscount);
                //RuleFor(customer => customer.Address).Length(20, 250);
                //RuleFor(customer => customer.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
          }

          //private bool BeAValidPostcode(string postcode) 
          //{
                // custom postcode validating logic goes here
          //}
    }
}

