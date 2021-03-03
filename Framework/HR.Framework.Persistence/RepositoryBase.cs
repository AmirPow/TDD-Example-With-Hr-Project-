using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HR.Framework.Core.Domain;
using HR.Framework.Core.Persistence;
using HR.Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot>
        where TAggregateRoot : EntityBase, IAggregateRoot<TAggregateRoot>
    {
        protected readonly DbContextBase dbContext;

        protected RepositoryBase(IDbContext dbContext)
        {
            this.dbContext = (DbContextBase)dbContext;
        }

        protected void Create(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Add(aggregateRoot);
        }

        protected void Update(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>();
        }

        protected void Remove(TAggregateRoot aggregateRoot)
        {
            dbContext.Set<TAggregateRoot>().Remove(aggregateRoot);
        }

        protected abstract IEnumerable<Expression<Func<TAggregateRoot, dynamic>>> GetAggregateExpression();
        protected IQueryable<TAggregateRoot> Set
        {
            get
            {
                var set = dbContext.Set<TAggregateRoot>().AsQueryable();
                var includeExpressions = GetAggregateExpression();
                if (includeExpressions != null)
                {
                    foreach (var expression in includeExpressions)
                    {
                        set = set.Include(expression);
                    }

                }
                return set ;
            }
        }
        protected TAggregateRoot GetById(Guid id)
        {
            return Set.Single(e => e.Id == id);
        }

    }
}
