using System;
using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IConsumer
    {
        public async Task RecieveMessage(Func<string, Task> onRecieve)
        {

        }
    }
}
