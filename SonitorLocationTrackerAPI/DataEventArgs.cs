namespace SonitorLocationTrackerAPI
{
    public class DataEventArgs
    {
        public object Data { get; set; }
        public IContextService Owner { get; set; }

        public DataEventArgs( object data )
        {
            Data = data;
        }
    }
}