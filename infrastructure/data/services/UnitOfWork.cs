using System;
using System.Collections.Generic;
using domain.generics;
using infraestructure.data.generics;
using Microsoft.EntityFrameworkCore;

namespace infrastructure
{
    public class UnitOfWork : IDisposable
    {
        private DbContext Context;
        public IList<Repository<Entity>> Repositories { get; }

        public void AddRepository(Repository<Entity> repository) {
            Repositories.Add(repository);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
