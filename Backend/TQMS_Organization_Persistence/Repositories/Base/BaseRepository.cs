namespace TQMS_Organization_Persistence.Repositories.Base
{
    public abstract class BaseRepository<TEnity>/*(OrganizationDBContext context) */: IBaseRepository<TEnity> where TEnity : BaseEntity
    {
        protected readonly OrganizationDBContext _context;

        // Constructor to inject the OrganizationDBContext
        public BaseRepository(OrganizationDBContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(TEnity entity)
        {
          await _context.Set<TEnity>().AddAsync(entity);

        }

        public async Task DeleteByIdAsync(Guid id)
        {
           var entity= await _context.Set<TEnity>().FindAsync(id);
            if(entity!=null)
            {
                _context.Set<TEnity>().Update(entity);
            }
        }

        public void DeleteAsync(TEnity entity)
        {
            if(entity != null)
            {
                _context.Set<TEnity>().Update(entity);
            }
        }
        public async Task<IEnumerable<TEnity>> GetAllAsync()
        {
            return await _context.Set<TEnity>().ToListAsync();
        }

        public async Task<TEnity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEnity>().FindAsync(id) ?? default!;
            //context.Set<TEnity>(): This accesses the DbSet for the entity type TEnity from the database context.
            //?? default!: This is the null-coalescing operator. If FindAsync(id) returns null,
            //the method returns the default value for the type TEnity.
        }

        public async Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<TEnity, bool>> predicate, 
            Expression<Func<TEnity, TResult>> selector)
        {
            return await GetFilteredListAsync(predicate, null, selector, false);
        }

        public async Task<IEnumerable<TEnity>> GetFilteredListAsync(Expression<Func<TEnity, bool>> predicate)
        {
            return await GetFilteredListAsync<TEnity>(predicate,entity=>entity,null,false);
        }

        public async Task<IEnumerable<TResult>> GetFilteredListAsync<TResult>(Expression<Func<TEnity, bool>> predicate, 
            Expression<Func<TEnity, object>> orderBy, Expression<Func<TEnity, TResult>>? selector, bool descending = false)
        {
            var query = _context.Set<TEnity>().Where(predicate);
            if (orderBy != null)
            {
                query = descending
                    ? query.OrderByDescending(orderBy)
                    : query.OrderBy(orderBy);
            }

            if (selector != null)
            {
                return await query.Select(selector).ToListAsync();
            }
            return (IEnumerable<TResult>)await query.ToListAsync();
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEnity, bool>> predicate, 
            Expression<Func<TEnity, TResult>> selector)
        {
            return await _context.Set<TEnity>()
                .Where(predicate)
                .Select(selector)
                .AsQueryable()
                .FirstOrDefaultAsync()??default!;
        }

        public async Task<TResult> GetSingleOrDefaultAsync<TResult>(Expression<Func<TEnity, bool>> predicate, 
            Expression<Func<TEnity, TResult>> selector)
        {
            return await _context.Set<TEnity>()
                .Where(predicate)
                .Select(selector)
                .AsQueryable()
                .SingleOrDefaultAsync() ?? default!;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(TEnity entity)
        {
            _context.Set<TEnity>().Update(entity);
        }
    }
}
