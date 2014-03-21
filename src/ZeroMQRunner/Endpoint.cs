namespace ZeroMQRunner
{
    public class Endpoint
    {
        public string Type
        {
            get { return GetType().Name.ToLowerInvariant(); }
        } 
    }
}