using MediatR;

namespace Integration.Application.Features.Commands.CreateIntegration
{
    public class CreateIntegrationCommand : IRequest<int>
    {
        // Email Information
        public bool ShowName { get; set; }
        public bool ShowAge { get; set; }
        public bool ShowPhone { get; set; }
        public bool ShowEmailAddress { get; set; }
        public bool SendEmailToUser { get; set; }
        public string EmailTo { get; set; }
        public string UserEmailTitle { get; set; }
        public string CustomEmailTitle { get; set; }
        public string UserTemplate { get; set; }
        public string CustomTemplate { get; set; }
        // Condition
        public string FileFormat { get; set; }
        //Name, Age, Phone, EmailAddress
        public string Field { get; set; }
        //Equal, Greater, Lesser, Contains
        public string Operator { get; set; }
        public string Value { get; set; }
        // Integration
        public string Link { get; set; }
        public string Method { get; set; }
        public string Payload { get; set; }
        public bool PayloadShowName { get; set; }
        public bool PayloadShowAge { get; set; }
        public bool PayloadShowPhone { get; set; }
        public bool PayloadShowEmailAddress { get; set; }
    }
}
