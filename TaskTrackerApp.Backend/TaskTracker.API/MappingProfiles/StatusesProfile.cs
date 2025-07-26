using AutoMapper;
using TaskTracker.Repository.DbEntities;
using TaskTracker.API.Dtos.OutputDtos.Statuses;

public class StatusesProfile : Profile
{
    public StatusesProfile()
    {
        CreateMap<Status, StatusDto>();
    }
}