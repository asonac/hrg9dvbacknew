using Integration.Application.Features.Commands.IntegrateUser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Integration.Application.Util
{
    public static class DestructureObject
    {
        public static object Destructure(IntegrateUserCommand request, bool emailOrPayload)
        {
            var showName = emailOrPayload ? request.ShowName : request.PayloadShowName;
            var showPhone = emailOrPayload ? request.ShowPhone : request.PayloadShowPhone;
            var showEmail = emailOrPayload ? request.ShowEmailAddress : request.PayloadShowEmailAddress;
            var showAge = emailOrPayload ? request.ShowAge : request.PayloadShowAge;

            List<object> users = new List<object>();

            var user = new
            {
                Name = request.Name,
                Phone = request.Phone,
                EmailAddress = request.EmailAddress,
                Age = request.Age
            };

            string json = JsonConvert.SerializeObject(user);

            JObject rss = JObject.Parse(json);

            if (!showName)
                rss.Properties()
                    .Where(attr => attr.Name.StartsWith("Name"))
                    .ToList()
                    .ForEach(attr => attr.Remove());

            if (!showPhone)
                rss.Properties()
                  .Where(attr => attr.Name.StartsWith("Phone"))
                  .ToList()
                  .ForEach(attr => attr.Remove());

            if (!showEmail)
                rss.Properties()
                  .Where(attr => attr.Name.StartsWith("Email"))
                  .ToList()
                  .ForEach(attr => attr.Remove());

            if (!showAge)
                rss.Properties()
                  .Where(attr => attr.Name.StartsWith("Age"))
                  .ToList()
                  .ForEach(attr => attr.Remove());


            var userProjected = JsonConvert.DeserializeObject(rss.ToString());

            return userProjected;
        }
    }
}
