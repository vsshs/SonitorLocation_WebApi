﻿namespace SonitorLocationTrackerAPI.Sonitor
{
    public class DetectorStatus
    {
        public string HostName { get; set; }
        public int Channel { get; set; }
        public bool Online { get; set; }
    }
}