using Akka.Actor;
using static Akka.Pattern.BackoffSupervisor;

namespace AKKA_demo
{
    public class MessageActor : ReceiveActor
    {
        public MessageActor() {
            Receive<Message>(greet =>
            {
                Data.Instance.messageLog.Add($"[Thread ] Text Received {greet.Txt}");
            });
        }
    }
}
