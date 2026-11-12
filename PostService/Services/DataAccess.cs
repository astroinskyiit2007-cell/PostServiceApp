using Microsoft.EntityFrameworkCore;
using PostService.Models;

namespace PostService;

public class PostingDbContext : DbContext
{
    public DbSet<Posting> Postings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=postings_ef.db");
    }
}

public interface IGenericRepository<TModel> where TModel : ModelBase
{
    List<TModel> GetList();
    TModel? GetById(int id);
    TModel Create(TModel item);
    void Update(TModel item);
    void Delete(int id);
}

public interface IPostingRepository : IGenericRepository<Posting>
{
}

public class GenericEfRepository<TModel> : IGenericRepository<TModel> where TModel : ModelBase
{
    protected readonly DbContext _context;

    public GenericEfRepository(DbContext context)
    {
        _context = context;
    }

    public List<TModel> GetList()
    {
        return _context.Set<TModel>().AsNoTracking().ToList();
    }

    public TModel? GetById(int id)
    {
        return _context.Set<TModel>().AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public TModel Create(TModel item)
    {
        _context.Set<TModel>().Add(item);
        _context.SaveChanges();
        return item;
    }

    public void Update(TModel item)
    {
        _context.Set<TModel>().Update(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _context.Set<TModel>().Find(id);
        if (item != null)
        {
            _context.Set<TModel>().Remove(item);
            _context.SaveChanges();
        }
    }
}

public class PostingRepository : GenericEfRepository<Posting>, IPostingRepository
{
    public PostingRepository(PostingDbContext context) : base(context)
    {
    }
}