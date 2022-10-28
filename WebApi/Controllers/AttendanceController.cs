using Domain.Dtos;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }
    [HttpGet("GetAverageAttendance")]
    public async Task<Response<GetEmployeeAverageDto>> GetAverageAttendance([FromQuery]EmployeeAttendanceFilterDto attendance)
    {
        return await _attendanceService.GetEmployeeAverage(attendance);
    }
    
    [HttpPost("StartWork")]
    public async Task<Response<string>> AddAttendance(AddAttendanceDto attendance)
    {
        return await _attendanceService.AddAttendance(attendance);
    }

    
}
