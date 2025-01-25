namespace AcmHackathonBackend.Models.ResponseModels;

public class EventResponseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public string RegistrationLink { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool IsUpcoming { get; set; }
    public string Type { get; set; } = string.Empty;
    public int? MaxTeamSize { get; set; }
    public int? MinTeamSize { get; set; }
    public decimal? PrizeMoney { get; set; }
    public List<EventScheduleResponseModel> Schedule { get; set; } = new();
    public List<EventRuleResponseModel> Rules { get; set; } = new();
    public List<EventPrizeResponseModel> Prizes { get; set; } = new();
    public List<EventSponsorResponseModel> Sponsors { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class EventScheduleResponseModel
{
    public int Id { get; set; }
    public string Day { get; set; } = string.Empty;
    public List<ScheduleActivityResponseModel> Activities { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class ScheduleActivityResponseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class EventRuleResponseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class EventPrizeResponseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal? Amount { get; set; }
    public int Rank { get; set; }
    public List<PrizeBenefitResponseModel> Benefits { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class PrizeBenefitResponseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class EventSponsorResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
} 