using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using static Akka.Pattern.BackoffSupervisor;

namespace AKKA_demo.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class ActorController : ControllerBase
    {

        [HttpGet("ping")]
        public string GetPing()
        {
            try
            {
                var actorSystem = ActorSystem.Create("PingPong");
                //var pingActorProps = Props.Create(() => new PingActor());
                var pingActorProps = actorSystem.ActorOf<PingActor>("Ping");

                pingActorProps.Tell(new Ping(0));

                return pingActorProps.ToString();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpGet("message")]
        public string GetMessage()
        {
            try
            {
                Data.Instance.messageLog.Add("Hello World");
                var system = ActorSystem.Create("MySystem");
                var greeter = system.ActorOf<MessageActor>("greeter");
                greeter.Tell(new Message("Hello World"));
                return Data.Instance.messageLog[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}