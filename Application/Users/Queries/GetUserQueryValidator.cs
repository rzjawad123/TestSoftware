using Application.Users.Query;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator(IStringLocalizer stringLocalizer) 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username cant be empty");    
        }
    }
}
