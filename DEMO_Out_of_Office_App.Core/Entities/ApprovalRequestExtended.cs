﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class ApprovalRequestExtended
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("ApprovalRequest")]
        public int ApprovalRequestID { get; set; }

        public int EmployeeId { get; set; }

        public int HrManager { get; set; }

        public int PmManager { get; set; }

        public bool ApprovedHr { get; set; }

        public bool ApprovedPm { get; set; }

        public virtual ApprovalRequest ApprovalRequest { get; set; }
    }
}

