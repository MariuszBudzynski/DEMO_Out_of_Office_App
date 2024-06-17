using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EditLeaveRequestModel : PageModel 
    {
        private int _id;
        private readonly DataLoaderHelper _dataLoaderHelper;
        private readonly IUpdateLeaveRequestUseCase _updateLeaveRequestUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;

        [BindProperty(SupportsGet = true)]
        public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; } = new List<AbsenceReason>();
        
        public EditLeaveRequestModel(DataLoaderHelper dataLoaderHelper, IUpdateLeaveRequestUseCase updateLeaveRequestUseCase,IGetDataByIdUseCase getDataByIdUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _updateLeaveRequestUseCase = updateLeaveRequestUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
        }

        public async Task OnGet(int id)
        {
            _id = id;
            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();
            await LoadLeaveRequest();
            
        }

        public async Task LoadLeaveRequest()
        {
            var leaveRequests = (await _dataLoaderHelper.LoadLeaveRequestsDTOAsync()).FirstOrDefault(e => e.Id == _id);
            LeaveRequestDTO = leaveRequests;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var leaveRequest = await _getDataByIdUseCase.ExecuteAsync<LeaveRequest>(LeaveRequestDTO.Id);
            int absenceReasonId = GetAbsenceReasonId(LeaveRequestDTO.AbsenceReason);

            leaveRequest.AbsenceReasonID = absenceReasonId;
            leaveRequest.StartDate = LeaveRequestDTO.StartDate;
            leaveRequest.EndDate = LeaveRequestDTO.EndDate;
            leaveRequest.Comment = LeaveRequestDTO.Comment;
            leaveRequest.StatusType = LeaveRequestsStatusType.New;

           await _updateLeaveRequestUseCase.ExecureAsync(leaveRequest);

            return RedirectToPage("LeaveRequests");
        }

        private async Task<LeaveRequest> CreateNewLeaveRequest()
        {
            int absenceReasonId =  GetAbsenceReasonId(LeaveRequestDTO.AbsenceReason);

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

        private int GetAbsenceReasonId(string absenceReasonName)
        {

            return absenceReasonName switch
            {
                "Vacation" => (int)AbsenceReasonType.Vacation,
                "Sick Leave" => (int)AbsenceReasonType.SickLeave,
                "Family Leave" => (int)AbsenceReasonType.FamilyLeave,
                "Personal Leave" => (int)AbsenceReasonType.PersonalLeave,
            };
        }
    }
}
