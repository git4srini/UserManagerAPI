using System;
using System.Collections.Generic;
using System.Text;
using UserManager.Repository;
using Xunit;

namespace UserManager.Test
{
    public class QueryTestFixture : IDisposable
    {
        public UserManagerDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = MockUserManagerDbContext.Create();
        }

        public void Dispose()
        {
           MockUserManagerDbContext.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
