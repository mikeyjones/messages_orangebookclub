using System.Threading.Tasks;
using Akka.Actor;

namespace MessagingOrangeBookClub
{
    public class PingActor : ReceiveActor
    {
        public PingActor(IActorRef pong)
        {
            Receive<string>(msg =>
            {
                IActorRef logger = Context.ActorOf<LoggerActor>();

                if (msg == "STOP") return;

                logger.Tell($"Received '{msg}'; Sending 'PING'");
                Task.Delay(500).Wait();

                pong.Tell("PING");

            });
        }
        public static Props Props(IActorRef pong)
        {
            return Akka.Actor.Props.Create(() => new PingActor(pong));
        }
    }
}