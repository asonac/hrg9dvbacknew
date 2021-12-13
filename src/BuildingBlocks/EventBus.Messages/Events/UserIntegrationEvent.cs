namespace EventBus.Messages.Events
{
    public class UserIntegrationEvent : IntegrationBaseEvent
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    }
}
