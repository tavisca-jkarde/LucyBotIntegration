using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Contracts
{
    public interface IChannel
    {
        void Subscribe(string topic, ICanRecieveMessage subscriber);

        void UnSubscribe(string topic, ICanRecieveMessage subscriber);

        void Send(Message message, ICanRecieveMessage sender);
    }
}
