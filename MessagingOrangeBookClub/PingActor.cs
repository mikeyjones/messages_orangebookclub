using System.Threading.Tasks;
using Akka.Actor;

namespace MessagingOrangeBookClub
{
    public class PingActor : ReceiveActor
    {
        public PingActor()
        {
            Receive<string>(msg =>
            {
                IActorRef logger = Context.ActorOf<LoggerActor>("loggerChild");
                IActorRef pong = Context.ActorOf<PongActor>("pongChild");
                
                if (msg == "STOP") return;
                
                logger.Tell($"Received '{msg}'; Sending 'PING'");
                Task.Delay(500).Wait();
                
                pong.Tell("PING");
                
            });
        }
    }
}