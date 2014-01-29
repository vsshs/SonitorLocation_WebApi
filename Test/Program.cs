using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SonitorLocationTrackerAPI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tracker = new LocationTracker("10.6.6.124");
            tracker.DataReceived += tracker_DataReceived;
            
            tracker.Start();

            while (true) ;
        }

        static void tracker_DataReceived(object sender, DataEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
}
