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
