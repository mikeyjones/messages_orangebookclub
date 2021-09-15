using System;
using Akka.Actor;

namespace MessagingOrangeBookClub
{
    public class LoggerActor : ReceiveActor
    {
        public LoggerActor()
        {
            Receive<string>(msg =>
            {
                Console.WriteLine(msg);
            });
        }
    }

}