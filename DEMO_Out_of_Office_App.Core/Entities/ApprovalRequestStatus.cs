﻿using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class ApprovalRequestStatus
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public EmployeeStatus StatusType { get; set; }

		public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
	}
}
