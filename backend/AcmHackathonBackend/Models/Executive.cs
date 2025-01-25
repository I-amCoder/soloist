using AcmHackathonBackend.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace AcmHackathonBackend.Models
{
    public class Executive : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Year { get; set; } = string.Empty;

        public ExecutiveSocialLinks? SocialLinks { get; set; }
    }

    public class ExecutiveSocialLinks : BaseEntity
    {
        public int ExecutiveId { get; set; }
        public Executive Executive { get; set; } = null!;

        public string? LinkedIn { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
    }
} 