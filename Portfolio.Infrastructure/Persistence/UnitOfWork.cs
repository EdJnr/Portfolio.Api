using Portfolio.Application.Interfaces;
using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<BlogEntity> Blog => new BaseRepository<BlogEntity>("Blog");

        public IBaseRepository<BlogCategoryEntity> BlogCategory => new BaseRepository<BlogCategoryEntity>("BlogCategories");

        public IBaseRepository<ProjectEntity> Project => new BaseRepository<ProjectEntity>("Projects");

        public IBaseRepository<PersonalDataEntity> PersonalData => new BaseRepository<PersonalDataEntity>("PersonalData");

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
