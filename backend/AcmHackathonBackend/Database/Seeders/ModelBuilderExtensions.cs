using AcmHackathonBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AcmHackathonBackend.Database.Seeders
{
    public static class ModelBuilderExtensions
    {
        private static readonly DateTime _seedTime = new DateTime(2024, 1, 1);

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Projects
            var aiHealthcare = new Project
            {
                Id = 1,
                Title = "AI-Powered Healthcare Assistant",
                Description = "An intelligent healthcare assistant that uses machine learning to provide personalized medical advice and symptom analysis.",
                Image = "https://images.unsplash.com/photo-1576091160399-112ba8d25d1d",
                Team = "HealthTech Innovators",
                Hackathon = "AI Innovation Hackathon 2024",
                Status = "Winner",
                DemoLink = "https://demo.healthtech.com",
                GithubLink = "https://github.com/healthtech/ai-assistant",
                IsFeatured = true,
                CreatedAt = _seedTime
            };

            var smartCity = new Project
            {
                Id = 2,
                Title = "Sustainable Smart City Platform",
                Description = "A comprehensive platform for monitoring and optimizing city resources using IoT sensors and blockchain technology.",
                Image = "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b",
                Team = "EcoTech Solutions",
                Hackathon = "Web3 Development Challenge 2024",
                Status = "Runner Up",
                DemoLink = "https://demo.smartcity.io",
                GithubLink = "https://github.com/ecotech/smart-city",
                IsFeatured = true,
                CreatedAt = _seedTime
            };

            var eduPlatform = new Project
            {
                Id = 3,
                Title = "Decentralized Education Platform",
                Description = "A blockchain-based platform for verifiable credentials and peer-to-peer learning.",
                Image = "https://images.unsplash.com/photo-1501504905252-473c47e087f8",
                Team = "EduChain",
                Hackathon = "Web3 Development Challenge 2024",
                Status = "Completed",
                DemoLink = "https://demo.educhain.io",
                GithubLink = "https://github.com/educhain/platform",
                IsFeatured = false,
                CreatedAt = _seedTime
            };

            modelBuilder.Entity<Project>().HasData(aiHealthcare, smartCity, eduPlatform);

            // Seed Project Technologies
            var technologies = new[]
            {
                new ProjectTechnology { Id = 1, ProjectId = 1, Name = "Python", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 2, ProjectId = 1, Name = "TensorFlow", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 3, ProjectId = 1, Name = "React", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 4, ProjectId = 1, Name = "Node.js", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 5, ProjectId = 2, Name = "Solidity", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 6, ProjectId = 2, Name = "React", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 7, ProjectId = 2, Name = "AWS", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 8, ProjectId = 2, Name = "IoT", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 9, ProjectId = 3, Name = "Blockchain", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 10, ProjectId = 3, Name = "Ethereum", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 11, ProjectId = 3, Name = "IPFS", CreatedAt = _seedTime },
                new ProjectTechnology { Id = 12, ProjectId = 3, Name = "Vue.js", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<ProjectTechnology>().HasData(technologies);

            // Seed Project Features
            var features = new[]
            {
                new ProjectFeature { Id = 1, ProjectId = 1, Description = "Real-time symptom analysis", CreatedAt = _seedTime },
                new ProjectFeature { Id = 2, ProjectId = 1, Description = "Medical history tracking", CreatedAt = _seedTime },
                new ProjectFeature { Id = 3, ProjectId = 1, Description = "Emergency alert system", CreatedAt = _seedTime },
                new ProjectFeature { Id = 4, ProjectId = 1, Description = "Integration with healthcare providers", CreatedAt = _seedTime },
                new ProjectFeature { Id = 5, ProjectId = 2, Description = "Real-time resource monitoring", CreatedAt = _seedTime },
                new ProjectFeature { Id = 6, ProjectId = 2, Description = "Predictive maintenance", CreatedAt = _seedTime },
                new ProjectFeature { Id = 7, ProjectId = 2, Description = "Citizen engagement portal", CreatedAt = _seedTime },
                new ProjectFeature { Id = 8, ProjectId = 2, Description = "Blockchain-based voting system", CreatedAt = _seedTime },
                new ProjectFeature { Id = 9, ProjectId = 3, Description = "Decentralized credential verification", CreatedAt = _seedTime },
                new ProjectFeature { Id = 10, ProjectId = 3, Description = "Peer-to-peer learning modules", CreatedAt = _seedTime },
                new ProjectFeature { Id = 11, ProjectId = 3, Description = "Smart contract-based course certification", CreatedAt = _seedTime },
                new ProjectFeature { Id = 12, ProjectId = 3, Description = "Community-driven content creation", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<ProjectFeature>().HasData(features);

            // Seed Executives
            var executives = new[]
            {
                new Executive
                {
                    Id = 1,
                    Name = "Anas Raza",
                    Role = "President",
                    Image = "https://plus.unsplash.com/premium_photo-1664536392896-cd1743f9c02c?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8cGVyc29ufGVufDB8fDB8fHww",
                    Description = "Leading ACM's vision for innovative hackathons and tech events. Passionate about creating inclusive tech communities and fostering innovation through collaborative events.",
                    Department = "Computer Science",
                    Year = "Final Year",
                    CreatedAt = _seedTime
                },
                new Executive
                {
                    Id = 2,
                    Name = "Farwa Toor",
                    Role = "VP Internal",
                    Image = "https://plus.unsplash.com/premium_photo-1690407617542-2f210cf20d7e?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D",
                    Description = "Managing internal operations and coordinating with different departments to ensure smooth execution of ACM initiatives.",
                    Department = "Computer Science",
                    Year = "Final Year",
                    CreatedAt = _seedTime
                },
                new Executive
                {
                    Id = 3,
                    Name = "Nauman Asif",
                    Role = "General Secretary",
                    Image = "https://plus.unsplash.com/premium_photo-1689539137236-b68e436248de?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D",
                    Description = "Overseeing administrative tasks and maintaining effective communication between members and the executive council.",
                    Department = "Computer Science",
                    Year = "Final Year",
                    CreatedAt = _seedTime
                },
                new Executive
                {
                    Id = 4,
                    Name = "Nadir Hussain",
                    Role = "Treasurer",
                    Image = "https://images.unsplash.com/photo-1521566652839-697aa473761a?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fHBlcnNvbnxlbnwwfHwwfHx8MA%3D%3D",
                    Description = "Managing financial operations and ensuring efficient allocation of resources for ACM activities and events.",
                    Department = "Computer Science",
                    Year = "Final Year",
                    CreatedAt = _seedTime
                }
            };

            modelBuilder.Entity<Executive>().HasData(executives);

            // Seed Executive Social Links
            var socialLinks = new[]
            {
                new ExecutiveSocialLinks
                {
                    Id = 1,
                    ExecutiveId = 1,
                    LinkedIn = "https://linkedin.com/in/anasraza",
                    Github = "https://github.com/anasraza",
                    Twitter = "https://twitter.com/anasraza",
                    CreatedAt = _seedTime
                },
                new ExecutiveSocialLinks
                {
                    Id = 2,
                    ExecutiveId = 2,
                    LinkedIn = "https://linkedin.com/in/farwatoor",
                    Github = "https://github.com/farwatoor",
                    CreatedAt = _seedTime
                },
                new ExecutiveSocialLinks
                {
                    Id = 3,
                    ExecutiveId = 3,
                    LinkedIn = "https://linkedin.com/in/naumanasif",
                    Github = "https://github.com/naumanasif",
                    CreatedAt = _seedTime
                },
                new ExecutiveSocialLinks
                {
                    Id = 4,
                    ExecutiveId = 4,
                    LinkedIn = "https://linkedin.com/in/nadirhussain",
                    Github = "https://github.com/nadirhussain",
                    CreatedAt = _seedTime
                }
            };

            modelBuilder.Entity<ExecutiveSocialLinks>().HasData(socialLinks);

            // Seed Events
            var aiHackathon = new Event
            {
                Id = 1,
                Slug = "ai-innovation-hackathon-2024",
                Title = "AI Innovation Hackathon",
                Date = new DateTime(2024, 4, 15),
                Description = "Create cutting-edge AI solutions",
                Image = "https://images.unsplash.com/photo-1540575467063-178a50c2df87",
                FullDescription = "Join us for an exciting 48-hour hackathon focused on artificial intelligence and machine learning innovations. This event brings together developers, data scientists, and AI enthusiasts to create groundbreaking solutions.",
                IsUpcoming = true,
                CreatedAt = _seedTime
            };

            var web3Challenge = new Event
            {
                Id = 2,
                Slug = "web3-development-challenge-2024",
                Title = "Web3 Development Challenge",
                Date = new DateTime(2024, 2, 20),
                Description = "Blockchain and DApp development",
                Image = "https://images.unsplash.com/photo-1591115765373-5207764f72e7",
                FullDescription = "A groundbreaking hackathon focused on Web3 technologies and blockchain development. Participants created innovative decentralized applications and smart contracts.",
                IsUpcoming = false,
                CreatedAt = _seedTime
            };

            // New Events
            var pastEvent = new Event
            {
                Id = 3,
                Slug = "data-science-summit-2023",
                Title = "Data Science Summit",
                Date = new DateTime(2023, 11, 10),
                Description = "Exploring the future of data science",
                Image = "https://images.unsplash.com/photo-1517430816045-df4b7de11d1d",
                FullDescription = "A summit bringing together data scientists and industry leaders to discuss the latest trends and innovations in data science.",
                IsUpcoming = false,
                CreatedAt = _seedTime
            };

            var upcomingEvent = new Event
            {
                Id = 4,
                Slug = "cybersecurity-conference-2024",
                Title = "Cybersecurity Conference",
                Date = new DateTime(2024, 6, 5),
                Description = "Securing the digital future",
                Image = "https://images.unsplash.com/photo-1504384308090-c894fdcc538d",
                FullDescription = "Join experts and enthusiasts in the field of cybersecurity to explore the latest challenges and solutions in protecting digital assets.",
                IsUpcoming = true,
                CreatedAt = _seedTime
            };

            modelBuilder.Entity<Event>().HasData(aiHackathon, web3Challenge, pastEvent, upcomingEvent);

            // Seed Event Schedule
            var schedules = new[]
            {
                new EventSchedule { Id = 1, EventId = 1, Day = "Day 1", CreatedAt = _seedTime },
                new EventSchedule { Id = 2, EventId = 1, Day = "Day 2", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<EventSchedule>().HasData(schedules);

            // Seed Schedule Activities
            var activities = new[]
            {
                new ScheduleActivity { Id = 1, EventScheduleId = 1, Time = "09:00 AM", Activity = "Opening Ceremony", CreatedAt = _seedTime },
                new ScheduleActivity { Id = 2, EventScheduleId = 1, Time = "10:00 AM", Activity = "Team Formation", CreatedAt = _seedTime },
                new ScheduleActivity { Id = 3, EventScheduleId = 1, Time = "11:00 AM", Activity = "Hacking Begins", CreatedAt = _seedTime },
                new ScheduleActivity { Id = 4, EventScheduleId = 2, Time = "02:00 PM", Activity = "Project Submissions", CreatedAt = _seedTime },
                new ScheduleActivity { Id = 5, EventScheduleId = 2, Time = "04:00 PM", Activity = "Presentations", CreatedAt = _seedTime },
                new ScheduleActivity { Id = 6, EventScheduleId = 2, Time = "06:00 PM", Activity = "Awards Ceremony", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<ScheduleActivity>().HasData(activities);

            // Seed Event Rules
            var rules = new[]
            {
                new EventRule { Id = 1, EventId = 1, Description = "Teams must consist of 2-4 members", CreatedAt = _seedTime },
                new EventRule { Id = 2, EventId = 1, Description = "All code must be written during the hackathon", CreatedAt = _seedTime },
                new EventRule { Id = 3, EventId = 1, Description = "Use of open-source libraries is allowed", CreatedAt = _seedTime },
                new EventRule { Id = 4, EventId = 1, Description = "Projects must incorporate AI/ML components", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<EventRule>().HasData(rules);

            // Seed Event Prizes
            var prizes = new[]
            {
                new EventPrize { Id = 1, EventId = 1, Place = "1st Place", Reward = "$5000", CreatedAt = _seedTime },
                new EventPrize { Id = 2, EventId = 1, Place = "2nd Place", Reward = "$3000", CreatedAt = _seedTime },
                new EventPrize { Id = 3, EventId = 1, Place = "3rd Place", Reward = "$1000", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<EventPrize>().HasData(prizes);

            // Seed Prize Benefits
            var benefits = new[]
            {
                new PrizeBenefit { Id = 1, EventPrizeId = 1, Description = "Direct interview with tech partners", CreatedAt = _seedTime },
                new PrizeBenefit { Id = 2, EventPrizeId = 1, Description = "1-year AI cloud credits", CreatedAt = _seedTime },
                new PrizeBenefit { Id = 3, EventPrizeId = 2, Description = "6-month AI cloud credits", CreatedAt = _seedTime },
                new PrizeBenefit { Id = 4, EventPrizeId = 3, Description = "3-month AI cloud credits", CreatedAt = _seedTime }
            };

            modelBuilder.Entity<PrizeBenefit>().HasData(benefits);

            // Seed Event Venue
            var venue = new EventVenue
            {
                Id = 1,
                EventId = 1,
                Name = "Tech Innovation Center",
                Address = "123 Innovation Street, Silicon Valley, CA",
                MapLink = "https://maps.google.com/",
                CreatedAt = _seedTime
            };

            modelBuilder.Entity<EventVenue>().HasData(venue);

            // Seed Event Sponsors
            var sponsors = new[]
            {
                new EventSponsor
                {
                    Id = 1,
                    EventId = 1,
                    Name = "TechCorp",
                    Logo = "https://example.com/techcorp-logo.png",
                    Website = "https://techcorp.com",
                    CreatedAt = _seedTime
                },
                new EventSponsor
                {
                    Id = 2,
                    EventId = 1,
                    Name = "AI Solutions",
                    Logo = "https://example.com/ai-solutions-logo.png",
                    Website = "https://aisolutions.com",
                    CreatedAt = _seedTime
                }
            };

            modelBuilder.Entity<EventSponsor>().HasData(sponsors);
        }
    }
} 