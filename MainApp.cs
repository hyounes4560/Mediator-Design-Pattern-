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

    
    
}
