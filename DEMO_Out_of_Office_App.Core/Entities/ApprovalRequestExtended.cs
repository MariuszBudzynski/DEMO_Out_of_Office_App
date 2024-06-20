using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class ApprovalRequestExtended : IEntityId
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApprovalRequest")]
        public int ApprovalRequestID { get; set; }

        public int EmployeeId { get; set; }

        public int HrManagerId { get; set; }

        public int PmManagerId { get; set; }

        public bool ApprovedHr { get; set; }

        public bool ApprovedPm { get; set; }

       
        public virtual Approval Approvals { get; set; }
    }
}

