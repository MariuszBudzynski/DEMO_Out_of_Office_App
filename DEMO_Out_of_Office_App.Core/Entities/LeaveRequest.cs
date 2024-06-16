using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class LeaveRequest : IEntityId
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        [ForeignKey("AbsenceReason")]
        public int AbsenceReasonID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        [Required]
        [ForeignKey("LeaveRequestsStatus")]
        public LeaveRequestsStatusType StatusType { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual AbsenceReason AbsenceReason { get; set; }
        public virtual LeaveRequestsStatus LeaveRequestsStatus { get; set; }
    }
}
