namespace OrderPathBackend.MessageBroker
{
    public interface IConsumer
    {
        public async Task RecieveMessage(Func<string, Task> method)
        {

        }
    }
}
