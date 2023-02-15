using Akka.Actor;
using Microsoft.AspNetCore.Mvc;

namespace AKKA_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        [HttpGet]
        public string GetPing()
        {
            try
            {
                var actorSystem = ActorSystem.Create("PingPong");
                var pingActorProps = Props.Create(() => new PingActor());
                IActorRef pingActor = actorSystem.ActorOf(pingActorProps, "ping");

                pingActor.Tell(new Ping(0));

                return pingActor.ToString();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}