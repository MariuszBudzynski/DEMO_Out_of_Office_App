using Moq;
using DEMOOutOfOfficeApp.Helpers;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;

namespace DEMOOutOfOfficeApp.Tests.Helpers
{
    public class DataLoaderHelperTests
    {
        private readonly Mock<IGetDataByIdUseCase> _getDataByIdUseCaseMock;
        private readonly Mock<IGetDataUseCase> _getDataUseCaseMock;
        private readonly Mock<IGetEmployeeProjectsUseCase> _getEmployeeProjectsUseCaseMock;
        private readonly Mock<IGetProjectsUseCase> _getProjectsUseCaseMock;
        private readonly DataLoaderHelper _dataLoaderHelper;

        public DataLoaderHelperTests()
        {
            _getDataByIdUseCaseMock = new Mock<IGetDataByIdUseCase>();
            _getDataUseCaseMock = new Mock<IGetDataUseCase>();
            _getEmployeeProjectsUseCaseMock = new Mock<IGetEmployeeProjectsUseCase>();
            _getProjectsUseCaseMock = new Mock<IGetProjectsUseCase>();

            _dataLoaderHelper = new DataLoaderHelper(
                null, null, null, _getDataByIdUseCaseMock.Object,
                _getProjectsUseCaseMock.Object, null, _getDataUseCaseMock.Object,
                _getEmployeeProjectsUseCaseMock.Object, null);
        }

        [Fact]
        public async Task LoadEmployeeAsync_Returns_Employee()
        {
            // Arrange
            int employeeId = 1;
            var expectedEmployee = new Employee { ID = employeeId, FullName = "John Doe" };
            _getDataByIdUseCaseMock.Setup(x => x.ExecuteAsync<Employee>(employeeId)).ReturnsAsync(expectedEmployee);

            // Act
            var result = await _dataLoaderHelper.LoadEmpoloyeeAsync(employeeId);

            // Assert
            Assert.Equal(expectedEmployee, result);
        }

        [Fact]
        public async Task LoadAllUsersAsync_Returns_Users()
        {
            // Arrange
            var expectedUsers = new List<User>
            {
                new User { ID = 1, FullName = "John Doe" },
                new User { ID = 2, FullName = "Jane Smith" }
            };
            _getDataUseCaseMock.Setup(x => x.ExecuteAsync<User>()).ReturnsAsync(expectedUsers);

            // Act
            var result = await _dataLoaderHelper.LoadAllUsersAsync();

            // Assert
            Assert.Equal(expectedUsers.Count, result.Count());
            Assert.Equal(expectedUsers, result);
        }

        [Fact]
        public async Task LoadProjectsDTOAsync_Exception_Logs_Error()
        {
            // Arrange
            _getEmployeeProjectsUseCaseMock.Setup(x => x.ExecuteAsync()).ThrowsAsync(new Exception("Error in LoadProjectsDTOAsync"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () => await _dataLoaderHelper.LoadProjectsDTOAsync());
            Assert.Contains("Error in LoadProjectsDTOAsync", exception.Message);
            // Additional assertions on logging can be added if logging framework is mockable
        }
    }
}
