using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;

namespace DEMOOutOfOfficeApp.Models
{
    public interface IEditLeaveRequestFormModel
    {
        public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }
    }
}
