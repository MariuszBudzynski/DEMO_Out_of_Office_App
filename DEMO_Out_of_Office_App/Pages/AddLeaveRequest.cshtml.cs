using Azure.Core;
using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
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
    public class AddLeaveRequestModel : PageModel, ILeaveRequestFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveLeaveRequestDataUseCase _saveLeaveRequestDataUseCase;
        private readonly IGetEmployeeProjectsUseCase _getEmployeeProjectsUseCase;
        private readonly ISaveListOfObjectsToDatabaseUseCase _saveListOfObjectsToDatabaseUseCase;

        [BindProperty(SupportsGet = true)]
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }
        public ApprovalRequest ApprovalRequest { get; set; }
        public List<ApprovalRequest> ApprovalsRequest { get; set; } = new();

        public AddLeaveRequestModel(IDataLoaderHelper dataLoaderHelper,
                                    ISaveLeaveRequestDataUseCase saveLeaveRequestDataUseCase,
                                    ISaveListOfObjectsToDatabaseUseCase saveListOfObjectsToDatabaseUseCase
                                   )
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveLeaveRequestDataUseCase = saveLeaveRequestDataUseCase;
            _saveListOfObjectsToDatabaseUseCase = saveListOfObjectsToDatabaseUseCase;
        }
        public async Task OnGet(int id)
        {

            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();

            LeaveRequest = new LeaveRequest() { EmployeeID = id, StatusType = LeaveRequestsStatusType.New, StartDate = DateTime.Now, EndDate = DateTime.Now };

            FullName = (await _dataLoaderHelper.LoadAllEmployeesAsync()).FirstOrDefault(e => e.ID == id).FullName;

        }

        public async Task<IActionResult> OnPostAsync()
        {

            LeaveRequest.StatusType = LeaveRequestsStatusType.New;

            await _saveLeaveRequestDataUseCase.ExecuteAsync(LeaveRequest);

            ApprovalsRequest = await CreateNewApprovalRequestList(LeaveRequest.ID);

            await _saveListOfObjectsToDatabaseUseCase.ExecuteAsync(ApprovalsRequest);

            return RedirectToPage("/LeaveRequests");
        }

        private async Task<List<ApprovalRequest>> CreateNewApprovalRequestList(int id)
        {
            var approvalList = new List<ApprovalRequest>();

            var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).Where(pe => pe.EmployeeID == id).ToList();

            var projectManagerIds = employeeProjects.Select(ep => ep.Project.ProjectManagerID).Distinct().ToList();

            var employeeHRApproverId = (await _dataLoaderHelper.LoadEmpoloyeeAsync(id)).PeoplePartnerID;

            foreach (var pm in projectManagerIds)
            {
                var approvalRequest = new ApprovalRequest()
                {
                    LeaveRequestID = LeaveRequest.ID,
                    StatusID = 1,
                    Comment = LeaveRequest.Comment,
                    EmployeeId = id,
                    HrManagerId = employeeHRApproverId,
                    PmManagerId = pm,
                    ApprovedHr = false,
                    ApprovedPm = false
                };

                approvalList.Add(approvalRequest);
            }

            return approvalList;
        }

    }
}
