using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class AddLeaveRequestModel : PageModel, IEditLeaveRequestFormModel
    {
        private int _id;
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly ISaveDataUseCase saveDataUse;

        [BindProperty(SupportsGet = true)]
        public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; } = new List<AbsenceReason>();

        public AddLeaveRequestModel(IDataLoaderHelper dataLoaderHelper, IGetDataByIdUseCase getDataByIdUseCase,ISaveDataUseCase saveDataUse)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _getDataByIdUseCase = getDataByIdUseCase;
            this.saveDataUse = saveDataUse;
        }
        public async Task OnGet(int id)
        {
            _id = id;
            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();
            LeaveRequestDTO = await CreateNewLeaveRequestDTOAsync(id);
        }

        private async Task OnPost()
        {

        }

        private async Task<LeaveRequestDTO> CreateNewLeaveRequestDTOAsync(int id)
        {
            var employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(id);

            return new LeaveRequestDTO(_id, employee.FullName, String.Empty, DateTime.Now, DateTime.Now, String.Empty, LeaveRequestsStatusType.New.ToString());
        }

        private LeaveRequest CreateNewLeaveRequest()
        {
            var absenceReasonId = LeaveRequestDTO.AbsenceReason switch
            {
                "Vacation" => 1,
                "Sick Leave" => 2,
                "Family Leave" => 3,
                "Personal Leave" => 4,
                _ => throw new ArgumentException($"Unknown absence reason: {LeaveRequestDTO.AbsenceReason}")
            };

           return new LeaveRequest()
            {
                EmployeeID = LeaveRequestDTO.Id,
                AbsenceReasonID = absenceReasonId,
                StartDate = LeaveRequestDTO.StartDate,
                EndDate = LeaveRequestDTO.EndDate,
                Comment = LeaveRequestDTO.Comment,
                StatusType = LeaveRequestsStatusType.New
            };
        }

        private async Task<ApprovalRequest> CreateNewApprovalRequest()
        {
            //var aproverid = (await _dataLoaderHelper.LoadEmpoloyeeProjects()).ToList().Where(e=>);

            //var aproverId = _dataLoaderHelper.
            //the random aprover id is just for demonstration purposes
            //var randomApproverId = GetRandomApproverIdAsync().Result;

            return new ApprovalRequest()
            {
                //ApproverID = aproverId.
                //LeaveRequestID = await GetLastLeaveRequestIdAsync()

            };
        }

        private async Task<int> GetLastLeaveRequestIdAsync()
        {
            var lastLeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).LastOrDefault();
            return lastLeaveRequest?.ID ?? 0;
        }

        //private async Task<int> GetRandomApproverIdAsync()
        //{
        //    var employees = (await _dataLoaderHelper.LoadAllEmployeesAsync()).ToList();

        //    if (employees == null || employees.Count == 0)
        //    {
        //        throw new InvalidOperationException("No employees found.");
        //    }

        //    // Generate a random index within the range of employees list
        //    var random = new Random();
        //    int randomIndex = random.Next(0, employees.Count);

        //    // Get the ID of the employee at the randomly chosen index
        //    int randomApproverId = employees[randomIndex].ID;

        //    return randomApproverId;
        //}



    }
}
