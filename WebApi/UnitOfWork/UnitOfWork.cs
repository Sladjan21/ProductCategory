using Models.Interfaces;
using Models.Data.Contexts;
using Models.Repositories;

namespace Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public UnitOfWork(AppDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _appDbContext = context;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }

        public int Complete() => _appDbContext.SaveChanges();

        public async Task<int> CompleteAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose() => _appDbContext.Dispose();
    }
}
