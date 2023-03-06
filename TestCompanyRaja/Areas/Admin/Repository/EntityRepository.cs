
using Microsoft.EntityFrameworkCore;
using TestCompanyRaja.Areas.Admin.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace TestCompanyRaja.Areas.Admin
{
 
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TestCompanyRajaDbContext _dbContext;
        private DbSet<TEntity> table = null;
        public EntityRepository(TestCompanyRajaDbContext context)
        {
            _dbContext = context;
            table = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();

        }

        public void Edit(TEntity entity)
        {
            table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public TEntity FindBy(object Id)
        {
            return table.Find(Id);
        }

        public List<TEntity> GetAll()
        {
            return table.ToList();
        }

        
    }
}