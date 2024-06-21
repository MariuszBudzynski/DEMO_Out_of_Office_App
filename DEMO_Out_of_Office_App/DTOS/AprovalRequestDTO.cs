namespace DEMOOutOfOfficeApp.DTOS
{
    public record AprovalRequestDTO(int id, string Status,string Comment, int ApproverID, int LeaveRequestID =0, string AbsenceReason = "", string AbsenceReasonComment = "");
}
