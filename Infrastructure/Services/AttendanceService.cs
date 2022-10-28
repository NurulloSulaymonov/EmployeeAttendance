using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Response;
using Infrastructure.Context;
namespace Infrastructure.Services;
public class AttendanceService : IAttendanceService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public AttendanceService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddAttendance(AddAttendanceDto model)
    {
        try
        {
            var mapped = _mapper.Map<Attendance>(model);
            await _context.Attendances.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<string>(_mapper.Map<string>("Attendance Added Successfully"));
        }
        catch (Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<GetEmployeeAverageDto>> GetEmployeeAverage(EmployeeAttendanceFilterDto model)
    {
        var filter = _context.Attendances.Where(a=>a.EmployeeId == model.EmployeeId && a.Date >= model.StartDate.UtcDateTime && a.Date<=model.EndDate.UtcDateTime).ToList();
        if(filter.Count == 0)
        {
            return new Response<GetEmployeeAverageDto>(System.Net.HttpStatusCode.NotFound, "No Data Found");
        }

        var average = filter.Average(x => x.StartTime.TotalMilliseconds);
        var response = new GetEmployeeAverageDto()
        {
            EmployeeId = model.EmployeeId,
            AverageTime = TimeSpan.FromMilliseconds(average).ToString()
        };
        return new Response<GetEmployeeAverageDto>(response);
    }
    // filter
    // employeeId = 1
    // startDate = 2021-01-01
    // endDate = 2021-01-31
    
    // id = 1, name = "John", age = 30, address = "New York"
    // id = 2, name = "Mary", age = 25, address = "London"
    // id = 3, name = "John", age = 30, address = "New York" 
    
    //attendance
    // id = 1, employeeId = 1, date = "2021-01-01", startTime = "18:00:00" status = "Present" +
    // id = 2, employeeId = 1, date = "2021-01-02",  startTime = "18:00:00" status = "Present" +
    // id = 3, employeeId = 1, date = "2021-01-03",  startTime = "18:00:00" status = "Present" +















}