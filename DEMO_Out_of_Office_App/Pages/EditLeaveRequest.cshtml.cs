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
    public class EditLeaveRequestModel : PageModel
    {
        private int _id;
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IUpdateLeaveRequestUseCase _updateLeaveRequestUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IGetLeaveRequestsUseCase _getLeaveRequestsUseCase;

        //[BindProperty(SupportsGet = true)]
        //public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        [BindProperty(SupportsGet = true)]
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }

        public EditLeaveRequestModel(IDataLoaderHelper dataLoaderHelper,
                                    IUpdateLeaveRequestUseCase updateLeaveRequestUseCase,
                                    IGetDataByIdUseCase getDataByIdUseCase,
                                    IGetLeaveRequestsUseCase getLeaveRequestsUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _updateLeaveRequestUseCase = updateLeaveRequestUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _getLeaveRequestsUseCase = getLeaveRequestsUseCase;
        }

        public async Task OnGet(int id)
        {
            LeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).FirstOrDefault(lr => lr.EmployeeID == id);
            AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();
            FullName = (await _dataLoaderHelper.LoadAllEmployeesAsync()).FirstOrDefault(e => e.ID == id).FullName;
            Status = (await _getLeaveRequestsUseCase.ExecuteAsync()).FirstOrDefault(e=> e.ID == id).StatusType.ToString();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            LeaveRequest.StatusType = LeaveRequestsStatusType.New;

            await _updateLeaveRequestUseCase.ExecureAsync(LeaveRequest);

            return RedirectToPage("LeaveRequests");
        }
    }
}
