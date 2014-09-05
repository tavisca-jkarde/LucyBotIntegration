using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.protocol.x.muc;
using Lucy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lucy.Core
{
    public class ChatBot : ICanChat
    {
        private ICommandAdapter _commandAdapter;

        private XmppClientConnection _xmppClient = new XmppClientConnection("chat.hipchat.com");

        public string UserName { get; set; }

        public string Password { get; set; }

        private bool _loggedIn = false;

        private Jid _room;

        public ChatBot(ICommandAdapter commandAdapter)
        {
            _commandAdapter = commandAdapter;
        }

        public ChatBot(ICommandAdapter commandAdapter, string username, string password)
        {
            _commandAdapter = commandAdapter;
            UserName = username;
            Password = password;
        }

        public void Notify(string newMessage)
        {
            _xmppClient.Send(new agsXMPP.protocol.client.Message(_room, MessageType.groupchat, newMessage));
        }

        public bool Login()
        {
            _xmppClient.OnLogin += new ObjectHandler(_xmppClient_OnLogin);

            _xmppClient.AutoResolveConnectServer = false;
            _xmppClient.AutoRoster = true;
            _xmppClient.Open(this.UserName, this.Password);
            Thread.Sleep(10000);
            
            return _loggedIn;
        }

        private void RegisterEventHandlers()
        {

        }

        private void _xmppClient_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (!String.IsNullOrEmpty(msg.Body))
            {
                Console.WriteLine("Message : {0} - from {1}", msg.Body, msg.From);
                string user = msg.From.Resource;

                if (user == "Lucy Bot")
                    return;
                if (msg.Body.StartsWith("@lucy"))
                {
                    if (msg.Body.Contains("take rest"))
                    {
                        _loggedIn = false;
                        _xmppClient.Send(new agsXMPP.protocol.client.Message(msg.From, msg.Type, "Good Bye :)"));
                        _xmppClient.Close();
                    }
                    else
                    {
                        msg.Body = msg.Body.Replace("@lucy", "").TrimStart().TrimEnd();
                        Notify(msg.Body);
                    }
                }
            }
        }

        private void _xmppClient_OnLogin(object sender)
        {
            Console.WriteLine("Login successfull!!");
            _loggedIn = true;
        }

        public void ConnectToRoom(Jid room, string nickName)
        {

            _room = room;
            try
            {
                MucManager manager = new MucManager(_xmppClient);
                manager.JoinRoom(room, nickName, true);
                _xmppClient.OnMessage += new agsXMPP.protocol.client.MessageHandler(_xmppClient_OnMessage);
                StartListening();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void StartListening()
        {
            while (_loggedIn) ;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var chatBot = obj as ChatBot;
            if (this.UserName == chatBot.UserName && this.Password == chatBot.Password)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            string hash = this.UserName + this.Password;
            return hash.GetHashCode();
        }
    }
}
