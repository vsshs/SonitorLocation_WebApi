using System;

namespace SonitorLocationTrackerAPI
{
    public delegate void DataReceivedHandler( Object sender, DataEventArgs e );

    public interface IContextService
    {
        string Name { get; set; }
        Guid Id { get; set; }
        bool IsRunning { get; }

        void Send( string message );
        void Start();
        void Stop();

        event DataReceivedHandler DataReceived;
    }
}