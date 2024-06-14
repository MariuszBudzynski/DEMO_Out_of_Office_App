﻿using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Context;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEMOOutOfOfficeApp.Core.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<T>> GetData<T>() where T : class, IEntityId
        {
           return await _appDbContext.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _appDbContext.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.PeoplePartner)
                .ToListAsync();
        }

    }
}
