using System.Threading.Tasks;
using Akka.Actor;

namespace MessagingOrangeBookClub
{
    public class PongActor : ReceiveActor
    {
        private int count = 0;
        
        public PongActor()
        {
            Receive<string>(msg =>
            {
                IActorRef logger = Context.ActorOf<LoggerActor>("loggerChild");
                IActorRef ping = Context.ActorOf<PingActor>("pingChild");

                count++;
                string nextMsg = (count < 5) ? "PONG" : "STOP"; 

                
                if (msg == "STOP") return;
                
                logger.Tell($"Received '{msg}'; Sending '{nextMsg}; Count = {count}'");
                Task.Delay(500).Wait();
                
                ping.Tell(nextMsg);
                

            });
        }
    }
}