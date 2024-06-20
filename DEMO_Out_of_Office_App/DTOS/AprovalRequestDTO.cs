namespace DEMOOutOfOfficeApp.DTOS
{
    public record AprovalRequestDTO(int id,int LeaveRequestID, string HrManager, string PmManager , string Status,string Comment, bool ApprovedHr = false, bool ApprovedPm = false);
}
