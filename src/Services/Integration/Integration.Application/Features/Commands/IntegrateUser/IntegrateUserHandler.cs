using AutoMapper;
using Integration.Application.Contracts.Infrastructure;
using Integration.Application.Contracts.Persistence;
using Integration.Application.Models;
using Integration.Application.Util;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Application.Features.Commands.IntegrateUser
{
    public class IntegrateUserHandler : IRequestHandler<IntegrateUserCommand>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<IntegrateUserHandler> _logger;
        private readonly IEmailService _emailService;

        public IntegrateUserHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<IntegrateUserHandler> logger, IEmailService emailService)
        {
            _integrationReporsitory = integrationReporsitory ?? throw new ArgumentNullException(nameof(integrationReporsitory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<Unit> Handle(IntegrateUserCommand request, CancellationToken cancellationToken = default)
        {
            if (VerifyCondition(request))
            {
                await SendMailToUser(request);
                var userInfo = DestructureObject.Destructure(request, false);
                var fileString = GenerateFile.GenerateUserFile(request, true, userInfo);

                FileInfo file = new FileInfo();

                if (!string.IsNullOrWhiteSpace(request.FileFormat) &&
                   !string.IsNullOrWhiteSpace(request.EmailTo))
                {
                    file.File = fileString;
                    file.Extension = request.FileFormat.ToLower();

                    await SendMailToCustom(request, file);
                }
            }

            return Unit.Value;
        }

        private async Task SendMailToUser(IntegrateUserCommand request)
        {
            request.UserTemplate = ReplaceUserInformation(request.UserTemplate, request);
            request.UserEmailTitle = ReplaceUserInformation(request.UserEmailTitle, request);
            var email = new Email() { To = request.EmailAddress, Body = request.UserTemplate, Subject = request.UserEmailTitle };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"User email failed due to an error with the mail service: {ex.Message}");
            }
        }

        private async Task SendMailToCustom(IntegrateUserCommand request, FileInfo file)
        {
            request.CustomTemplate = ReplaceUserInformation(request.CustomTemplate, request);
            request.CustomEmailTitle = ReplaceUserInformation(request.CustomEmailTitle, request);
            var email = new Email() { To = request.EmailTo, Body = request.CustomTemplate, Subject = request.CustomEmailTitle };

            try
            {
                await _emailService.SendEmailWithAttachment(email, file);
            }
            catch (Exception ex)
            {
                _logger.LogError($"User email failed due to an error with the mail service: {ex.Message}");
            }
        }

        private string ReplaceUserInformation(string userInformation, IntegrateUserCommand request)
        {
            userInformation = userInformation.Replace("{nome}", request.Name);
            userInformation = userInformation.Replace("{idade}", request.Age.ToString());
            userInformation = userInformation.Replace("{telefone}", request.Phone);
            userInformation = userInformation.Replace("{e-mail}", request.EmailAddress);

            return userInformation;
        }

        private bool VerifyCondition(IntegrateUserCommand request)
        {
            if (!string.IsNullOrWhiteSpace(request.Value) &&
               !string.IsNullOrWhiteSpace(request.Operator) &&
               !string.IsNullOrWhiteSpace(request.Field))
            {
                switch (request.Field.ToLower())
                {
                    case "nome":
                    case "name":
                        if (request.Operator.ToLower() == "equals" || request.Operator.ToLower() == "igual")
                            return request.Name.ToLower() == request.Value.ToLower();
                        if (request.Operator.ToLower() == "contains" || request.Operator.ToLower() == "contem")
                            return request.Name.ToLower().Contains(request.Value.ToLower());
                        break;
                    case "phone":
                    case "telefone":
                        if (request.Operator.ToLower() == "equals" || request.Operator.ToLower() == "igual")
                            return request.Phone.ToLower() == request.Value.ToLower();
                        if (request.Operator.ToLower() == "contains" || request.Operator.ToLower() == "contem")
                            return request.Phone.ToLower().Contains(request.Value.ToLower());
                        break;
                    case "email":
                    case "emailaddress":
                        if (request.Operator.ToLower() == "equals" || request.Operator.ToLower() == "igual")
                            return request.EmailAddress.ToLower() == request.Value.ToLower();
                        if (request.Operator.ToLower() == "contains" || request.Operator.ToLower() == "contem")
                            return request.Phone.Contains(request.Value);
                        break;
                    case "idade":
                    case "age":
                        if (request.Operator.ToLower() == "equals" || request.Operator.ToLower() == "igual")
                            return request.Age.ToString() == request.Value;
                        if (request.Operator.ToLower() == "contains" || request.Operator.ToLower() == "contem")
                            return request.Age.ToString().Contains(request.Value);
                        if (request.Operator.ToLower() == "greater" || request.Operator.ToLower() == "maior")
                            return request.Age >= int.Parse(request.Value);
                        if (request.Operator.ToLower() == "lesser" || request.Operator.ToLower() == "menor")
                            return request.Age <= int.Parse(request.Value);
                        break;
                }

            }
            return true;
        }
    }
}
