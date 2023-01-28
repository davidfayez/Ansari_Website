using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Domain.Common;
using Ansari_Website.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Ansari_Website.Infrastructure.Common.ExtensionMethods;
using CommonTbl = Ansari_Website.Domain.Common;
namespace Ansari_Website.Infrastructure.Services;
public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : CommonTbl.Common
{
        private ApplicationDbContext _context;
        private DbSet<TEntity> Table;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int USERID;
        public BaseService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.Table = _context.Set<TEntity>();
             _httpContextAccessor = httpContextAccessor.CheckIsNullOrContextNull();
            USERID = _httpContextAccessor.HttpContext == null ? 0: _httpContextAccessor.HttpContext.User.GetUserId();
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return Table.AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> where)
        {
            return Table.Where(where).AsNoTracking();
        }
        public virtual async Task<TEntity> GetBYID(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            return null;
        }

        public virtual async Task<int> Insert(TEntity entity)
        {

            entity.CreatedBy = USERID;
            await Table.AddAsync(entity);
            if (await Save())
            {
                var idProperty = entity.GetType().GetProperty("Id")?.GetValue(entity, null);
                return (int)(idProperty == null ? 0 : idProperty);
            }
            return 0;
        }
        public virtual async Task<bool> InsertMany(ICollection<TEntity> entities)
        {
            entities.Select(x => { x.CreatedBy = USERID; return x; }).ToList();
            await Table.AddRangeAsync(entities);
            return await Save();

        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            entity.ModefiedOn = DateTime.UtcNow;
            entity.ModefiedBy = USERID;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.IsActive).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedOn).IsModified = false;
            _context.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
            return await Save();
        }

        public virtual async Task<bool> Delete(int id, bool DisableDeleteforCascade = false)
        {
            TEntity entity = null;// await GetBYID(id);

            if (DisableDeleteforCascade)
            {
                var query = _context.Set<TEntity>().Where(x => x.Id == id);
                var oneToManyRelations = _context.Model.GetNavigationProperties<TEntity>(RelationshipMultiplicity.Many);
                foreach (var relation in oneToManyRelations.Select(x => x.Name))
                {
                    query = query.Include(relation);
                }
                entity = await query.FirstOrDefaultAsync();
                foreach (var relation in oneToManyRelations.Select(x => x.Name))
                {
                    var rr = entity.GetType().GetProperty(relation).GetValue(entity);
                    int countValue = (int)(rr.GetType().GetProperty("Count")?.GetValue(rr, null));
                    if (countValue > 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                entity = await GetBYID(id);
            }

            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedOn = DateTime.UtcNow;
                entity.DeletedBy = USERID;
                _context.Entry(entity).State = EntityState.Modified;
                return await Save();
            }
            return false;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }



    }
