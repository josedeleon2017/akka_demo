namespace AKKA_demo
{
    public sealed class Data
    {
        private readonly static Data _instance = new Data();

        private Data()
        {
        }

        public static Data Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<string> messageLog = new List<string>();
    }
}
