using AutoMapper;
using TaskTracker.Repository.DbEntities;
using TaskTracker.API.Dtos.InputDtos.Tags;
using TaskTracker.API.Dtos.OutputDtos.Tags;

public class TagsProfile : Profile
{
    public TagsProfile()
    {
        CreateMap<Tag, TagDto>();
        CreateMap<TagCreationDto, Tag>();
    }
}