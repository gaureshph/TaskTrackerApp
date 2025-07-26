using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Repository.Repositories;
using TaskTracker.API.Dtos.OutputDtos.Statuses;

namespace TaskTrackerApp.API.Controllers;

[ApiController]
[Route("statuses")]
public class StatusesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IStatusesRepository statusesRepository;

    public StatusesController(IMapper mapper, IStatusesRepository statusesRepository)
    {
        this.mapper = mapper;
        this.statusesRepository = statusesRepository;
    }

    [HttpGet(Name = "GetStatuses")]
    public async Task<IActionResult> GetStatuses()
    {
        var statuses = await statusesRepository.GetStatusesAsync();
        var statusDtos = mapper.Map<List<StatusDto>>(statuses);

        return Ok(statusDtos);
    }
}
