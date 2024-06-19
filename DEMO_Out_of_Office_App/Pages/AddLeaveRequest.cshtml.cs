using Azure.Core;
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
        private readonly ISaveDataUseCase _saveDataUseCase;

        [BindProperty(SupportsGet = true)]
        public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; } = new List<AbsenceReason>();

        public AddLeaveRequestModel(IDataLoaderHelper dataLoaderHelper, IGetDataByIdUseCase getDataByIdUseCase,ISaveDataUseCase saveDataUse)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _getDataByIdUseCase = getDataByIdUseCase;
            _saveDataUseCase = _saveDataUseCase;
        }
        public async Task OnGet(int id)
        {
            _id = id;
            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();
            LeaveRequestDTO = await CreateNewLeaveRequestDTOAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await CreateAndSaveLeaveRequestAsync();

            return RedirectToPage("/LeaveRequests");
        }

        private async Task CreateAndSaveLeaveRequestAsync()
        {
            var newLeaveRequest = CreateNewLeaveRequest();
            await _saveDataUseCase.ExecuteAsync(newLeaveRequest);
        }

        private async Task<LeaveRequestDTO> CreateNewLeaveRequestDTOAsync(int id)
        {
            var employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(_id);

            return new LeaveRequestDTO(_id,employee.PeoplePartnerID ,employee.FullName, String.Empty, DateTime.Now, DateTime.Now, String.Empty, LeaveRequestsStatusType.New.ToString());
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

        private async Task<ApprovalRequest> CreateNewApprovalRequestHR()
        {
            List<ApprovalRequest> ApprovalRequests = new();

            var leaveRequestId = await GetLastLeaveRequestIdAsync();

            var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).Select(e => e.Project.ProjectManagerID);

            

            return new ApprovalRequest()
            {
                

            };
        }

        private async Task<int> GetLastLeaveRequestIdAsync()
        {
            var lastLeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).LastOrDefault();
            return lastLeaveRequest?.ID ?? 0;
        }



    }
}
