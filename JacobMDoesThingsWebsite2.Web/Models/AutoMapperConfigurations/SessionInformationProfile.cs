namespace JacobMDoesThingsWebsite2.Web.Models.AutoMapperConfigurations;

public class SessionInformationProfile : Profile
{
    public SessionInformationProfile()
    {
        CreateMap<SessionInformationEntity, SessionInformationDTO>()
        .ForMember(dto => dto.Id, conf => conf.MapFrom(entity => entity.Id))
        .ForMember(dto => dto.TrackingId, conf => conf.MapFrom(entity => entity.TrackingId))
        .ForMember(dto => dto.UserAgent, conf => conf.MapFrom(entity => entity.UserAgent))
        .ForMember(dto => dto.PageVisits, conf => conf.MapFrom(entity => entity.PageVisitEntities));

        CreateMap<SessionInformationDTO, SessionInformationEntity>()
        .ForMember(entity => entity.Id, conf => conf.MapFrom(dto => dto.Id))
        .ForMember(entity => entity.TrackingId, conf => conf.MapFrom(dto => dto.TrackingId))
        .ForMember(entity => entity.UserAgent, conf => conf.MapFrom(dto => dto.UserAgent))
        .ForMember(entity => entity.PageVisitEntities, conf => conf.MapFrom(dto => dto.PageVisits));

        CreateMap<PageVisitEntity, PageVisitDTO>()
        .ForMember(dto => dto.SessionInformationId, conf => conf.MapFrom(entity => entity.SessionInformationEntityId))
        .ForMember(dto => dto.Id, conf => conf.MapFrom(entity => entity.Id))
        .ForMember(dto => dto.StartTime, conf => conf.MapFrom(entity => entity.StartTime))
        .ForMember(dto => dto.EndTime, conf => conf.MapFrom(entity => entity.EndTime))
        .ForMember(dto => dto.URI, conf => conf.MapFrom(entity => entity.URI));

        CreateMap<PageVisitDTO, PageVisitEntity>()
        .ForMember(entity => entity.Id, conf => conf.MapFrom(dto => dto.SessionInformationId))
        .ForMember(entity => entity.Id, conf => conf.MapFrom(dto => dto.Id))
        .ForMember(entity => entity.StartTime, conf => conf.MapFrom(dto => dto.StartTime))
        .ForMember(entity => entity.EndTime, conf => conf.MapFrom(dto => dto.EndTime))
        .ForMember(entity => entity.URI, conf => conf.MapFrom(dto => dto.URI));
    }
}
