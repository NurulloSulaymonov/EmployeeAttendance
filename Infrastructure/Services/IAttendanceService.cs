using Domain.Dtos;
using Domain.Response;

namespace Infrastructure.Services;

public interface IAttendanceService
{
    Task<Response<string>> AddAttendance(AddAttendanceDto model);
    Task<Response<GetEmployeeAverageDto>> GetEmployeeAverage(EmployeeAttendanceFilterDto model);
}
