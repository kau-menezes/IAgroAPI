// using FluentValidation;
// using IAgro.Application.Features.Fields.Update;

// namespace IAgro.Application.Features.Companies.Update;

// public class UpdateFieldValidator : AbstractValidator<UpdateFieldRequest>
// {
//     public UpdateFieldValidator()
//     {
//         RuleFor(c => c.Props.Nickname)
//             .NotEmpty()
//             .MinimumLength(2)
//             .MaximumLength(35)
//             .When(c => c.Props.Nickname is not null);

//         RuleFor(c => c.Props.Area)
//             .NotEmpty()
//             .When(c => c.Props.Area is not null);

//         RuleFor(c => c.Props.Country)
//             .NotEmpty()
//             .MinimumLength(2)
//             .MaximumLength(35)
//             .When(c => c.Props.Country is not null);
//     }
// }