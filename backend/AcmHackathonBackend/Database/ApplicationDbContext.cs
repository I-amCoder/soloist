using AcmHackathonBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AcmHackathonBackend.Database.Seeders;

namespace AcmHackathonBackend.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<ProjectFeature> ProjectFeatures { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventSchedule> EventSchedules { get; set; }
        public DbSet<ScheduleActivity> ScheduleActivities { get; set; }
        public DbSet<EventRule> EventRules { get; set; }
        public DbSet<EventPrize> EventPrizes { get; set; }
        public DbSet<PrizeBenefit> PrizeBenefits { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
        public DbSet<EventSponsor> EventSponsors { get; set; }

        public DbSet<Executive> Executives { get; set; }
        public DbSet<ExecutiveSocialLinks> ExecutiveSocialLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project configurations
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Technologies)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Features)
                .WithOne(f => f.Project)
                .HasForeignKey(f => f.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event configurations
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Schedule)
                .WithOne(s => s.Event)
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Rules)
                .WithOne(r => r.Event)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Prizes)
                .WithOne(p => p.Event)
                .HasForeignKey(p => p.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithOne(v => v.Event)
                .HasForeignKey<EventVenue>(v => v.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Sponsors)
                .WithOne(s => s.Event)
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventSchedule>()
                .HasMany(s => s.Activities)
                .WithOne(a => a.EventSchedule)
                .HasForeignKey(a => a.EventScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventPrize>()
                .HasMany(p => p.Benefits)
                .WithOne(b => b.EventPrize)
                .HasForeignKey(b => b.EventPrizeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Executive configurations
            modelBuilder.Entity<Executive>()
                .HasOne(e => e.SocialLinks)
                .WithOne(s => s.Executive)
                .HasForeignKey<ExecutiveSocialLinks>(s => s.ExecutiveId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add indexes for better query performance
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.IsFeatured);

            modelBuilder.Entity<Event>()
                .HasIndex(e => e.Slug)
                .IsUnique();

            modelBuilder.Entity<Event>()
                .HasIndex(e => e.IsUpcoming);

            modelBuilder.Entity<Executive>()
                .HasIndex(e => e.Role);

            // Add the seed data
            modelBuilder.Seed();
        }
    }
} 