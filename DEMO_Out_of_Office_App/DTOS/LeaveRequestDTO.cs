namespace DEMOOutOfOfficeApp.DTOS
{
    public record LeaveRequestDTO(int EmployeeId, int HrManagerId ,string EmployeeName,string AbsenceReason,DateTime StartDate,DateTime EndDate,string Comment,string Status);

}
