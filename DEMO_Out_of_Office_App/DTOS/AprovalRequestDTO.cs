﻿namespace DEMOOutOfOfficeApp.DTOS
{
    public record AprovalRequestDTO(int id,int LeaveRequestID, string Status,string Comment, int ApproverID,bool RequestAproved, string ApproverName = "");
}
