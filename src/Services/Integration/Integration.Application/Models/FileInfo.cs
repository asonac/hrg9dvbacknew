namespace Integration.Application.Models
{
    public class FileInfo
    {
        public string File { get; set; }
        public string Extension { get; set; }

        public string Type { get
            {
                switch (Extension.ToLower())
                {
                    case "json":
                        return "application/json";
                    case "csv":
                        return "text/csv";
                    case "xml":
                        return "application/xml";
                    default:
                        return ""; 
                }
            }
        
        }
    }
}
