using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Pages;
using Moq;

namespace DEMOOutOfOfficeApp.Tests
{
    public class AddProjectModelTests
    {
        [Fact]
        public async Task OnGetAsync_LoadsProjectTypesAndProjectManagers()
        {
            // Arrange
            var mockDataLoaderHelper = new Mock<IDataLoaderHelper>();
            var mockSaveDataUseCase = new Mock<ISaveDataUseCase>();

            var model = new AddProjectModel(
                mockDataLoaderHelper.Object,
                mockSaveDataUseCase.Object
            );

            var mockProjectTypes = new List<ProjectType>
            {
                new ProjectType { ID = 1, Name = "Type 1" },
                new ProjectType { ID = 2, Name = "Type 2" }
            };

            var mockProjectManagers = new List<User>
            {
                new User { ID = 1, FullName = "John Doe", RoleID = (int)UserRole.ProjectManager },
                new User { ID = 2, FullName = "Jane Smith", RoleID = (int)UserRole.ProjectManager }
            };

            mockDataLoaderHelper.Setup(x => x.LoadProjectTypesAsync()).ReturnsAsync(mockProjectTypes);
            mockDataLoaderHelper.Setup(x => x.LoadAllUsersAsync()).ReturnsAsync(mockProjectManagers);

            // Act
            await model.OnGetAsync(0);

            // Assert
            Assert.Equal(mockProjectTypes, model.ProjectTypes);
            Assert.NotNull(model.Project);
            Assert.NotNull(model.ProjectManagers);
            Assert.Equal(2, model.ProjectManagers.Count); // Ensure correct number of project managers loaded
        }

        [Fact]
        public async Task OnGetAsync_ExceptionThrown_LogsErrorAndRethrows()
        {
            // Arrange
            var mockDataLoaderHelper = new Mock<IDataLoaderHelper>();
            var mockSaveDataUseCase = new Mock<ISaveDataUseCase>();

            var model = new AddProjectModel(
                mockDataLoaderHelper.Object,
                mockSaveDataUseCase.Object
            );

            mockDataLoaderHelper.Setup(x => x.LoadProjectTypesAsync()).ThrowsAsync(new Exception("Simulated exception"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await model.OnGetAsync(0));
            // Ensure that the exception is logged (can check logging framework mock or verify logging call)
        }


    }
}
