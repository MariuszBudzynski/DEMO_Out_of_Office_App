namespace DEMOOutOfOfficeApp.DTOS
{
    public record LeaveRequestDTO(int Id,int HrManagerId ,string EmployeeName,string AbsenceReason,DateTime StartDate,DateTime EndDate,string Comment,string Status);

}
