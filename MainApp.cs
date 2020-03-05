using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Mediator.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Mediator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create chatroom
            Chatroom chatroom = new Chatroom();
            List<Participant> beatle = new List<Participant>();
            List<Participant> nonBeatle = new List<Participant>();


            //Message for everyone
            String firstMessage = "Hello there!";
            String secondMessage = "Hello Beatles!";
            String thirdMessage = "Hello non Beatles!";

            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");
            Participant Mark = new NonBeatle("Mark");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);
            chatroom.Register(Mark);

            //Add participants to groups 
            beatle.Add(George);
            beatle.Add(Paul);
            beatle.Add(Ringo);
            beatle.Add(John);
            nonBeatle.Add(Yoko);
            nonBeatle.Add(Mark);
            

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            Console.WriteLine("\nJohn is sending Hello there! to everyone in the chatroom\n");
            John.SendAll(firstMessage);

            Console.WriteLine("\nSending a meassge to the Beatles group\n");
            Yoko.SendMany(beatle, secondMessage);

            Console.WriteLine("\nSending a meassge to the non Beatles group\n");
            Ringo.SendMany(nonBeatle, thirdMessage);

            

            // Wait for user
            Console.ReadKey();
        }
    }

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

   

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
   class Chatroom : AbstractChatroom
    {
        private Dictionary<string,Participant> participants = new Dictionary<string,Participant>();
      
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

                else { Console.WriteLine("{0} you can't send yourself a message!", from); }


            }  

        }

        public override void SendMany(string from, List<Participant> to, string message)
        {

            foreach (Participant entry in to )
            {
                //to replace the [to] argument with participants[entry.Key]
                Participant participant = participants[entry.Name];
                if (participant != null && participants[from] != participants[entry.Name])
                {

                    participant.Receive(from, message);
                }

                else { Console.WriteLine("{0} you can't send yourself a message!", from); }
                

            }

        }
    
}

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

        public void SendMany(List<Participant> to, string message) {

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

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class Beatle : Participant
    {

        // Constructor
        public Beatle(string name)
            : base(name)
        {
        }
       
        
        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class NonBeatle : Participant
    {
        // Constructor
        public NonBeatle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
