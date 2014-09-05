using agsXMPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucy.Core.Contracts
{
    public interface ICanChat
    {
        string UserName { get; set; }
        string Password { get; set; }
        void Notify(string newMessage);
        bool Login();
        void ConnectToRoom(Jid room, string nickName);
    }
}
