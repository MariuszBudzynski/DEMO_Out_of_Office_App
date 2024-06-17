using DEMOOutOfOfficeApp.Core.Entities;
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

        [BindProperty(SupportsGet = true)]
        public LeaveRequestDTO? LeaveRequestDTO { get; set; }
        
        //public LeaveRequest LeaveRequest { get; set; }

        public EditLeaveRequestModel(DataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }

        public async Task OnGet(int id)
        {
            _id = id;
            await LoadLeaveRequest();
        }

        public async Task LoadLeaveRequest()
        {
            var leaveRequests = (await _dataLoaderHelper.LoadLeaveRequestsDTOAsync()).FirstOrDefault(e => e.Id == _id);
            LeaveRequestDTO = leaveRequests;


        }
    }
}
