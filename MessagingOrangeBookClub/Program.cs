using System;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using LaYumba.Functional;

namespace MessagingOrangeBookClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");

            var pong = system.ActorOf<PongActor>("pongChild");
            var ping = system.ActorOf(PingActor.Props(pong));

            ping.Tell("START");

            Thread.Sleep(100000);
        }

        // public static void Main()
        // {
        //
        //     //Counter.main();
        //     Agent<string> logger, ping, pong = null;
        //
        //     logger = Agent.Start((string msg) => Console.WriteLine(msg));
        //
        //     ping = Agent.Start((string msg) =>
        //     {
        //         if (msg == "STOP") return;
        //
        //         logger.Tell($"Received '{msg}'; Sending 'PING'");
        //         Task.Delay(500).Wait();
        //         pong.Tell("PING");
        //     });
        //
        //     pong = Agent.Start(0, (int count, string msg) =>
        //     {
        //         int newCount = count + 1;
        //         string nextMsg = (newCount < 5) ? "PONG" : "STOP";
        //
        //         logger.Tell($"Received '{msg}' #{newCount}; Sending '{nextMsg}'");
        //         Task.Delay(500).Wait();
        //         ping.Tell(nextMsg);
        //
        //         return newCount;
        //     });
        //
        //     ping.Tell("START");
        //
        //     Thread.Sleep(10000);
        // }


    }
}