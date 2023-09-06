using Portfolio.Application.Interfaces.Repositories;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<BlogEntity> Blog { get; }

        IBaseRepository<BlogCategoryEntity> BlogCategory { get; }

        IBaseRepository<ProjectEntity> Project { get; }

        IBaseRepository<PersonalDataEntity> PersonalData { get; }

        public void Dispose();
    }
}
