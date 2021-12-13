using Integration.Application.Models;
using System.Threading.Tasks;

namespace Integration.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
        Task<bool> SendEmailWithAttachment(Email email, FileInfo file);
    }
}
