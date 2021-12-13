using Integration.Application.Features.Commands.IntegrateUser;

namespace Integration.Application.Util
{
    public static class GenerateFile
    {

        public static string GenerateUserFile(IntegrateUserCommand request, bool emailOrPayload, object user)
        {
            CreateFiles file = new CreateFiles();
            var format = emailOrPayload ? request.FileFormat : request.Payload;

            switch (format.ToLower())
            {
                case "xml":
                    return file.GenerateXML(request, emailOrPayload);
                case "csv":
                    return file.GenerateCSV(request, emailOrPayload, user);
                case "json":
                    return file.GenerateJSON(user);
            }

            return "";
        }


    }
}
