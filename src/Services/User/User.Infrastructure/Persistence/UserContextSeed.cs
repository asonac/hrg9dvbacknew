using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(Context userContext, ILogger<UserContextSeed> logger)
        {
            if (!userContext.Users.Any())
            {
                userContext.Users.AddRange(GetPreconfiguredUsers());
                await userContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Entities.User> GetPreconfiguredUsers()
        {
            return new List<Entities.User>
            {
                new Entities.User()
                {
                    Name = "Teddy Test",
                    Age = 21,
                    Phone = "+5511998478602",
                    EmailAddress = "teddy@test.com"
                }
            };
        }
    }
}
