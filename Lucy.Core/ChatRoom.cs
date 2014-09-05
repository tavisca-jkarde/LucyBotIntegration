using agsXMPP;
using Lucy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core
{
    public class ChatRoom
    {
        static HashSet<ICanChat> _chatBots = new HashSet<ICanChat>();

        public void Join(ICanChat chatter)
        {
            if(chatter.Login())
            {
                Jid room = "114716_tavisca@conf.hipchat.com";
                string nickName = "Lucy Bot";
                chatter.ConnectToRoom(room, nickName);
                //_chatBots.Add(chatter);
            }
        }

        public void Leave(ICanChat chatter)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message, ICanChat sender)
        {
            throw new NotImplementedException();
        }

        public bool IsUserPresent(ICanChat chatter)
        {
            throw new NotImplementedException();
        }

        public object GetBotCount()
        {
            return _chatBots.Count;
        }
    }
}
