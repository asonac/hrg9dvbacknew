﻿using FluentValidation;
using System.Collections.Generic;

namespace Integration.Application.Features.Commands.UpdateIntegration
{
    public class UpdateIntegrationValidator : AbstractValidator<UpdateIntegrationCommand>
    {
        public UpdateIntegrationValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty().WithMessage("{Id} is required.");

            RuleFor(p => p.ShowName || p.ShowAge || p.ShowPhone || p.ShowEmailAddress)
                .Must(x => { return x == true; }).When(x => x.EmailTo != "").WithMessage("Atleast one of the fields must be chosen. {ShowName}, {ShowAge}, {ShowPhone} or {ShowEmailAddress}");

            RuleFor(p => p.PayloadShowName || p.PayloadShowAge || p.PayloadShowPhone || p.PayloadShowEmailAddress)
              .Must(x => { return x == true; }).When(x => x.Link != "" && x.Method != null).WithMessage("Atleast one of the fields must be chosen. {ShowName}, {ShowAge}, {ShowPhone} or {ShowEmailAddress}");

            RuleFor(p => p.UserEmailTitle)
               .NotEmpty().WithMessage("{UserEmailTitle} is required.");

            RuleFor(p => p.UserTemplate)
               .NotEmpty().WithMessage("{UserTemplate} is required.");

            RuleFor(p => p.EmailTo)
            .EmailAddress().When(email => email.EmailTo != "").WithMessage("A valid email is required");

            RuleFor(p => p.CustomEmailTitle)
              .NotEmpty().When(x => !string.IsNullOrEmpty(x.EmailTo)).WithMessage("{CustomEmailTitle} is required.");

            RuleFor(p => p.CustomTemplate)
             .NotEmpty().When(x => !string.IsNullOrEmpty(x.EmailTo)).WithMessage("{UserEmailTitle} is required.");

            RuleFor(p => p.FileFormat)
                 .Must(x =>
                 {
                     List<string> formats = new List<string>
                    {
                        "",
                        "csv",
                        "json",
                        "xml"
                    };

                     return formats.Contains(x.ToLower());
                 }).WithMessage("Invalid file format!"); ;

            RuleFor(p => p.Method)
               .Must(x =>
               {
                   List<string> methods = new List<string>
                  {
                       "",
                        "get",
                        "post",
                  };

                   return methods.Contains(x.ToLower());
               }).WithMessage("Invalid methods. Choose [GET] or [POST]."); ;

            RuleFor(p => p.Payload)
                .Must(x =>
                {
                    List<string> formats = new List<string>
                   {
                        "",
                        "csv",
                        "json",
                        "xml"
                   };

                    return formats.Contains(x.ToLower());
                }).WithMessage("Invalid file format!");
        }
    }
}
