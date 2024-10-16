using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class GameLibraryValidator : AbstractValidator<GameLibrary>
    {
        public GameLibraryValidator()
        {
            RuleFor(p=> p.PlayerID).NotEmpty();
            RuleFor(p=> p.PlayerName).NotEmpty();
            
        }
    }
}
