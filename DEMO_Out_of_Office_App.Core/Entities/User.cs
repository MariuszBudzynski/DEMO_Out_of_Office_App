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
    public class User : IEntityId, IEmployeeID, IUsername, IPasswordHash
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }

    }
}
