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
    public class AddLeaveRequestModel : PageModel,ILeaveRequestFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly ISaveLeaveRequestDataUseCase _saveLeaveRequestDataUseCase;
        private readonly IGetEmployeeProjectsUseCase _getEmployeeProjectsUseCase;
        private readonly IRepository repository;

        [BindProperty(SupportsGet = true)]
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }
        public ApprovalRequest ApprovalRequest { get; set; }
        public List<ApprovalRequestExtended> ApprovalsRequestExtended { get; set; } = new();

        public List<ApprovalRequest> ApprovalsRequest { get; set; } = new();

        //public List<int> EmployeeProjectManagerIds { get; set; } = new();


        public AddLeaveRequestModel(IDataLoaderHelper dataLoaderHelper, IGetDataByIdUseCase getDataByIdUseCase,
                                    ISaveLeaveRequestDataUseCase saveLeaveRequestDataUseCase,
                                    IGetEmployeeProjectsUseCase getEmployeeProjectsUseCase,
                                    IRepository repository)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _getDataByIdUseCase = getDataByIdUseCase;
            _saveLeaveRequestDataUseCase = saveLeaveRequestDataUseCase;
            _getEmployeeProjectsUseCase = getEmployeeProjectsUseCase;
            this.repository = repository;
        }
        public async Task OnGet(int id)
        {

            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();

            LeaveRequest = new LeaveRequest() { EmployeeID = id, StatusType = LeaveRequestsStatusType.New ,StartDate = DateTime.Now,EndDate = DateTime.Now};

            FullName = (await _dataLoaderHelper.LoadAllEmployeesAsync()).FirstOrDefault(e => e.ID == id).FullName;

            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            LeaveRequest.StatusType = LeaveRequestsStatusType.New;

            await _saveLeaveRequestDataUseCase.ExecuteAsync(LeaveRequest);

            ApprovalsRequest = await CreateNewApprovalRequestList(LeaveRequest.ID);

            await repository.SaveListOfObjectsToDatabase(ApprovalsRequest);


            ApprovalsRequestExtended = await CreateApprovalRequestExtended(LeaveRequest.EmployeeID, ApprovalsRequest);

            await repository.SaveListOfObjectsToDatabase(ApprovalsRequestExtended);


            return RedirectToPage("/LeaveRequests");
        }

        private async Task<List<ApprovalRequest>> CreateNewApprovalRequestList(int id)
        {
            var aprovalList = new List<ApprovalRequest>();

            var employeeprojects = (await _getEmployeeProjectsUseCase.ExecuteAsync()).Where(pe => pe.EmployeeID == id).ToList();

            var projectManagerIds = new List<int>();

            foreach (var ids in employeeprojects)
            {
                projectManagerIds.Add(ids.Project.ProjectManagerID);
            }

           
            foreach (var pm in projectManagerIds)
            {
                var aproval = new ApprovalRequest()
                {
                    LeaveRequestID = LeaveRequest.ID,
                    StatusID = 1,
                    Comment = LeaveRequest.Comment
                };

                aprovalList.Add(aproval);
            }

            return aprovalList;

        }

        private async Task<List<ApprovalRequestExtended>> CreateApprovalRequestExtended(int id, List<ApprovalRequest> approvalRequests)
        {
            var approvalExtendedList = new List<ApprovalRequestExtended>();

            var employeeProjects = (await _getEmployeeProjectsUseCase.ExecuteAsync()).Where(pe => pe.EmployeeID == id).ToList();

            var employeeHRApproverId = (await _dataLoaderHelper.LoadEmpoloyeeAsync(id)).PeoplePartnerID;

            foreach (var approvalRequest in approvalRequests)
            {
                var approvalExtended = new ApprovalRequestExtended()
                {
                    ApprovalRequestID = approvalRequest.ID,
                    EmployeeId = id,
                    HrManagerId = employeeHRApproverId,
                    ApprovedHr = false,
                    ApprovedPm = false
                };

                foreach (var project in employeeProjects)
                {
                    approvalExtended.PmManagerId = project.Project.ProjectManagerID;
                    approvalExtendedList.Add(approvalExtended);
                }
            }

            return approvalExtendedList;
        }

        //private async Task<int> GetLastLeaveRequestIdAsync()
        //{
        //    var lastLeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).LastOrDefault();
        //    return lastLeaveRequest?.ID ?? 0;
        //}



    }
}
