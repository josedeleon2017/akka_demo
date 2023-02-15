using Akka.Event;
using Akka.Util;

namespace AKKA_demo
{
    public class PingActor : Akka.Actor.ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public PingActor()
        {
            Receive<Ping>(p =>
            {
                _log.Info($"Recived:{0}", p);

                var replyTime = TimeSpan.FromSeconds(ThreadLocalRandom.Current.Next(1, 5));
                Context.System.Scheduler.ScheduleTellOnce(replyTime, Sender, p.Next(), Self);
            });
        }
    }
}
