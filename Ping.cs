using Akka.Event;

namespace AKKA_demo
{
    public class Ping
    {
        private int Count;
        public Ping(int count)
        {
            Count = count;
        }

        public int Next()
        {
            return Count++;
        }
    }
}
