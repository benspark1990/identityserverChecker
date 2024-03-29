﻿using Ardalis.Specification;
using IdentityServer.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Api.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}
