using System;
using System.Collections.Generic;
using static System.Console;

namespace tp.Mediator
{
    interface IMediator
    {
        void Register(IObjectMediator objectMediator);
        void Send(string from, string to, string message);
    }
    class ChatMediator : IMediator
    {
        private Dictionary<string, IObjectMediator> participants = new Dictionary<string, IObjectMediator>();
        public void Register(IObjectMediator objectMediator)
        {
            if (!participants.ContainsValue(objectMediator))
            {
                participants.Add(objectMediator.Name, objectMediator);
                objectMediator.Connect(this);
            }
        }
        public void Send(string from, string to, string message)
        {
            if (participants.ContainsKey(to))
            {
                var participant = participants[to];
                participant.Receive(from, message);
            }
            else
            {
                WriteLine($"User {to} not found...");
            }                
        }
    }
    interface IObjectMediator
    {
        String Name { get; set; }
        void Connect(IMediator to);
        void Send(string to, string message);
        void Receive(string from, string message);
    }
    class ParticipantObjectMediator : IObjectMediator
    {
        private IMediator chat;
        public string Name { get; set; }
        public ParticipantObjectMediator(string name) => this.Name = name;
        public void Connect(IMediator to) => chat = to;
        public void Receive(string from, string message) => WriteLine($"{from} to {Name}: {message}");
        public void Send(string to, string message) => chat.Send(Name, to, message);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mediator pattern demo...");

            var chat = new ChatMediator();

            var user1 = new ParticipantObjectMediator("User 1");
            var user2 = new ParticipantObjectMediator("User 2");
            var user3 = new ParticipantObjectMediator("User 3");
            var user4 = new ParticipantObjectMediator("User 4");

            chat.Register(user1);
            chat.Register(user2);
            chat.Register(user3);
            chat.Register(user4);

            user1.Send("User 2", "Hi !");
            user2.Send("User 1", "Hello!");            
        }
    }
}
