namespace DEMOOutOfOfficeApp.DTOS
{
    public record AprovalRequestDTO(int id,string Aprover,int LeaveRequestId,string Status,string Comment);
}
