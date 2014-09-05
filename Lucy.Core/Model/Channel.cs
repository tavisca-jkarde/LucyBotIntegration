using Lucy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Model
{
    public static class Channel : IChannel
    {
        public void Subscribe(string topic, ICanRecieveMessage subscriber)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe(string topic, ICanRecieveMessage subscriber)
        {
            throw new NotImplementedException();
        }

        public static void Send(Message message, ICanRecieveMessage sender)
        {
            throw new NotImplementedException();
        }
    }
}
