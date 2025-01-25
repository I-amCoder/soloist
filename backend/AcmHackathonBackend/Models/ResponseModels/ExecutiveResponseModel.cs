namespace AcmHackathonBackend.Models.ResponseModels;

public class ExecutiveResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public ExecutiveSocialLinksResponseModel? SocialLinks { get; set; }
}

public class ExecutiveSocialLinksResponseModel
{
    public string? LinkedIn { get; set; }
    public string? Github { get; set; }
    public string? Twitter { get; set; }
} 