using AcmHackathonBackend.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AcmHackathonBackend.Models
{
    public class Event : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        public string? FullDescription { get; set; }

        public List<EventSchedule> Schedule { get; set; } = new();

        public List<EventRule> Rules { get; set; } = new();

        public List<EventPrize> Prizes { get; set; } = new();

        public EventVenue? Venue { get; set; }

        public List<EventSponsor> Sponsors { get; set; } = new();

        public bool IsUpcoming { get; set; }
    }

    public class EventSchedule : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Day { get; set; } = string.Empty;

        public List<ScheduleActivity> Activities { get; set; } = new();
    }

    public class ScheduleActivity : BaseEntity
    {
        public int EventScheduleId { get; set; }
        public EventSchedule EventSchedule { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Time { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Activity { get; set; } = string.Empty;
    }

    public class EventRule : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }

    public class EventPrize : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Place { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Reward { get; set; } = string.Empty;

        public List<PrizeBenefit> Benefits { get; set; } = new();
    }

    public class PrizeBenefit : BaseEntity
    {
        public int EventPrizeId { get; set; }
        public EventPrize EventPrize { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }

    public class EventVenue : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        public string? MapLink { get; set; }
    }

    public class EventSponsor : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Logo { get; set; } = string.Empty;

        public string? Website { get; set; }
    }
} 