using System.Collections.Generic;
using System.Linq.Expressions;
using TestCompanyRaja.Areas.Admin.Models.Domain;

namespace TestCompanyRaja.Areas.Admin
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        TEntity FindBy(object Id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
    }
}
