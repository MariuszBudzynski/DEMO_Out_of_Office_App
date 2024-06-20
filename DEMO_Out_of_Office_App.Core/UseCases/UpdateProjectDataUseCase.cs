using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class UpdateProjectDataUseCase : IUpdateProjectDataUseCase
    {
        private readonly IRepository _repository;

        public UpdateProjectDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Project project)
        {
            await _repository.UpdateProjectData(project);
        }
    }
}
