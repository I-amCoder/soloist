using AutoMapper;
using AcmHackathonBackend.Models;
using AcmHackathonBackend.Models.ResponseModels;

namespace AcmHackathonBackend.Mappings
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventResponseModel>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Date.AddDays(1)))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Venue != null ? src.Venue.Name : string.Empty));

            CreateMap<EventSchedule, EventScheduleResponseModel>();

            CreateMap<ScheduleActivity, ScheduleActivityResponseModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Activity))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => DateTime.Parse(src.Time)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.Parse(src.Time).AddHours(1)));

            CreateMap<EventRule, EventRuleResponseModel>();

            CreateMap<EventPrize, EventPrizeResponseModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Place))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Reward))
                    .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => ParseOrdinal(src.Place)));


            CreateMap<PrizeBenefit, PrizeBenefitResponseModel>();

            CreateMap<EventSponsor, EventSponsorResponseModel>();

            CreateMap<Executive, ExecutiveResponseModel>()
                .ForMember(dest => dest.SocialLinks, opt => opt.MapFrom(src => src.SocialLinks));


            CreateMap<ExecutiveSocialLinks, ExecutiveSocialLinksResponseModel>();

            CreateMap<Project, ProjectResponseModel>()
           .ForMember(dest => dest.Technologies, opt => opt.MapFrom(src => src.Technologies))
           .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Features));

            CreateMap<ProjectTechnology, ProjectTechnologyResponseModel>();
            CreateMap<ProjectFeature, ProjectFeatureResponseModel>();
        }
        private int ParseOrdinal(string place)
        {
            var numberPart = new string(place.TakeWhile(char.IsDigit).ToArray());
            return int.TryParse(numberPart, out var rank) ? rank : throw new FormatException($"Invalid place format: {place}");
        }
    }
}
