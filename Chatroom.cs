using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;

            }

            //add a participant to the chatroom
            participant.Chatroom = this;

        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }

        public override void SendAll(string from, string message)

        {
            //loop the chatroom and send the same messgae to all registered users
            foreach (KeyValuePair<string, Participant> entry in participants)
            {
                //to replace the [to] argument with participants[entry.Key]
                Participant participant = participants[entry.Key];

                if (participant != null && participants[from] != participants[entry.Key])
                {
                    participant.Receive(from, message);
                }

                else 
                { 
                    Console.WriteLine("{0} you can't send yourself a message!", from);
                }

            }

        }

        public override void SendMany(string from, List<Participant> to, string message)
        {

            foreach (Participant entry in to)
            {
                //to replace the [to] argument with participants[entry.Key]
                Participant participant = participants[entry.Name];
                if (participant != null && participants[from] != participants[entry.Name])
                {
                     participant.Receive(from, message);
                }

                else 
                { 
                    Console.WriteLine("{0} you can't send yourself a message!", from);
                }


            }

        }

    


    }
}
