using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    abstract class AbstractChatroom
    {

        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
        public abstract void SendAll(string from, string message);
        public abstract void SendMany(string from, List<Participant> to, string message);

    }
}
