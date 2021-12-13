using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;


namespace Integration.Infrastructure.Persistence
{
    public class IntegrationContextSeed
    {
        public static async Task SeedAsync(Context userContext, ILogger<IntegrationContextSeed> logger)
        {
            if (!userContext.Integrations.Any())
            {
                userContext.Integrations.AddRange(GetPreconfiguredUsers());
                await userContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Entities.Integration> GetPreconfiguredUsers()
        {
            return new List<Entities.Integration>
            {
                new Entities.Integration()
                {
                    ShowName = true,
                    ShowAge = true,
                    ShowPhone = true,
                    ShowEmailAddress = true,
                    SendEmailToUser = true,
                    UserEmailTitle = "Welcome {nome}!!!",
                    UserTemplate = "Olá, seja bem vindo {nome}!",
                    EmailTo = "comercial@exemplo.com",
                    CustomEmailTitle = "New User",
                    CustomTemplate = "<p>Nome: {nome}</p><p>Idade: {idade}</p><p>Telefone: {telefone}</p><p>E-mail: {e-mail}</p>",
                    Method = "post",
                    Payload = "json",
                    Link = "https://httpbin.org/post",
                    FileFormat = "json",
                    Field = "Age",
                    Operator = "Greater",
                    Value = "18",
                    PayloadShowAge = false,
                    PayloadShowEmailAddress = false,
                    PayloadShowName = true,
                    PayloadShowPhone = true
                }
            };
        }
    }
}
