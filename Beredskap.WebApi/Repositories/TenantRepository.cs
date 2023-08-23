using System.Linq.Expressions;
using Beredskap.Domain.Entities;
using Beredskap.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beredskap.WebApi.Repositories;

public partial class TenantRepository : IRepository<TenantEntity>
{
    private readonly DbContext _context;

    public TenantRepository(DbContext context)
    {
        _context = context;
    }

    public TenantEntity GetById(Guid id)
    {
        return _context.Set<TenantEntity>().Find(id);
    }

    public IEnumerable<TenantEntity> GetAll()
    {
        return _context.Set<TenantEntity>().ToList();
    }

    public IEnumerable<TenantEntity> Find(Expression<Func<TenantEntity, bool>> predicate)
    {
        return _context.Set<TenantEntity>().Where(predicate).ToList();
    }

    public void Add(TenantEntity entity)
    {
        _context.Set<TenantEntity>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(TenantEntity entity)
    {
        _context.Set<TenantEntity>().Update(entity);
        _context.SaveChanges();
    }

    public void Remove(TenantEntity entity)
    {
        _context.Set<TenantEntity>().Remove(entity);
        _context.SaveChanges();
    }
}