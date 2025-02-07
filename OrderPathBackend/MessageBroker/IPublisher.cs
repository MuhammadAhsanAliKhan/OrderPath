namespace OrderPathBackend.MessageBroker
{
    public interface IPublisher
    {
        public void SendMessage(string message);
    }
}
