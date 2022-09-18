using System.Linq.Expressions;

namespace hoangtiendung.Core.Service.IRepository
{
    public interface IRepository<TEntity, TModel> where TEntity : class, new() where TModel : class
    {
        void Add(TModel model);
        void AddMore(IEnumerable<TModel> models);
        void Update(TModel model);
        void UpdateMore(IEnumerable<TModel> models);
        void Delete(TModel entity);
        void DeleteMore(IEnumerable<TModel> models);
        void SaveChanges();
        Task<TModel> GetById(Guid id);
        Task<IEnumerable<TModel>> GetAll();
        Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> expression);
        Task<IEnumerable<TModel>> Paging(Expression<Func<TModel, bool>> expression, int page, int size);
    }
}
