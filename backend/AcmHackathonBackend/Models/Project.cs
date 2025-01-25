using AcmHackathonBackend.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AcmHackathonBackend.Models
{
    public class Project : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Team { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Hackathon { get; set; } = string.Empty;

        public List<ProjectTechnology> Technologies { get; set; } = new();

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;

        public string? DemoLink { get; set; }

        public string? GithubLink { get; set; }

        public List<ProjectFeature> Features { get; set; } = new();

        public bool IsFeatured { get; set; }
    }

    public class ProjectTechnology : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }

    public class ProjectFeature : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
} 