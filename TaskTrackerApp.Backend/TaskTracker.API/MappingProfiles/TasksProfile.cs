using AutoMapper;
using TaskTracker.Repository.DbEntities;
using TaskTracker.API.Dtos.InputDtos.Tasks;
using TaskTracker.API.Dtos.OutputDtos.Tasks;

public class TasksProfile : Profile
{
    public TasksProfile()
    {
        CreateMap<TaskEntry, TaskDto>();
        CreateMap<TaskCreationDto, TaskEntry>();
        CreateMap<TaskUpdationDto, TaskEntry>();
    }
}