using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DEMOOutOfOfficeApp.Models
{
    public interface ILeaveRequestFormModel
    {
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }
    }
}
