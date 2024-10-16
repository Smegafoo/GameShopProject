using Entities.Concrete;
using Entities.DTO_s.Requests.GameReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class GameReviewValidator : AbstractValidator<GameReview>
    {
        public GameReviewValidator()
        {
            RuleFor(p => p.Review).NotEmpty();
            RuleFor(p => p.GameId).NotEmpty();
            RuleFor(p=> p.ReviewPoint).NotEmpty();
            RuleFor(p => p.ReviewPoint).InclusiveBetween(0,100);
        }
    }
}
