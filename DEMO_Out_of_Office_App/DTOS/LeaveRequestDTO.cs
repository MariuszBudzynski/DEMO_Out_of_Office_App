namespace DEMOOutOfOfficeApp.DTOS
{
    public record LeaveRequestDTO(int Id,string EmployeeName,string AbsenceReason,DateTime StartDate,DateTime EndDate,string Comment,string Status);

}
