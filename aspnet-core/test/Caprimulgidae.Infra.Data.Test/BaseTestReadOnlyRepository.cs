using Antilopes.Domain.Core.Repositorys;
using Antilopes.Repository.Dapper;
using FluentAssertions;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.Data.Test
{
    public abstract class BaseTestReadOnlyRepository<TestReadOnlyRepository, ImplementationTestReadOnlyRepository> : IDisposable
        where ImplementationTestReadOnlyRepository : BaseDapperRepository
        where TestReadOnlyRepository : IReadOnlyRepository
    {
        protected readonly TestReadOnlyRepository readOnlyRepository;
        protected BaseTestReadOnlyRepository()
        {
            var testReadOnlyRepository = Activator.CreateInstance<ImplementationTestReadOnlyRepository>() as IReadOnlyRepository;
            readOnlyRepository = (TestReadOnlyRepository)testReadOnlyRepository;
        }

        protected virtual void TestIfNotThrow(Action<TestReadOnlyRepository> action)
        {
            readOnlyRepository.Invoking(x => action.Invoke(x))
                .Should()
                .NotThrow();
        }

        protected virtual async void TestIfBeOfType<ExpectedType>(Func<Task<ExpectedType>> func)
        {
            var taskResult = await func.Invoke();
            taskResult.Should().BeOfType<ExpectedType>();
        }

        public void Dispose()
        {
            readOnlyRepository.Dispose();
        }
    }
}
