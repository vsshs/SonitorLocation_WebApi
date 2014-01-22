using System;

namespace SonitorLocationTrackerAPI.Sonitor
{
    /// <summary>
    /// Sonitor Events
    /// </summary>
    public delegate void SonitorMessageReceivedHandler( Object sender, SonitorEventArgs e );

    public class SonitorEventArgs
    {
        public SonitorMessage Message { get; set; }

        public SonitorEventArgs( SonitorMessage message )
        {
            Message = message;
        }
    }
}