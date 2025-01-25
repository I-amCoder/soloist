using System.Collections.Generic;

namespace AcmHackathonBackend.Models.ResponseModels
{
    public class EventsResponseModel
    {
        public IEnumerable<EventResponseModel> Upcoming { get; set; }
        public IEnumerable<EventResponseModel> Past { get; set; }
    }
} 