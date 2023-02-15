namespace AKKA_demo
{
    public class Message
    {
        public Message(string txt)
        {
            Txt = txt.ToUpper();
        }
        public string Txt { get; private set; }
    }
}
