using AutoMapper;
using hoangtiendung.Core.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace hoangtiendung.Core.Service.Repository
{
    public class Repository<TEntity, TModel> : IRepository<TEntity, TModel> where TEntity : class, new() where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly DbContext _context;
        public Repository(IMapper mapper, DbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            TEntity entity = _mapper.Map<TEntity>(model);
            _context.Set<TEntity>().AddAsync(entity);
            throw new NotImplementedException();
        }

        public void AddMore(IEnumerable<TModel> models)
        {
            if (models == null)
                throw new ArgumentNullException("model");
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(models);
            _context.Set<TEntity>().AddRangeAsync(entities);
            throw new NotImplementedException();
        }

        public void Delete(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            TEntity entity = _mapper.Map<TEntity>(model);
            _context.Set<TEntity>().Remove(entity);
            throw new NotImplementedException();
        }

        public void DeleteMore(IEnumerable<TModel> models)
        {
            if (models == null)
                throw new ArgumentNullException("model");
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(models);
            _context.Set<TEntity>().RemoveRange(entities);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            Expression<Func<TEntity, bool>> expressionEntity = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().Where(expressionEntity).ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TModel>> Paging(Expression<Func<TModel, bool>> expression,int page,int size)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            Expression<Func<TEntity, bool>> expressionEntity = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().Where(expressionEntity).Skip(page * size).Take(size).ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<TModel>> GetAll()
        {
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().ToListAsync();
            IEnumerable<TModel> models = _mapper.Map<IEnumerable<TModel>>(entities).ToList();
            return models;
            throw new NotImplementedException();
        }

        public async Task<TModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("id");
            var entity = await _context.Set<TEntity>().FindAsync(id);
            TModel model = _mapper.Map<TModel>(entity);
            return model;
            throw new NotImplementedException();
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public void Update(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            TEntity entity = _mapper.Map<TEntity>(model);
            _context.Update(entity);
            throw new NotImplementedException();
        }

        public void UpdateMore(IEnumerable<TModel> models)
        {
            if (models == null)
                throw new ArgumentNullException("models");
            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(models);
            _context.UpdateRange(entities);
            throw new NotImplementedException();
        }
    }
}
