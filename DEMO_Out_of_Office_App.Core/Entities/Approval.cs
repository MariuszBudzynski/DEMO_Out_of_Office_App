using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class Approval
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ApprovalRequest")]
        public int ApprovalRequestID { get; set; }

        [ForeignKey("ApprovalRequestExtended")]
        public int ApprovalRequestExtendedID { get; set; }
      
        public virtual ApprovalRequest ApprovalRequest { get; set; }

        public virtual ApprovalRequestExtended ApprovalRequestExtended { get; set; }
    }
}
