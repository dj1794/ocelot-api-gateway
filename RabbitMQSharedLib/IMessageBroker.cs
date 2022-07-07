using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQSharedLib
{
    public interface IMessageBroker
    {
        void publish(string msg);
        void subscribe();
    }
}