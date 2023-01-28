using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.Common.Interfaces;
public interface IBaseService<TEntity> where TEntity : class
{
    Task<IQueryable<TEntity>> GetAll();
    Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> where);
    Task<TEntity> GetBYID(int Id);
    Task<bool> Update(TEntity entity);
    Task<int> Insert(TEntity entity);
    Task<bool> InsertMany(ICollection<TEntity> entities);
    Task<bool> Delete(int id, bool DisableDeleteforCascade = false);
    Task<bool> Save();

}
