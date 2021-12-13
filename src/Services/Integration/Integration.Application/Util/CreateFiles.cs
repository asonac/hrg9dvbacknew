using CsvHelper;
using Integration.Application.Features.Commands.IntegrateUser;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Integration.Application.Util
{
    public class CreateFiles
    {

        public string GenerateXML(IntegrateUserCommand request, bool emailOrPayload)
        {
            var showName = emailOrPayload ? request.ShowName : request.PayloadShowName;
            var showPhone = emailOrPayload ? request.ShowPhone : request.PayloadShowPhone;
            var showEmail = emailOrPayload ? request.ShowEmailAddress : request.PayloadShowEmailAddress;
            var showAge = emailOrPayload ? request.ShowAge : request.PayloadShowAge;

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            writerSettings.CloseOutput = false;
            MemoryStream localMemoryStream = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(localMemoryStream, writerSettings))
            {
                writer.WriteStartElement("user");
                if (showName)
                    writer.WriteElementString("name", request.Name);
                if (showPhone)
                    writer.WriteElementString("phone", request.Phone);
                if (showEmail)
                    writer.WriteElementString("emailAddress", request.EmailAddress);
                if (showAge)
                    writer.WriteElementString("age", request.Age.ToString());
                writer.WriteEndElement();
                writer.Flush();
            }

            return Encoding.UTF8.GetString(localMemoryStream.ToArray());
        }

        public string GenerateCSV(IntegrateUserCommand request, bool emailOrPayload, object user)
        {
            List<object> users = new List<object>();
            users.Add(user);

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader(user.GetType());
                csv.WriteRecords(users);
                return Encoding.UTF8.GetString(mem.ToArray());
            }
        }

        public string GenerateJSON(object user)
        {
            string json = JsonConvert.SerializeObject(user);
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);
                tw.Write(json);
                tw.Flush();
                ms.Position = 0;
                return Encoding.UTF8.GetString(ms.ToArray());
            }

        }
    }
}
