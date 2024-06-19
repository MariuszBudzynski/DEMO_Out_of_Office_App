namespace DEMOOutOfOfficeApp.DTOS
{
    public record AprovalRequestDTO(int id,int AproverId,int LeaveRequestId, int EmployeeId, int HrManagerId,string HrManager, int PmManagerId, string PmManager , string Status,string Comment, bool ApprovedHr = false, bool ApprovedPm = false);
}
