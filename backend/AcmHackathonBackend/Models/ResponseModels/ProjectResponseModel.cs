namespace AcmHackathonBackend.Models.ResponseModels;
public class ProjectResponseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Hackathon { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? DemoLink { get; set; }
    public string? GithubLink { get; set; }
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ProjectTechnologyResponseModel> Technologies { get; set; } = new();
    public List<ProjectFeatureResponseModel> Features { get; set; } = new();
}

public class ProjectTechnologyResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ProjectFeatureResponseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
} 