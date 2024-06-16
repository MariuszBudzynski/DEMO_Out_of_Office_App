using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Models
{
    public interface IApprovalRequestsFormModel
    {
        public int ID { get; set; }
        public List<Employee> Approver { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }
        public List<ApprovalRequestStatus> Status { get; set; }
        public string Comment { get; set; }
    }
}
