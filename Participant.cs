using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    class Participant
    {
        Chatroom chatroom;
        string name;

        // Constructor
        public Participant(string name)
        {
            this.name = name;
        }

        // Gets participant name
        public string Name
        {
            get { return name; }
        }


        // Gets chatroom
        public Chatroom Chatroom
        {
            set { chatroom = value; }
            get { return chatroom; }
        }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            chatroom.Send(name, to, message);
        }

        //Sends message to all participants
        public void SendAll(string message)
        {
            chatroom.SendAll(name, message);
        }

        public void SendMany(List<Participant> to, string message)
        {

            chatroom.SendMany(name, to, message);

        }

        // Receives message from given participant
        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }
}
