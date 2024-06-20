using Azure.Core;
using DEMOOutOfOfficeApp.Common.Enums;
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
        public List<ApprovalRequestExtended> ApprovalRequestExtended { get; set; } = new();

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
            ApprovalRequestExtended = await CreateApprovalRequestExtended(LeaveRequest.EmployeeID);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //var leaveRequest = new LeaveRequest()
            //{

            //};

            LeaveRequest.StatusType = LeaveRequestsStatusType.New;

            await _saveLeaveRequestDataUseCase.ExecuteAsync(LeaveRequest);

            await repository.SaveListOfApprovalRequestExtendedToDatabase(ApprovalRequestExtended);


            return RedirectToPage("/LeaveRequests");
        }

        private async Task<List<ApprovalRequestExtended>> CreateApprovalRequestExtended(int id)
        {
            var aprovalList = new List<ApprovalRequestExtended>();

            var employeeprojects = (await _getEmployeeProjectsUseCase.ExecuteAsync()).Where(pe => pe.EmployeeID == id).ToList();

            var projectManagerIds = new List<int>();

            foreach (var ids in employeeprojects)
            {
                projectManagerIds.Add(ids.Project.ProjectManagerID);
            }

            //var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).Where(e=>e.EmployeeID == id);

            //var projectManagerIds = employeeProjects.Select(pm => pm.Project.ProjectManagerID);

            //var employeeProjectManagers = (await _dataLoaderHelper.LoadEmpoloyeeProjects(id)).Select(p=>p.ProjectManagerID);



            var employeeHRaproverid = (await _dataLoaderHelper.LoadEmpoloyeeAsync(id)).PeoplePartnerID;

            foreach (var pm in projectManagerIds)
            {
                var aproval = new ApprovalRequestExtended() { EmployeeId = id, HrManagerId = employeeHRaproverid, ApprovedHr = false , PmManagerId = pm , ApprovedPm = false};

                aprovalList.Add(aproval);
            }

            return aprovalList;
        }

        //private async Task CreateAndSaveLeaveRequestAsync()
        //{
        //    var newLeaveRequest = CreateNewLeaveRequest();
        //    await _saveDataUseCase.ExecuteAsync(newLeaveRequest);
        //}

        //private async Task<LeaveRequestDTO> CreateNewLeaveRequestDTOAsync(int id)
        //{
        //    var employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(_id);

        //    return new LeaveRequestDTO(_id,employee.PeoplePartnerID ,employee.FullName, String.Empty, DateTime.Now, DateTime.Now, String.Empty, LeaveRequestsStatusType.New.ToString());
        //}

        //private LeaveRequest CreateNewLeaveRequest()
        //{
        //    var absenceReasonId = LeaveRequestDTO.AbsenceReason switch
        //    {
        //        "Vacation" => 1,
        //        "Sick Leave" => 2,
        //        "Family Leave" => 3,
        //        "Personal Leave" => 4,
        //        _ => throw new ArgumentException($"Unknown absence reason: {LeaveRequestDTO.AbsenceReason}")
        //    };

        //   return new LeaveRequest()
        //    {
        //        EmployeeID = LeaveRequestDTO.Id,
        //        AbsenceReasonID = absenceReasonId,
        //        StartDate = LeaveRequestDTO.StartDate,
        //        EndDate = LeaveRequestDTO.EndDate,
        //        Comment = LeaveRequestDTO.Comment,
        //        StatusType = LeaveRequestsStatusType.New
        //    };
        //}

        //private async Task<ApprovalRequest> CreateNewApprovalRequestHR()
        //{
        //    List<ApprovalRequest> ApprovalRequests = new();

        //    var leaveRequestId = await GetLastLeaveRequestIdAsync();

        //    var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).Select(e => e.Project.ProjectManagerID);



        //    return new ApprovalRequest()
        //    {


        //    };
        //}

        //private async Task<int> GetLastLeaveRequestIdAsync()
        //{
        //    var lastLeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).LastOrDefault();
        //    return lastLeaveRequest?.ID ?? 0;
        //}



    }
}
