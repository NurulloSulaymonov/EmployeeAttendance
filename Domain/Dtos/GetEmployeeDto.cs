using Domain.Entites;

namespace Domain.Dtos;

public class GetEmployeeDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender Gender { get; set; }
    public string? Phone { get; set; }
    public List<GetAttendanceDto> Attendances { get; set; }


}
