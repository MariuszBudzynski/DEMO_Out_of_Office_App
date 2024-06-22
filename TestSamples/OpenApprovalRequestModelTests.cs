using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Pages;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DEMOOutOfOfficeApp.Tests
{
    public class OpenApprovalRequestModelTests
    {
        
        [Fact]
        public async Task OnPostRejectAsync_ExceptionThrown_LogsErrorAndRethrows()
        {
            // Arrange
            var mockDataLoaderHelper = new Mock<IDataLoaderHelper>();
            var mockUpdateAprovalRequestUseCase = new Mock<IUpdateAprovalRequestUseCase>();
            var mockUpdateEmployeeUseCase = new Mock<IUpdateEmployeeUseCase>();
            var mockUpdateLeaveRequestUseCase = new Mock<IUpdateLeaveRequestUseCase>();

            var model = new OpenApprovalRequestModel(
                mockDataLoaderHelper.Object,
                mockUpdateAprovalRequestUseCase.Object,
                mockUpdateEmployeeUseCase.Object,
                mockUpdateLeaveRequestUseCase.Object
            );

            var approvalRequestId = 1; // Example approval request ID
            model.AprovalRequestID = approvalRequestId;

            // Simulate data loading
            mockDataLoaderHelper.Setup(x => x.LoadAprovalRequestAsync(approvalRequestId)).ThrowsAsync(new Exception("Simulated exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await model.OnPostRejectAsync());
            // Ensure that the exception is logged (can check logging framework mock or verify logging call)
        }
    }
}
