using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using SonitorLocationTrackerAPI;

namespace WebApi.Controllers
{
    public class SonitorTrackerController : ApiController
    {
        public const string Address = "10.6.6.124";

        public static LocationTracker Tracker = null;

        public SonitorTrackerController()
        {
            if (Tracker == null)
                StartTracker();

            if (Tracker != null && !Tracker.IsRunning)
            {
                Tracker.Stop();
                Debug.WriteLine("Tracker not running. Trying to start");
                StartTracker();
            }
        }


        [HttpGet]
        public ICollection<Tag> GetTags()
        {
            if (Tracker == null || !Tracker.IsRunning)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Tracker was not initialized!"));

            var tags = new Collection<Tag>();
            foreach (var tag in Tracker.Tags)
                tags.Add(tag.Value);

            return tags;
        }


        [HttpGet]
        public Tag GetTag(string key)
        {
            if (Tracker == null || !Tracker.IsRunning)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Tracker was not initialized!"));

            Tag tag;
            Tracker.Tags.TryGetValue(key, out tag);

            if (tag == null)
                throw new HttpResponseException(
                    Request.CreateErrorResponse(
                        HttpStatusCode.NotFound, 
                        "Tag with key: '" + HttpUtility.HtmlEncode(key) + "' was not found!"));

            return tag;
        }



        private static void StartTracker()
        {
            Tracker = new LocationTracker(Address);
            Tracker.Start();

            Debug.WriteLine("Tracker started");
        }



    }
}
