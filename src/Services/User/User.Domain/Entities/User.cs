using User.Domain.Common;

namespace User.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    }
}
